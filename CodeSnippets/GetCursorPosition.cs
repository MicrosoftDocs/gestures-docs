    private Vector3 GetCursorScreenPosition()
    {
        if (IsMouseMode)
        {
            // Step 1.5: Return mouse screen position.
            return Input.mousePosition;
        }
        
        // Step 1.9: Replace mouse position with palm position.
        return Vector3.zero;
    }