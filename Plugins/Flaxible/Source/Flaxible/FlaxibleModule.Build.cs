using Flax.Build;
using Flax.Build.NativeCpp;

public class Flaxible : GameModule
{
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        BuildNativeCode = false;
    }
}
