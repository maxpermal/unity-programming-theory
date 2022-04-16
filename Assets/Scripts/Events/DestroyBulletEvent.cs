using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class DestroyBulletEvent : EventManager.GameEvent
{
    public GameObject bullet;

    public DestroyBulletEvent() => Name = "Destroy bullet event";

    // ABSTRACTION
    public override void Execute()
    {
        bullet.GetComponent<BulletController>().OnDestroy();
        GameObject.Destroy(bullet);
    }
}

public class DestroyBulletEventDecorator
{
    DestroyBulletEvent ev;
    public DestroyBulletEventDecorator(GameObject bullet)
    {
        ev = new DestroyBulletEvent();
        ev.bullet = bullet;
        EventManager.Schedule(ev);
    }
}