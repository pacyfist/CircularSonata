using FlaxEngine;
using System.Threading;
using System.Threading.Tasks;

namespace Flaxible;

public class MediatedScript : Script
{
    protected CancellationTokenSource cancellationTokenSource = new();

    protected Mediator mediator = Mediator.Global;

    public virtual Task OnAwakeAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnAwake()
        => OnAwakeAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnEnableAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnEnable()
        => OnEnableAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnDisableAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnDisable()
        => OnDisableAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnStartAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnStart()
        => OnStartAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnUpdateAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnUpdate()
        => OnUpdateAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnLateUpdateAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnLateUpdate()
        => OnLateUpdateAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnFixedUpdateAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnFixedUpdate()
        => OnFixedUpdateAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnLateFixedUpdateAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnLateFixedUpdate()
        => OnLateFixedUpdateAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnDebugDrawAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnDebugDraw()
        => OnDebugDrawAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnDebugDrawSelectedAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public override void OnDebugDrawSelected()
        => OnDebugDrawSelectedAsync(cancellationTokenSource.Token).Wait();


    public virtual Task OnDestroyAsync(CancellationToken cancellationToken)
         => Task.CompletedTask;

    public override void OnDestroy()
    {
        OnDestroyAsync(cancellationTokenSource.Token).Wait();
        cancellationTokenSource.Cancel();
    }
}
