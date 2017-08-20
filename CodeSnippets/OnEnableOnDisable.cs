    private void OnEnable()
    {
        // Step 1.2: Register to skeleton events
        GesturesManager.Instance.RegisterToSkeleton();
    }

    private void OnDisable()
    {
        // Step 1.2: Unregister from skeleton events
        GesturesManager.Instance.UnregisterFromSkeleton();
    }