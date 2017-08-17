    private float GetCursorDepthDelta()
    {
        // Step 3.6: return mouse scroll delta
        return Input.mouseScrollDelta.y / 10;
    }