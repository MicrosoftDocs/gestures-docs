# Kinect v2 Troubleshooting

When facing difficulty getting Project Prague to work with Kinect v2, please follow the troubleshooting steps below.

## Step 1 - USB 3.0 Port

The Kinect for Windows v2 camera must be plugged in to an **SS USB 3.0** port:

![Kinect USB Port](Images\RealSensePort.png)

Please note that sometimes, the **SS USB 3.0** port is colored **blue** and the **power USB 3.0** port is colored **gray** or **black**.

## Step 2 - Kinect for Windows SDK 2.0

Verify that **Kinect for Windows SDK 2.0** is installed on your machine:

![Kienct SDK](Images\KinectSDK.PNG)

If you don't have it - download and install from [this page](https://www.microsoft.com/en-us/download/details.aspx?id=44561).

## Step 3 - Update Driver

In the **Device Manager**, locate the **WDF KinectSensor Interface 0** device, right-click it, select **Update driver** and then **Search automatically for updated driver software**:

![Kinect update driver](Images\KinectUpdateDriver.png)