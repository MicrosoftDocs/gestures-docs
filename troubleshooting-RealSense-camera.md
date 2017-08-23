# RealSense™ Troubleshooting

> [!NOTE]
> This troubleshooting page applies to both the **SR300** and **F200** models of **Intel® RealSense™**. Any reference to **SR300** in the images below is interchangeable with **F200**.

The Intel® RealSense™ camera must be plugged in to an **SS USB 3.0** port:

![RealSense USB Port](Images\RealSensePort.png)

Note that sometimes, the SS USB 3.0 port is colored blue and the power USB 3.0 port is colored gray/black.

> [!TIP]
> On some machines, the RealSense™ camera can only be detected when connected through a USB 3.0 hub with an external power supply.

You should see **3 Intel® RealSense™ Camera devices** appearing in the **Imaging devices** category of your Device Manager:

![Device Manager](Images\RealSenseDeviceManager.png)

If your camera is connected and you don't see these 3 devices, please follow the instructions below to re-install the Intel® RealSense™ camera driver.

## Re-install camera driver

To fix an erroneous Intel® RealSense™ camera driver installation, make sure your camera is plugged-in and follow these steps:

1. **Uninstall all "Intel® RealSense™ Camera" devices** appearing in the **Imaging device** category of your Device Manager. Check the "Delete the driver software for this device." checkbox before you click the "Uninstall" button:

    ![Uninstall RealSense devices](Images\RealSenseUninstallDevice.png)

    If you are suggested to restart your machine, agree and proceed with the instructions.

1. When you no longer see any "Intel® RealSense™ Camera" devices, click the "Action" menu and choose "**Scan for hardware changes**":

    ![Scan changes](Images\RealSenseScanChanges.png)

    Your camera will be detected by Windows Update and the latest driver will be downloaded and installed. Please be patient, as this process **may take up to 5 minutes**.

    To verify that a new driver is currently being downloaded and installed, inspect your Task Manager, looking for the "Intel® Software Setup Assistant" processes:

    ![Task Manager Intel Setup](Images\RealSenseSetupTaskManager.png)

1. Once the driver is installed, restart your machine.

1. If, at this point, you still cannot see all 3 "Intel® RealSense™ Camera" devices, try installing the driver manually. **Download and run the** [Intel® RealSense™ Depth Camera Manager setup](https://downloadcenter.intel.com/download/25044/Intel-RealSense-Depth-Camera-Manager). Make sure to select the appropriate version for your model - either "intel_rs_dcm_**sr300**" or "intel_rs_dcm_**f200**".