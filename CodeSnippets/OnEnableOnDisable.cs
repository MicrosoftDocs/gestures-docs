    private void OnEnable()
    {
        // Step 1.8: Register to skeleton events
        GesturesManager.Instance.RegisterToSkeleton();
    }

    private void OnDisable()
    {
        // Step 1.8: Unregister from skeleton events
        GesturesManager.Instance.UnregisterFromSkeleton();
    }