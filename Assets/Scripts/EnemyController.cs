using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class EnemyController : ActorController
{
    ObjectCollision mcollision;
    public float distMinDetection;
    [SerializeField] bool canShoot;

    // Start is called before the first frame update
    override protected void Start()
    {
        mcollision = gameObject.GetComponent<ObjectCollision>();
        cooldownShoot = 0;
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        if(profile.isDead)
        {
            return;
        }
        Vector3 direction = (gameManager.player.transform.position - transform.position).normalized;
        var isRay = Physics.Raycast(body.position, body.transform.TransformDirection(direction), distMinDetection);
        if (isRay == false)
        {
            inputs.vertical = direction.z;
            inputs.horizontal = direction.x;
        }
        inputs.attack = canShoot;

        base.Update();
    }

    override protected void FixedUpdate()
    {
        if (profile.isDead)
        {
            return;
        }
        base.FixedUpdate();
    }

    public void RemoveEnemy()
    {
        gameManager.RemoveEnemy(gameObject);
        gameManager.IncreaseScore(profile.scoreValue);
    }
}

public class EnemyHulk : EnemyController
{
    public EnemyHulk() => type = ActorType.EnemyHulk;
}

public class EnemySmall : EnemyController
{
    public EnemySmall() => type = ActorType.EnemySmall;
}
