    private float GetCursorDepthDelta()
    {
        float delta;
        if (IsMouseMode)
        {
            // Step 5.1: return mouse scroll delta
            delta = Input.mouseScrollDelta.y / 10;
        }
        else
        {
            // Step 5.1: return palm depth delta
            var currentDepth = GetPalmCameraPosition().z;
            delta = (currentDepth - _lastPalmDepth) / 10;
            _lastPalmDepth = currentDepth;
        }

        return Mathf.Max(Mathf.Min(delta, 1), -1);
    }