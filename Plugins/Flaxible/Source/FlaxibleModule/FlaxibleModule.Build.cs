using Flax.Build;
using Flax.Build.NativeCpp;

public class FlaxibleModule : GameModule
{
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        BuildNativeCode = false;
    }
}
