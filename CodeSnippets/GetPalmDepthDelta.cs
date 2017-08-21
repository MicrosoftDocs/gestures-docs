    private float GetCursorDepthDelta()
    {
        // Step 3.1: Compute palm depth delta
        var currentDepth = GetPalmCameraPosition().z;
        var delta = currentDepth - _lastPalmDepth;
        _lastPalmDepth = currentDepth;

        return delta / 10;
    }