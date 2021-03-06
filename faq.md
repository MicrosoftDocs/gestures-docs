# Frequently Asked Questions

### **Does Project Prague SDK expose the vector data for the palm\finger positions and directions?**

The SDK provides both the high level abstraction of a [gesture](index.md#gesture) and also the raw skeleton we estimate on every frame. This skeleton is light-weight, namely, it exposes the palm & fingertip location and direction vectors (for the palm  - we also include an orientation vector to fix the full six degrees of freedom).

Depending on your needs, you could either use our simplistic high-level gesture specification language or weave in the use of the raw skeleton stream.

For an example of using the skeleton stream, refer to [our 3D camera code sample](https://github.com/Microsoft/Gestures-Samples/tree/master/Camera3D).

### **Will Project Prague be compatible with the Surface Pro devices capable of Hello (e.g. Surface Pro 4)?**

Unfortunately, no. The Surface Pro (or for that matter - any currently shipped Surface device we know of) has at best an active IR camera while Project Prague requires a depth camera.

Check out our overview page for [a list of the currently supported depth cameras](index.md#supported-depth-cameras).

### **Does Project Prague work with Leap Motion or Kinect v1?**

No, we currently do not support these sensors.

We will definitely consider adding support for any depth sensor that gains enough demand from our users and can produce depth images in an adequate quality for gesture detection.

Check out our overview page for [a list of the currently supported depth cameras](index.md#supported-depth-cameras).

### **I have Visual Studio 2017 and I would like to use it as the C# script editor for Unity, what do I need to do?**

You need to install [Visual Studio Tools for Unity](https://www.visualstudio.com/vs/unity-tools/):

1. Launch **Visual Studio Installer**. If you have Visual Studio 2017 installed, this application should be available in your start menu.

1. Choose **Modify**:

    ![Visual Studio Installer Modify](Images\UnityVisualStudioInstaller.png)

1. Scroll down to the **Mobile & Gaming** category and select the **Game development with Unity** component:

    ![Visual Studio Tools for Unity](Images\UnityVisualStudioToolsInstall.png)

    Click **Modify** to install the **Visual Studio Tools for Unity** component.

When the installation completes, verify that Unity can access Visual Studio as its script editor. In the Unity editor **Preferences**, browse to the **External Script Editor** drop-down list, and select **Visual Studio 2017**:

![Unity External Script Editor](Images\UnityExternalScriptEditor.png)

If **Visual Studio 2017** is not one of the options available in the **External Script Editor** drop-down list, select the **Browse...** option and paste "%programfiles(x86)%\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe" in the **File name** text box:

![Path to devenv.exe](Images\UnityPathToDevenv.png)

For further assistance with the installation, refer to the [Visual Studio Tools for Unity documentation](https://docs.microsoft.com/en-us/visualstudio/cross-platform/getting-started-with-visual-studio-tools-for-unity#install-visual-studio-tools-for-unity).