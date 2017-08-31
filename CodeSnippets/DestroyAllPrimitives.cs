    public void DestroyAllPrimitives()
    {
        var allPrimitives = FindObjectsOfType<Rigidbody>();

        foreach (var primitive in allPrimitives)
        {
            Destroy(primitive.gameObject);
        }
    }