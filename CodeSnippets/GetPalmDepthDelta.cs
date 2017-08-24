    private float GetCursorDistanceCoefficient()
    {
        var currentPalmDistance = GetPalmCameraPosition().magnitude;
        var coefficient = currentPalmDistance / _lastPalmDistance;
        _lastPalmDistance = currentPalmDistance;

        return coefficient;
    }