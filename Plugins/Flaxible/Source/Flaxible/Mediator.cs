using FlaxEngine;
using System;
using System.Collections.Generic;

namespace Flaxible;

public class Mediator
{
    public class Message { }

    private static Mediator _global = null;

    public static Mediator Global
    {
        get
        {
            if (_global == null)
            {
                _global = new Mediator();
            }
            return _global;
        }
    }

    public Mediator()
    {
        Debug.Log($"Mediator - Has Been Constructed");

        Scripting.FixedUpdate += OnFixedUpdate;
        Scripting.Exit += OnExit;

        if (Engine.IsEditor)
        {
           FlaxEditor.Editor.Instance.PlayModeEnd += OnExit;
        }
    }

    private void OnExit()
    {
        _subscribe = null;

        Scripting.FixedUpdate -= OnFixedUpdate;
        Scripting.Exit -= OnExit;

        if (Engine.IsEditor)
        {
           FlaxEditor.Editor.Instance.PlayModeEnd -= OnExit;
        }

        _global = null;
    }

    private event EventHandler<Message> _subscribe;

    private Queue<Message> messages = new();

    public void Publish<T>(T message) where T : Message
    {
        Debug.Log($"Mediator - New Message - {typeof(T).Name}");

        messages.Enqueue(message);
    }

    public void SubscribeTo<T>(Action<T> action) where T : Message
    {
        Debug.Log($"Mediator - New Subscription To - {typeof(T).Name}");

        _subscribe += (sender, message) =>
        {
            if (message is T)
            {
                action((T)message);
            }
        };
    }

    private void OnFixedUpdate()
    {
        foreach (var message in messages)
        {
            _subscribe?.Invoke(this, message);
        }

        messages.Clear();
    }
}
