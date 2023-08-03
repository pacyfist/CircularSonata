using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game;

public class Field : Script
{
    public Actor Collection { get; set; }

    private Actor[] spawners;

    /// <inheritdoc/>
    public override void OnStart()
    {
        spawners = Collection.Children;
    }

    /// <inheritdoc/>
    public override void OnEnable()
    {
        // Here you can add code that needs to be called when script is enabled (eg. register for events)
    }

    /// <inheritdoc/>
    public override void OnDisable()
    {
        // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
    }

    /// <inheritdoc/>
    public override void OnFixedUpdate()
    {
        Matrix.RotationY(0.005f, out var rot);

        Actor.Rotation *= rot;

        // foreach (var s in spawners)
        // {
        //     s.RotateAround(Vector3.Zero, Vector3.Up, 1f);
        // }
    }
}

