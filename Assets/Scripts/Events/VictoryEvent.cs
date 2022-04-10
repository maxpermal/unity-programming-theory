using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class VictoryEvent : EventManager.GameEvent
{
    public VictoryEvent() => Name = "Victory event";

    public override void Execute()
    {   
        SpawnManager spawnManager = GameManager.instance.GetComponent<SpawnManager>();
        spawnManager.isEnable = false;

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
