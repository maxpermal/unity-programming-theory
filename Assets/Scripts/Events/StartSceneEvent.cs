using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class StartSceneEvent : EventManager.GameEvent
{
    public string scene;

    public StartSceneEvent() => Name = "Start game event";

    public override void Execute()
    {
        base.Execute();
        GameManager.instance.LoadAScene(scene);
    }
}

public class StartSceneEventDecorator
{
    internal StartSceneEvent ev;
    public StartSceneEventDecorator(string scene)
    {
        ev = new StartSceneEvent();
        ev.scene = scene;
        EventManager.Schedule(ev);
    }
}

public class StartScene1EventDecorator : StartSceneEventDecorator
{
    public StartScene1EventDecorator() : base("SCENE1")
    {
    }
}
