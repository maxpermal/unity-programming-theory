using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class VictoryEvent : EventManager.GameEvent
{
    public VictoryEvent() => Name = "Victory event";

    // ABSTRACTION
    public override void Execute()
    {
        MainManager.Instance.SpawnMng.QuitGame();

        GameObject victory = GameObject.Find("UICanvas");
        victory.GetComponent<ActiveDialogBox>().SetActive("victory", true);
    }
}

public class VictoryEventDecorator
{
    VictoryEvent ev;
    public VictoryEventDecorator()
    {
        ev = new VictoryEvent();
        EventManager.Schedule(ev);
    }
}
