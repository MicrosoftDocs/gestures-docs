    private float GetCursorDepthDelta()
    {
        // Step 3.2: return palm depth delta
        var currentDepth = GetPalmCameraPosition().z;
        delta = (currentDepth - _lastPalmDepth) / 10;
        _lastPalmDepth = currentDepth;
    }