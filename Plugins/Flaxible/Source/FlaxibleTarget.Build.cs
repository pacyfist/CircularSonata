using Flax.Build;

public class FlaxibleTarget : GameProjectTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for game
        Modules.Add("Flaxible");
    }
}
