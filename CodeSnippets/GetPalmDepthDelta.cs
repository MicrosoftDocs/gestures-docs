    private float GetCursorDepthDelta()
    {
        // Compute palm depth delta
        var currentDepth = GetPalmCameraPosition().z;
        var delta = currentDepth - _lastPalmDepth;
        _lastPalmDepth = currentDepth;

        return delta / 10;
    }