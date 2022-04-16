using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class RestartGameEvent : EventManager.GameEvent
{
    public GameObject gameobject;

    public RestartGameEvent() => Name = "Restart game event";

    // ABSTRACTION
    public override void Execute()
    {
        MainManager.Instance.QuitGame();
        MainManager.Instance.StartGame();
    }
}

public class RestartGameEventDecorator
{
    RestartGameEvent ev;
    public RestartGameEventDecorator()
    {
        ev = new RestartGameEvent();
        EventManager.Schedule(ev);
    }
}
