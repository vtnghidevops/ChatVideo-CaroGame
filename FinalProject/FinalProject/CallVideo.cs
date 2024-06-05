using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FinalProject
{
    public partial class CallVideo : Form
    {

        // Check server
        bool isServer = false;
        string ipClientConnected;
        //bool checkListener = true;
        Socket listenerCam;
        Socket listenerAudio;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


        // Camera
        IPAddress ipAddress;
        private VideoCaptureDevice defaultCamera;
        private FilterInfoCollection cameras;
        int portCamServer = 18999;
        int portCamClient = 17999;

        // Mic
        private WaveInEvent waveIn;
        private Socket audio_sender;
        private BufferedWaveProvider soundProvider;
        private bool isMicrophoneOn = false;
        int portAudioServer = 15234;
        int portAudioClient = 17623;

        // Check ngắt callVideo
        bool isCall = false;



        public CallVideo()
        {
            InitializeComponent();

            // Select camera
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in cameras)
            {
                cb_optionCam.Items.Add(info.Name);
            }
            cb_optionCam.SelectedIndex = 0;



        }

        public CallVideo(bool isServer, IPAddress ipAddress, string ipClientConnected = "")
        {
            InitializeComponent();
            this.isServer = isServer;
            this.ipAddress = ipAddress;
            this.Shown += CallVideo_Shown;
            

            this.ipClientConnected = ipClientConnected;

            // Select camera
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in cameras)
            {
                cb_optionCam.Items.Add(info.Name);
            }
            cb_optionCam.SelectedIndex = 0;
            isCall = true;

           

        }


        private void CallVideo_Shown(object? sender, EventArgs e)
        {
            Task.Run(() => StartCamAndReceiveServer());

            if (defaultCamera != null && defaultCamera.IsRunning)
            {
                defaultCamera.SignalToStop();
            }
            defaultCamera = new VideoCaptureDevice(cameras[cb_optionCam.SelectedIndex].MonikerString);
            defaultCamera.NewFrame += Cam_NewFrame;
            defaultCamera.Start();

            MessageBox.Show("Cam đã được bật", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //private void StartCamAndReceiveServer()
        //{
        //    // Khởi tạo kết nối UDP
        //    if(checkListener)
        //    {
        //        EndPoint localEndPoint = new IPEndPoint(isServer ? ipAddress : IPAddress.Parse(ipClientConnected), isServer ? portCamServer : portCamClient);
        //        listenerCam = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //        listenerCam.Bind(localEndPoint);

        //        while (true)
        //        {
        //            byte[] buffer = new byte[1024 * 30];
        //            int bytesReceived = listenerCam.ReceiveFrom(buffer, ref localEndPoint); // Receive data

        //            if (bytesReceived > 0 && isCall)
        //            {
        //                // Convert byte array to bitmap and update UI
        //                Bitmap bitmap = ByteArrayToBitmap(buffer);
        //                //this.Invoke(new Action(() => ptb_otherCall.Image = bitmap));
        //                this.Invoke((Action)(() =>
        //                {
        //                    if (ptb_otherCall != null && !ptb_otherCall.IsDisposed)
        //                    {
        //                        ptb_otherCall.Image = bitmap;
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Error other cam");
        //                    }
        //                }));
        //            }
        //            else if (bytesReceived == 0)
        //            {
        //                this.Invoke(new Action(() => ptb_otherCall.Image = LoadImageFromImgFolder("wait-removebg-preview.png")));

        //            }

        //        }
        //    }


        //}

        private async void StartCamAndReceiveServer()
        {
            if(!isCall)
            {
                ptb_controlCam.Image = null;
                ptb_otherCall.Image = null;
            }
            EndPoint localEndPoint = new IPEndPoint(isServer ? ipAddress : IPAddress.Parse(ipClientConnected), isServer ? portCamServer : portCamClient);
            listenerCam = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            listenerCam.Bind(localEndPoint);

            var token = cancellationTokenSource.Token;

            try
            {
                // Asynchronous Task: Chạy vòng lặp lắng nghe trong một tác vụ
                // không đồng bộ để không làm ảnh hưởng đến giao diện người dùng và dễ dàng dừng lại khi cần.
                await Task.Run(() =>
                {
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                            break;

                        byte[] buffer = new byte[1024 * 30];
                        EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                        try
                        {
                            int bytesReceived = listenerCam.ReceiveFrom(buffer, ref remoteEndPoint);

                            if (bytesReceived > 0 && isCall)
                            {
                                Bitmap bitmap = ByteArrayToBitmap(buffer);
                                this.Invoke((Action)(() =>
                                {
                                    if (ptb_otherCall != null && !ptb_otherCall.IsDisposed)
                                    {
                                        ptb_otherCall.Image = bitmap;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error other cam");
                                    }
                                }));
                            }
                            else if (bytesReceived == 0)
                            {
                                MessageBox.Show("True");
                                this.Invoke(new Action(() => ptb_otherCall.Image = LoadImageFromImgFolder("wait-removebg-preview.png")));
                            }
                        }
                        catch (SocketException ex)
                        {
                            // Handle socket exceptions (e.g., socket closed)
                            if (ex.SocketErrorCode == SocketError.Interrupted)
                            {
                                break; // Exit the loop if socket is closed
                            }
                        }
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                // Operation was cancelled
            }
            finally
            {
                if (listenerCam != null)
                {
                    listenerCam.Close();
                    listenerCam = null;
                }
            }

        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Bitmap dataFramePicServer = new Bitmap(bitmap, new Size(250, 200));
            Bitmap dataFramePicClient = new Bitmap(bitmap, new Size(750, 800));

            ptb_mainCall.Image = dataFramePicClient;
            byte[] byteArray = ConvertToJpeg(dataFramePicServer);
            sendDataVideo(byteArray);



        }

        private byte[] ConvertToJpeg(Bitmap frame)
        {
            using (var ms = new MemoryStream())
            {
                frame.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }




        private Bitmap ByteArrayToBitmap(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                // Handle the case where the byte array is empty
                return null; // Or return a default image or throw an exception
            }

            try
            {
                using (var ms = new System.IO.MemoryStream(byteArray))
                {
                    return new Bitmap(ms);
                }
            }
            catch (Exception ex)
            {
                // Handle the case where the byte array does not represent a valid image
                MessageBox.Show("Error converting byte array to Bitmap: " + ex.Message);
                return null; // Or return a default image or throw an exception
            }
        }

        private void UpdatePictureBox(Bitmap bitmap)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Bitmap>(UpdatePictureBox), bitmap);
            }
            else
            {
                // Cập nhật PictureBox
                ptb_otherCall.Image = bitmap;
            }
        }

        private void sendDataVideo(byte[] array)
        {

            if (isServer)
            {
                // Là server thì send tới ip, port client này
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipClientConnected), portCamClient);
                Socket cam_sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                cam_sender.SendTo(array, ipEndPoint);
                //if (array.Length == 0)
                //{
                //    cam_sender.Close();
                //}
            }
            else
            {
                // Là client thì send tới port server này
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, portCamServer);
                Socket cam_sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                cam_sender.SendTo(array, ipEndPoint);
                //if (array.Length == 0)
                //{
                //    cam_sender.Close();
                //}
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            if (defaultCamera != null && defaultCamera.IsRunning)
            {
                defaultCamera.SignalToStop();
            }

            base.OnClosed(e);
        }

        private void ptb_mainCall_Click(object sender, EventArgs e)
        {

        }

        private void ptb_controlCam_Click(object sender, EventArgs e)
        {
            if (defaultCamera != null && defaultCamera.IsRunning)
            {
                // Dừng camera hiện tại
                defaultCamera.SignalToStop();
                ptb_mainCall.Image = LoadImageFromImgFolder("wait-removebg-preview.png");
                ptb_mainCall.SizeMode = PictureBoxSizeMode.CenterImage;



                ptb_controlCam.Image = LoadImageFromImgFolder("Cam_dis.png");
                ptb_controlCam.SizeMode = PictureBoxSizeMode.Zoom;

                // Send bytes stop cam
                byte[] zeroBytes = new byte[0];
                sendDataVideo(zeroBytes);
                
                MessageBox.Show("Đã tắt camera", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Khởi tạo camera mới
                if (defaultCamera != null && defaultCamera.IsRunning)
                {
                    defaultCamera.SignalToStop();
                }
                defaultCamera = new VideoCaptureDevice(cameras[cb_optionCam.SelectedIndex].MonikerString);
                defaultCamera.NewFrame += Cam_NewFrame;
                defaultCamera.Start();


                ptb_controlCam.Image = LoadImageFromImgFolder("videocamera_77953.png");
                ptb_controlCam.SizeMode = PictureBoxSizeMode.Zoom;

                // Hiển thị thông báo
                MessageBox.Show("Camera đã được bật", "Bật cam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }
        private Bitmap LoadImageFromImgFolder(string img)
        {

            // Lấy thư mục hiện tại
            string currentDirectory = Directory.GetCurrentDirectory();

            // Tạo đối tượng DirectoryInfo cho thư mục hiện tại
            DirectoryInfo currentDirInfo = new DirectoryInfo(currentDirectory);
            while (currentDirInfo.Name != "FinalProject")
            {
                // Lấy thư mục cha
                currentDirInfo = currentDirInfo.Parent;

                // Nếu không còn thư mục cha nào nữa, thoát khỏi vòng lặp
                if (currentDirInfo == null)
                {
                    Console.WriteLine("Thư mục 'FinalProject' không tìm thấy.");
                    return null;
                }
            }

            // Build the path to the image file in the 'img' folder
            string imagePath = Path.Combine(currentDirInfo.ToString(), "img", img);


            // Check if the file exists
            if (File.Exists(imagePath))
            {
                try
                {
                    // Load the image and return it
                    return new Bitmap(imagePath);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during image loading
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                    return null;
                }
            }
            else
            {
                // Display a message if the image file is not found
                MessageBox.Show("Hình ảnh không tìm thấy.");
                return null;
            }
        }


        private void ptb_controlMic_Click(object sender, EventArgs e)
        {
            Task.Run(() => StartMicAndReceiveServer());
            if (!isMicrophoneOn)
            {
                waveIn = new WaveInEvent();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new WaveFormat(44100, 1);
                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.StartRecording();

                ptb_controlMic.Image = LoadImageFromImgFolder("microphone-2104091_640.png");
                ptb_controlMic.SizeMode = PictureBoxSizeMode.Zoom;

                MessageBox.Show("Mic đã được bật", "Bật mic", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                StopMicrophone();
            }
        }
        private void StopMicrophone()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
                isMicrophoneOn = false;
                MessageBox.Show("Mic đã được tắt", "Tắt mic", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            // Nếu bạn đang sử dụng một socket để gửi dữ liệu, hãy đóng nó ở đây
            if (audio_sender != null)
            {
                audio_sender.Close();
                audio_sender = null;
            }

            // Optional: Reset soundProvider nếu vẫn còn sử dụng
            if (soundProvider != null)
            {
                soundProvider = null;
            }

            ptb_controlMic.Image = LoadImageFromImgFolder("mic_muted.png");
            ptb_controlMic.SizeMode = PictureBoxSizeMode.CenterImage;
        }


        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (isServer)
            {
                SendAudioData(e.Buffer, IPAddress.Parse(ipClientConnected), portAudioClient);
            }
            else
            {
                SendAudioData(e.Buffer, ipAddress, portAudioServer);
            }

        }

        private void SendAudioData(byte[] data, IPAddress ip, int port)
        {
            audio_sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            audio_sender.SendTo(data, endPoint);
        }


        //private void StartMicAndReceiveServer()
        //{
        //    isMicrophoneOn = true;
        //    // Khởi tạo kết nối UDP
        //    EndPoint localEndPoint = new IPEndPoint(isServer ? ipAddress : IPAddress.Parse(ipClientConnected), isServer ? portAudioServer : portAudioClient);
        //    Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //    listener.Bind(localEndPoint);


        //    while (true)
        //    {
        //        byte[] buffer = new byte[1024 * 15];
        //        int bytesReceived = listener.ReceiveFrom(buffer, ref localEndPoint); // Receive data
        //        if (bytesReceived > 0)
        //        {
        //            WaveInEvent waveLoad = new WaveInEvent();
        //            waveLoad.WaveFormat = new WaveFormat(44100, 1);
        //            WaveOutEvent playback;

        //            if (soundProvider == null)
        //            {
        //                soundProvider = new BufferedWaveProvider(waveLoad.WaveFormat);
        //                playback = new WaveOutEvent();
        //                playback.Init(soundProvider);
        //                playback.Play();
        //            }

        //            // Add the received data to the BufferedWaveProvider for processing
        //            soundProvider.AddSamples(buffer, 0, bytesReceived);

        //            // Clear buffer
        //            Array.Clear(buffer, 0, buffer.Length);
        //        }
        //    }


        //}

        private async void StartMicAndReceiveServer()
        {
            isMicrophoneOn = true;
            EndPoint localEndPoint = new IPEndPoint(isServer ? ipAddress : IPAddress.Parse(ipClientConnected), isServer ? portAudioServer : portAudioClient);
            listenerAudio = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            listenerAudio.Bind(localEndPoint);

            var token = cancellationTokenSource.Token;

            try
            {
                await Task.Run(() =>
                {
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                            break;

                        byte[] buffer = new byte[1024 * 15];
                        EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                        try
                        {
                            int bytesReceived = listenerAudio.ReceiveFrom(buffer, ref remoteEndPoint);

                            if (bytesReceived > 0)
                            {
                                WaveInEvent waveLoad = new WaveInEvent
                                {
                                    WaveFormat = new WaveFormat(44100, 1)
                                };

                                WaveOutEvent playback;

                                if (soundProvider == null)
                                {
                                    soundProvider = new BufferedWaveProvider(waveLoad.WaveFormat);
                                    playback = new WaveOutEvent();
                                    playback.Init(soundProvider);
                                    playback.Play();
                                }

                                soundProvider.AddSamples(buffer, 0, bytesReceived);
                                Array.Clear(buffer, 0, buffer.Length);
                            }
                        }
                        catch (SocketException ex)
                        {
                            if (ex.SocketErrorCode == SocketError.Interrupted)
                            {
                                break;
                            }
                        }
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                // Operation was cancelled
            }
            finally
            {
                if (listenerAudio != null)
                {
                    listenerAudio.Close();
                    listenerAudio = null;
                }
            }
        }
        private void ptb_interurpt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                isCall = false;
                //checkListener = false;
                StopListening();
                this.Close();
            }
        }

        private void StopListening()
        {
            cancellationTokenSource.Cancel();

            if (listenerCam != null)
            {
                listenerCam.Close();
                listenerCam = null;
            }else if(listenerAudio != null)
            {
                listenerAudio.Close();
                listenerAudio = null;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void chọnCameraBạnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
