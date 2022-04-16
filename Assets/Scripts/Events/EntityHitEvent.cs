using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class EntityHitEvent : EventManager.GameEvent
{
    public GameObject entity;
    public GameObject other;

    public EntityHitEvent() => Name = "Entity hit event";

    // ABSTRACTION
    public override void Execute()
    {
        var entityProfile = entity.GetComponent<ActorProfile>();
        var otherProfile = other.GetComponent<ActorProfile>();
        entityProfile.Hit(otherProfile);
        Vector3 impact = other.transform.position - entity.transform.position;
        other.GetComponent<Rigidbody>().AddForce(impact.normalized * 100, ForceMode.Impulse);
        if (otherProfile.health <= 0)
        {
            if(other.tag == "Enemy")
            {
                other.GetComponent<EnemyController>().RemoveEnemy();
                GameObject.Destroy(other);
            }
            else if(other.tag == "Player")
            {
                new GameOverEventDecorate();
            }
        }
    }
}
public class EntityHitEventDecorator
{
    EntityHitEvent ev;
    public EntityHitEventDecorator(GameObject entity, GameObject other)
    {
        ev = new EntityHitEvent();
        ev.entity = entity;
        ev.other = other;
        EventManager.Schedule(ev);
    }
}