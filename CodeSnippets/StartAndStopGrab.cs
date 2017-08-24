    public void StartGrab()
    {
        // Start grab mode. 
        if (!_hoveredGameObject)
        {
            return;
        }

        _isGrabbing = true;
        _lastObjectDistance = Vector3.Distance(Camera.main.transform.position, _hoveredGameObject.transform.position);
    }

    public void StopGrab()
    {
        // Stop grab mode.
        _isGrabbing = false;
    }