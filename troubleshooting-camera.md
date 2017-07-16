# Camera Troubleshooting

Gesture detection may work intermittently or stop completely when our [Gestures Service](getting-started-gestures-service.md) has a problem communicating with the [Intel® RealSense™ SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html). If such a problem occurs, the "Image" section of the Microsoft Gestures Service window will be blank, even when you place your hand inside the camera's field-of-view:

![Image section blank due to RealSense issue](Images\CaptureGesturesService_RealSenseIssue.PNG)

To overcome this problem, please make sure your system is set up correctly:

- The [Intel® RealSense™ SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html) must be plugged into an SS USB 3.0 port:

    ![RealSense USB Port](Images\RealSensePort.png)

    Note that in some computer brands, the SS USB 3.0 port is colored blue and the power USB 3.0 port is colored gray/black.

- You should see 3 "Intel® RealSense™ Camera SR300" devices appearing in the "Imaging devices" category of your Device Manager:

    ![Device Manager](Images\RealSenseDeviceManager.png)

    If your camera is connected and you don't see these 3 devices, please [re-install](#re-install-camera-driver) the [Intel® RealSense™ SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html) driver.

## Re-install camera driver

To fix an erroneous [Intel® RealSense™ SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html) driver installation, make sure your camera is plugged-in and follow these steps:

1. Uninstall any "Intel® RealSense™ Camera SR300" devices appearing in the "Imaging devices" category of your Device Manager. Check the "Delete the driver software for this device." checkbox before you click the "Uninstall" button:

    ![Uninstall RealSense devices](Images\RealSenseUninstallDevice.png)

    If you are suggested to restart your machine, choose to restart and proceed with the instructions.

1. When you no longer see any "Intel® RealSense™ Camera SR300" devices, click the "Action" menu and choose "Scan for hardware changes":

    ![Scan changes](Images\RealSenseScanChanges.png)

    Your camera will be detected by Windows Update and the latest driver will be downloaded and installed. Please be patient, as this process may take up to 5 minutes.

    To verify that a new driver is currently being downloaded and installed, inspect your Task Manager, looking for the "Intel® Software Setup Assistant" process:

    ![Task Manager Intel Setup](Images\RealSenseSetupTaskManager.png)

1. Once the driver is installed, restart your machine.