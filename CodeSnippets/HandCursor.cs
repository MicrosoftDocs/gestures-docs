using UnityEngine;
using Microsoft.Gestures.UnitySdk;
using Microsoft.Gestures.Toolkit;

public class HandCursor : MonoBehaviour
{
    [Tooltip("When true, cursor will track the mouse position. When false, cursor will track the palm position.")]
    public bool IsMouseMode = true;

    [Tooltip("The cursor image that will be displayed on the screen.")]
    public Texture2D CursorImage;

    [Tooltip("The size in pixels of the cursor icon.")]
    public Vector2 CursorSize = 24 * Vector2.one;

    [Tooltip("The color of the cursor in normal mode.")]
    public Color CursorTint = Color.red;

    private Vector3 GetPalmCameraPosition()
    {
        // Step 1.9: Convert palm position from depth-camera space to Main-Camera space
        return Vector3.zero;
    }

    private Vector3 GetCursorScreenPosition()
    {
        // Step 1.5: Return mouse screen position.

        // Step 1.9: Replace mouse position with palm position.

        return Vector3.zero;
    }

    private GameObject GetHoverObject()
    {
        // Step 2. Raycast a ray from camera to object under cursor.

        return null;
    }

    private void StartGrab()
    {
        // Step 3.   Begin grab mode. 
        //           Setup initial values needed for translation manipulation.
    }

    private void StopGrab()
    {
        // Step 3.   Stop grab mode.
    }

    private void OnEnable()
    {
        // Step 1.8: Register to skeleton events
    }

    private void OnDisable()
    {
        // Step 1.8: Unregister from skeleton events
    }

    private void Update()
    {
        // Step 2. Add highlighted material to hovered object

        // Step 3. Handle Grabbing
    }

    private void OnGUI()
    {
        // Step 1.5: Draw cursor texture at the cursor's position on the screen.

        // Step 3. Change cursor color when grab mode is on.
    }
}