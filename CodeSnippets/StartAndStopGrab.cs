    public void StartGrab()
    {
        // Step 3.3:   Start grab mode. 
        if (!_hoveredGameObject)
        {
            return;
        }

        _isGrabbing = true;
    }

    public void StopGrab()
    {
        // Step 3.3:   Stop grab mode.
        _isGrabbing = false;
    }