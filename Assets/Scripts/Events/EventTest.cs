using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class EventTest : EventManager.GameEvent
{
    public GameObject gameobject;

    public EventTest() => Name = "Test event";

    public override void Execute()
    {
        base.Execute();
        Debug.Log("This is a test event");
    }

    internal override void Cleanup()
    {
        base.Cleanup();
        Debug.Log("Clean test event");
    }
}
