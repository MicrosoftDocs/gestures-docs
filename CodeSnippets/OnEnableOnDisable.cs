    private void OnEnable()
    {
        // Register to skeleton events
        GesturesManager.Instance.RegisterToSkeleton();
    }

    private void OnDisable()
    {
        // Unregister from skeleton events
        GesturesManager.Instance.UnregisterFromSkeleton();
    }