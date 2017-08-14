    public void StartGrab()
    {
        // Step 3.3:   Begin grab mode. 
        //             Setup initial values needed for translation manipulation 
        //             that occur on the Update method.
        if (!_hoveredGameObject)
        {
            return;
        }

        _isGrabbing = true;
        _lastPalmDepth = GetPalmCameraPosition().z;
    }

    public void StopGrab()
    {
        // Step 3.3:   Stop grab mode.
        _isGrabbing = false;
    }