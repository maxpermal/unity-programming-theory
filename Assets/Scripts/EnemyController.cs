using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

// INHERITANCE
public class EnemyController : ActorController
{
    ObjectCollision mcollision;
    public float distMinDetection;
    [SerializeField] bool canShoot;

    // POLYMORPHISM
    override protected void Start()
    {
        mcollision = gameObject.GetComponent<ObjectCollision>();
        cooldownShoot = 0;
        base.Start();
    }

    // POLYMORPHISM
    protected override void UpdateInputs()
    {
        Vector3 direction = (gameManager.Player.transform.position - transform.position).normalized;
        var isRay = Physics.Raycast(body.position, body.transform.TransformDirection(direction), distMinDetection);
        if (isRay == false)
        {
            inputs.vertical = direction.z;
            inputs.horizontal = direction.x;
        }
        inputs.attack = canShoot;
    }

    public void RemoveEnemy()
    {
        gameManager.RemoveEnemy(gameObject);
    }
}

// INHERITANCE
public class EnemyHulk : EnemyController
{
    public EnemyHulk() => type = ActorType.EnemyHulk;
}

// INHERITANCE
public class EnemySmall : EnemyController
{
    public EnemySmall() => type = ActorType.EnemySmall;
}
