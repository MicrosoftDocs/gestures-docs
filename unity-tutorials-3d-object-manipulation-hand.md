# 3D Object Manipulation

This tutorial will introduce you to using gesture and skeleton input to enrich the user interface of the games and applications you make with Unity. We will create a 3D cursor that is controlled by hand gestures. We will use this cursor to select objects in the scene and move them in 3D space.

This tutorial will take approximately 30 minutes to complete.

## Download the Final Result

The final Unity project obtained in this tutorial can be found in our open-source samples repository on [GitHub](https://github.com/Microsoft/Gestures-Samples). After you clone the repository, follow these steps to run the application:

1. Launch Unity, in the **Projects** tab select **Open**.
1. Browse to the [**Unity\Tutorials\3D Object Manipulation**](https://github.com/Microsoft/Gestures-Samples/tree/master/Unity/3D%20Object%20Manipulation) directory within the cloned repository.
1. Press the play button (or **Ctrl+P**) to run the scene.

## Prerequisites

This tutorial assumes you have basic familiarity with the C# programming language and some experience with the Unity environment. We assume you know how to create Unity projects, scenes, game objects and scripts.

We recommend you complete the [**Introduction**](unity-tutorials-introduction.md) tutorial before starting this tutorial, we assume you are familiar with the [**Project Prague toolkit for Unity**](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage) prefabs discussed there.

## Step 1 - Scene Preparation

1. We start this tutorial with the scene obtained in the [**3D Object Manipulation - Scene Preparation**](unity-tutorials-3d-object-manipulation-mouse.md) tutorial. This scene contains a mouse-controlled cursor that allows you to hover over objects, "grab" them and move them to a new location in space. In our current tutorial, we will replace the mouse for gestures and motions, and use our hand to control the cursor instead.

    Please either complete the [**3D Object Manipulation - Scene Preparation**](unity-tutorials-3d-object-manipulation-mouse.md) tutorial, or follow [these instructions](unity-tutorials-3d-object-manipulation-mouse.md#download-the-final-result) to obtain its final product. Note that the [**3D Object Manipulation - Scene Preparation**](unity-tutorials-3d-object-manipulation-mouse.md) tutorial does not cover any material related to the [**Project Prague toolkit for Unity**](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage) and you should feel free to skip it.

1. In Unity, load the final project created in the [**3D Object Manipulation - Scene Preparation**](unity-tutorials-3d-object-manipulation-mouse.md) tutorial. Play the **3D Object Manipulation** scene. Make sure you can grab and move objects using the mouse:

    ![Grabbing and moving instructions](Images\Unity3dCursorMouseInstructions.png)

    On [step 3](#step-3---grab-and-move-object-using-gestures) we will learn how to do drag an object (**number 2** in the figure above) using the hand, and on [step 4](#step-4---move-object-away-or-towards-camera) we will learn to move an object away and towards the camera (**number 3** in the figure above) using the hand.

## Step 2 - Hand Cursor

1. Add the **GesturesManager** and **UIManager** prefabs to the scene (from **MicrosoftGesturesToolkit\Prefabs**). We will use these prefabs to communicate with the [**Gestures Service**](getting-started-gestures-service.md). Refer to [step 2 of the introduction tutorial](unity-tutorials-introduction.md#step-2---connecting-to-the-gestures-service) for more details.

1. In order to control the cursor with your hand, we first need to obtain access to the hand-skeleton information. The [**Gestures Service**](getting-started-gestures-service.md) computes a hand-skeleton and communicates it to all subscribing clients on a frame-by-frame basis. The **GesturesManager** game object in our scene acts as a client of the **Gestures Service**. **GesturesManager**'s **RegisterToSkeleton()** and **UnregisterFromSkeleton()** methods allow us to subscribe and unsubscribe to the hand-skeleton stream.

    We would like to receive hand-skeleton information whenever the **Cursor** game object is active. Please add the following implementation for the [**OnEnable()**](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html) and [**OnDisable()**](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html) methods to the **Cursor** script:

    [!code-csharp[OnEnableOnDisable](CodeSnippets\OnEnableOnDisable.cs)]

1. We will now extract the palm position which is arriving from the **Gestures Service**, bundled with other skeleton information. We will use the palm position to compute the **Cursor** location on screen.

    The hand-skeleton is provided in units of millimeters, in the following left-handed coordinate system:

    ![Hand skeleton coordinate system](Images\UnityHandSkeletonCoordinates.png)
    *We used a RealSense™ camera here to demonstrate the coordinate system axes. Note that the same coordinate system applies to all [depth-cameras](index.md#supported-depth-cameras) supported by Project Prague.*

    Ideally, we would like the **Main Camera** in our scene to see your hand from the perspective of your eyes. If we can achieve this - the 3D cursor's projection to the screen will follow your hand in a way that feels natural.

    In an attempt to approximate the desired perspective, we will use the below coefficients to map the hand-skeleton (which is given in the depth-camera's view-space) to the 3D cursor (that we want to express in the **Main Camera**'s view-space). Add these public members to **Cursor.cs**:

    [!code-csharp[ScaleAndOffset](CodeSnippets\ScaleAndOffset.cs)]

    Note that this mapping also performs a scale-down by a factor of 10, which in fact is a unit conversion from millimeters to centimeters. We do this because we want the dynamic range of the cursor position to be appropriate for the size of objects in our scene - on the order of magnitude of 1-10 Unity units.

    With this preparation, we are ready to compute the actual conversion of the palm position to a cursor position. Add the **GetPalmCameraPosition()** method to the **Cursor** script:

    [!code-csharp[GetCursorScreenPosition](CodeSnippets\GetPalmCameraPosition.cs)]

    Note the use of the **SmoothDefaultSkeleton** property in **GetPalmCameraPosition()**. This property provides a smoothed version of the hand skeleton currently seen by the depth-camera. The smoothing is achieved by an averaging of the skeletons received over the last several frames. You can control the number of frames used for averaging - examine the **GesturesManager** in the **Inspector** window and modify the **Smooth Moving Average Window Size** field.

    Note that the **PalmPosition** property of the **skeleton** corresponds to the location of the center of the hand:

    ![Palm position landmark](Images\UnityPalmPosition.png)

1. replace the **GetCursorScreenPosition()** with the following contents:

    [!code-csharp[GetPalmCameraPosition](CodeSnippets\GetCursorScreenPosition.cs)]

1. Make sure you have the **Gestures Service** running. Play the scene and bring either hand in front of the depth-camera. You should be able to control the cursor by moving your hand.

## Step 3 - Grab and Move Object Using Gestures

We will now introduce a gesture and use it to trigger the cursor to enter and leave "grab mode". When in grab mode, the grabbed object follows the cursor (which follows your hand), allowing you to move it to a new location.

1. In the **Project** window, locate the **GestureTrigger** prefab under **MicrosoftGesturesToolkit\Prefabs**. Drag and drop it to the **Hierarchy** window to create a new **GestureTrigger** game object in your scene.

1. Examine the **GestureTrigger** game object in the **Inspector** window, select the **XAML Gesture** radio button, expand the **Gesture XAML** section and paste in the following gesture definition:

    ```xml
    <Gesture Name="GrabReleaseGesture"
             xmlns="http://schemas.microsoft.com/gestures/2015/xaml">
        <Gesture.Segments>
            <IdleGestureSegment Name="Idle" />
            <HandPose Name="InitSpreadPose">
                <PalmPose Context="{AnyHand}" Direction="Forward|Down" />
                <FingerPose Context="Index, Middle, Ring, Pinky" Flexion="Open" />
            </HandPose>
            <HandPose Name="GrabPose">
                <PalmPose Context="{AnyHand}" />
                <FingerPose Context="Index, Middle, Ring, Pinky" Flexion="Folded" />
            </HandPose>
            <HandPose Name="FinalSpreadPose">
                <PalmPose Context="{AnyHand}" />
                <FingerPose Context="Index, Middle, Ring, Pinky" Flexion="Open" />
            </HandPose>
        </Gesture.Segments>
        <Gesture.SegmentsConnections>
            <SegmentConnections From="Idle" To="Idle, InitSpreadPose" />
            <SegmentConnections From="InitSpreadPose" To="GrabPose" />
            <SegmentConnections From="GrabPose" To="FinalSpreadPose" />
            <SegmentConnections From="FinalSpreadPose" To="Idle" />
        </Gesture.SegmentsConnections>
    </Gesture>
    ```

    When done, the **GestureTrigger** **Inspector** view should look like this:

    ![GrabReleaseGesture gesture definition](Images\UnityGrabReleaseGesture.png)

    > [!TIP]
    > To generate a XAML representation of a gesture, create a [C# gesture object](https://docs.microsoft.com/en-us/dotnet/api/microsoft.gestures.gesture) and call its [ToXaml()](https://docs.microsoft.com/en-us/dotnet/api/microsoft.gestures.xamlizable.toxaml#Microsoft_Gestures_Xamlizable_ToXaml) method. Visit [our overview page](index.md#creating-gestures-in-project-prague) to read about creating gestures in C#.

    The **GrabReleaseGesture** is made up of 3 poses as illustrated in the state-machine below:

    ![GrabReleaseGesture](Images\UnityGrabReleaseGestureStateMachine.png)

    To learn more about the concept of a gesture as a state machine, please visit our [overview page](index.md#gesture).

1. We would like to use the **GrabReleaseGesture** in the following manner

    - **GrabPose** detection will cause the cursor to enter grab mode, i.e., it should trigger **StartGrab()**.
    - **Idle** detection will cause the cursor to leave grab mode, i.e., it should trigger **StopGrab()**.

    > [!NOTE]
    > The [**Idle** state](https://docs.microsoft.com/en-us/dotnet/api/microsoft.gestures.gesture.idlegesturesegment#Microsoft_Gestures_Gesture_IdleGestureSegment) is the initial state in every gesture. Whenever the user either performs a gesture to completion or abandons a gesture in the middle of its execution, the state-machine falls back to the **idle** state.

    Examine the **GestureTrigger** game object in the **Inspector** window and press the **Add Gesture Segment Event Button** *twice*. This should generate two new UI (user interface) sections, **Segment #1** and **Segment #2**.

        - In the **Segment #1** drop down list, select the **GrabPose** (1), then click the **+** sign in the **On Trigger ()** pane (2). Drag the **Cursor** object to the **None (Object)** box (3) and select the **Cursor → StartGrab()** method from the **No Function** drop-down list (4):

        ![GrabPose gesture trigger](Images\UnityGrabGestureTrigger.png)

        - In the **Segment #2** drop down list, select the **Idle** (1), then click the **+** sign in the **On Trigger ()** pane (2). Drag the **Cursor** object to the **None (Object)** box (3) and select the **Cursor → StopGrab()** method from the **No Function** drop-down list (4):

        ![Idle gesture trigger](Images\UnityIdleGestureTrigger.png)

1. Run the scene. Test the feature we've added on this step:

    - Hover over an object with the cursor,
    - Grab it by clinching your hand into a fist,
    - Move the object to a new location,
    - Release the object by spreading your fingers apart.

## Step 4 - Move Object Away or Towards Camera

On this step, we will enable the grabbed object to move in the radial direction as well.

1. Add the following private member to **Cursor.cs**:

    [!code-csharp[LastPalmDepth member](CodeSnippets\LastPalmDepth.cs)]

    This member needs to be initialized every time an object is grabbed. To do that, add the following line at the end of the **StartGrab()** method:

    [!code-csharp[LastPalmDepth member](CodeSnippets\InitializeLastPalmDepth.cs)]

1. Replace the contents of the **GetCursorDistanceCoefficient()** method in **Cursor.cs** with the following:

    [!code-csharp[GetCursorDepthDelta() method](CodeSnippets\GetPalmDepthDelta.cs)]

1. Try running the scene. Grab an object and move your hand towards or away from the depth-camera. The object in the scene should follow your hand, moving respectively in the virtual scene.

    > [!TIP]
    > Don't hold your hand too close to the depth-camera. The camera has a [frustum](https://en.wikipedia.org/wiki/Viewing_frustum) shaped field-of-view - as you bring your hand closer, the detectible area becomes smaller, leaving you with less range of motion to manipulate objects in the scene.