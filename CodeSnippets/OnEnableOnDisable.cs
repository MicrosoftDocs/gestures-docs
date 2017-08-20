    private void OnEnable()
    {
        // Step 2.1: Register to skeleton events
        GesturesManager.Instance.RegisterToSkeleton();
    }

    private void OnDisable()
    {
        // Step 2.1: Unregister from skeleton events
        GesturesManager.Instance.UnregisterFromSkeleton();
    }