using UnityEngine;
using Microsoft.Gestures.UnitySdk;
using Microsoft.Gestures.Toolkit;

public class MouseCursor : MonoBehaviour
{
    [Tooltip("The cursor image that will be displayed on the screen.")]
    public Texture2D CursorImage;

    [Tooltip("The size in pixels of the cursor icon.")]
    public Vector2 CursorSize = 24 * Vector2.one;

    [Tooltip("The color of the cursor in normal mode.")]
    public Color CursorTint = Color.red;

    private Vector3 GetCursorScreenPosition()
    {
        // Step 1: Return mouse screen position.

        return Vector3.zero;
    }

    private GameObject GetHoveredObject()
    {
        // Step 2: Raycast a ray from camera to object under cursor.

        return null;
    }

    private float GetCursorDepthDelta()
    {
        // Step 3: Compute the change in cursor depth with respect to previous frame

        return 0;
    }

    private void StartGrab()
    {
        // Step 3:   Begin grab mode. 
    }

    private void StopGrab()
    {
        // Step 3:   Stop grab mode.
    }

    private void Update()
    {
        // Step 2: Add highlighted material to hovered object

        // Step 3: Handle Grabbing

        // Step 3: scale depth according to cursor's depth delta
    }

    private void OnGUI()
    {
        // Step 1: Draw cursor texture at the cursor's position on the screen.

        // Step 3: Change cursor color when grab mode is on.
    }
}