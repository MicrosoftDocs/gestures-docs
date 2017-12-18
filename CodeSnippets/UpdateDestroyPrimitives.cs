    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateRandomPrimitive();
        }
        if (Input.GetMouseButtonDown(1))
        {
            DestroyAllPrimitives();
        }
    }