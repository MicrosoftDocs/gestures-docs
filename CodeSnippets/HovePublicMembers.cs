    [Tooltip("Material used to highlight hovered game objects.")]
    public Material HighlightMaterial;

    [Tooltip("A layer mask to filter hover-able game objects")]
    public LayerMask Mask = -1; // -1 corresponds to "mask all layers in the scene"