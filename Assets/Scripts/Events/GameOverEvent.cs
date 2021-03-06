using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class GameOverEvent : EventManager.GameEvent
{
    public GameOverEvent() => Name = "Gameover event";

    // ABSTRACTION
    public override void Execute()
    {
        GameObject gameover = GameObject.Find("UICanvas");
        gameover.GetComponent<ActiveDialogBox>().SetActive("gameover", true);
    }
}

public class GameOverEventDecorate
{
    GameOverEvent ev;
    public GameOverEventDecorate()
    {
        ev = new GameOverEvent();
        EventManager.Schedule(ev);
    }
}
