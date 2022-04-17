using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class GameMenuEvent : EventManager.GameEvent
{
    internal bool state;
    public GameMenuEvent() => Name = "open/close menu event";

    // ABSTRACTION
    public override void Execute()
    {
        GameObject gameover = GameObject.Find("UICanvas");
        gameover.GetComponent<ActiveDialogBox>().SetActive("options", state);
    }
}

public class OpenGameMenuEventDecorate
{
    GameMenuEvent ev;
    public OpenGameMenuEventDecorate()
    {
        ev = new GameMenuEvent();
        ev.state = true;
        EventManager.Schedule(ev);
    }
}

public class CloseGameMenuEventDecorate
{
    GameMenuEvent ev;
    public CloseGameMenuEventDecorate()
    {
        ev = new GameMenuEvent();
        ev.state = false;
        EventManager.Schedule(ev);
    }
}