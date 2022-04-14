using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class VictoryEvent : EventManager.GameEvent
{
    public VictoryEvent() => Name = "Victory event";

    public override void Execute()
    {   
        SpawnManager.Instance.isEnable = false;

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
