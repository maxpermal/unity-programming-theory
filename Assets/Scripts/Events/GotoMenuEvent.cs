using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class GotoMenuEvent : EventManager.GameEvent
{
    public GotoMenuEvent() => Name = "Goto menu event";

    // ABSTRACTION
    public override void Execute()
    {
        MainManager.Instance.QuitGame();
        MainManager.Instance.LoadAScene("MENU");
    }
}

public class GotoMenuEventDecorator
{
    GotoMenuEvent ev;
    public GotoMenuEventDecorator()
    {
        ev = new GotoMenuEvent();
        EventManager.Schedule(ev);
    }
}
