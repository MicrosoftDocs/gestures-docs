    public void StartGrab()
    {
        // Step 3.3:   Begin grab mode. 
        if (!_hoveredGameObject)
        {
            return;
        }

        _isGrabbing = true;
        // step 5.1: save last value of hand depth
    }

    public void StopGrab()
    {
        // Step 3.3:   Stop grab mode.
        _isGrabbing = false;
    }