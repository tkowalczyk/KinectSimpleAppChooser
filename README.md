#KinectSimpleAppChooser#


This simple application shows how to properly use [Kinect for Windows SDK](http://www.microsoft.com/en-us/kinectforwindows/ "Kinect for Windows SDK") in the WPF with Kinect Sensor Chooser (from MSFT).

Kinect Sensor Chooser helps programmers to detect state of the connected sensor. If Kinect device is not connected then Kinect Sensor Chooser will send notification to application that Kinect is not connected.

**How does it work?**

Similar to the [KinectSimpleApp](https://github.com/tkowalczyk/KinectSimpleApp "KinectSimpleApp") example. First of all we have to declare in our XAML namespace where Kinect Sensor Chooser is:

`xmlns:my="clr-namespace:KinectSimpleAppChooser"`

Then invoked it:

`<my:KinectSensorChooser x:Name="kscReportKinectState"/>`

Next thing to do is implement Window Loaded event method and place there this code (in code-behind file):

`kscReportKinectState.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kscReportKinectState_KinectSensorChanged);`

It is just a simple handler which check the state of the sensor and send notification. Next we have to implement method we've declared `kscReportKinectState_KinectSensorChanged` it which we are able to check if connected sensor is old (Kinect from Xbox 360) or new (Kinect for Windows) and then call some special actions.

Then we check sensor state with some help from try/catch block:

`try
            {
                sensor.Start();
            }
            catch (System.IO.IOException)
            {
                kscReportKinectState.AppConflictOccurred();
            }
`

And that's all. To test this component try to run this code connect device and disconnect during the application is running and see for the effect.

**More examples**

Feel free to visit my homepage [Tomasz Kowalczyk](http://tomek.kownet.info/ "Tomasz Kowalczyk") to see more complex examples.