    public void StartGrab()
    {
        // Start grab mode. 
        if (!_hoveredGameObject)
        {
            return;
        }

        _isGrabbing = true;
    }

    public void StopGrab()
    {
        // Stop grab mode.
        _isGrabbing = false;
    }