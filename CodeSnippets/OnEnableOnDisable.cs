    private void OnEnable()
    {
        // Step 1.b Register to skeleton events
        GesturesManager.Instance.RegisterToSkeleton();
    }

    private void OnDisable()
    {
        // Step 1.b Unregister from skeleton events
        GesturesManager.Instance.UnregisterFromSkeleton();
    }