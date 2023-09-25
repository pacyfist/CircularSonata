using FlaxEngine;
using Flaxible;
using Game.Game.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Game;

public class RoundField : AsyncScript
{
    public Prefab SpawnerPrefab { get; set; }

    public Prefab BulletPrefab { get; set; }

    public Actor BulletContainer { get; set; }

    private List<Actor> _spawners = new List<Actor>();

    private double _angle = 0;

    private void SpawnSpawner()
    {
        var spawner = PrefabManager.SpawnPrefab(SpawnerPrefab, new Vector3(0, 0, 0));
        spawner.Parent = Actor;

        var bulletScript = spawner.AddScript<FireBullets>();
        bulletScript.BulletContainer = BulletContainer;
        bulletScript.BulletPrefab = BulletPrefab;

        var moveScript = spawner.AddScript<MoveToTarget>();

        moveScript.TargetRadius = 200;
        moveScript.CurrentRadius = 200;


        if (_spawners.Any())
        {
            var angle = _spawners.Last().GetScript<MoveToTarget>().TargetAngle;

            moveScript.TargetAngle = angle;
            moveScript.CurrentAngle = angle;
        }
        else
        {
            moveScript.TargetAngle = _angle;
            moveScript.CurrentAngle = _angle;
        }

        moveScript.UpdatePosition();

        _spawners.Add(spawner);
    }

    private void DropSpawner()
    {
        var spawner = _spawners.LastOrDefault();
        if (spawner != null)
        {
            _spawners.Remove(spawner);
            Destroy(spawner);
        }
    }

    public override Task OnStartAsync(CancellationToken cancellationToken)
    {
        Task.Run(async () =>
        {
            for (int i = 0; i < 5; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                Mediator.Global.Publish(new AddSpawner());

                await EngineTime.Delay(60, cancellationToken);
            }
        }, cancellationToken);


        Mediator.Global.SubscribeTo<AddSpawner>((message) =>
        {
            SpawnSpawner();
        });

        return Task.CompletedTask;
    }


    public override void OnFixedUpdate()
    {
        var divider = 2.0 * Math.PI / _spawners.Count;

        for (int i = 0; i < _spawners.Count; i++)
        {
            var moveScript = _spawners[i].Scripts
                .First(s => s is MoveToTarget) as MoveToTarget;

            var angle = _angle + (i * divider);

            moveScript.TargetRadius = 200;
            moveScript.TargetAngle = angle;
        }

        _angle += 0.01;
    }
}

