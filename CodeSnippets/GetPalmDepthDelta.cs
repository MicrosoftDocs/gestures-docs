    private float GetCursorDepthDelta()
    {
        // Step 3.1: return palm depth delta
        var currentDepth = GetPalmCameraPosition().z;
        delta = (currentDepth - _lastPalmDepth) / 10;
        _lastPalmDepth = currentDepth;
    }