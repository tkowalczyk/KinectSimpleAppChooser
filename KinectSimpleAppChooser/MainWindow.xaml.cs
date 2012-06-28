using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;

namespace KinectSimpleAppChooser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kscReportKinectState.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kscReportKinectState_KinectSensorChanged);
        }

        void kscReportKinectState_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Choose sensor to use
            //KinectSensor sensor = (KinectSensor)e.OldValue;
            KinectSensor sensor = (KinectSensor)e.NewValue;           

            sensor.ColorStream.Enable();
            sensor.DepthStream.Enable();
            sensor.SkeletonStream.Enable();
            sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(_sensor_AllFramesReady);
            try
            {
                sensor.Start();
            }
            catch (System.IO.IOException)
            {
                kscReportKinectState.AppConflictOccurred();
            }
        }

        private void _sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {

        }
        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopKinect(kscReportKinectState.Kinect);
        }

        private void StopKinect(KinectSensor sensorToStop)
        {
            if (sensorToStop != null)
            {
                sensorToStop.Stop();
            }
        }
    }
}
