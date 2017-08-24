using UnityEngine;
using Microsoft.Gestures.UnitySdk;
using Microsoft.Gestures.Toolkit;

public class Cursor : MonoBehaviour
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
        // Step 2: Cast a ray from camera to object under cursor.
        return null;
    }

    private float GetCursorDistanceCoefficient()
    {
        // Step 3: Compute the ratio in cursor distance with respect to previous frame
        return 1;
    }

    private void StartGrab()
    {
        // Step 3: Begin grab mode. 
    }

    private void StopGrab()
    {
        // Step 3: Stop grab mode.
    }

    private void Update()
    {
        // Step 2: Add highlighting material to hovered object

        // Step 3: Handle Grabbing

        // Step 3: Scale distance according to cursor's distance coefficient
    }

    private void OnGUI()
    {
        // Step 1: Draw cursor texture at the cursor's position on the screen.

        // Step 3: Change cursor color when grab mode is on.
    }
}