using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class EnemyController : MonoBehaviour
{
    GameManager gameManager;
    public ActorType type;
    public GameObject bullet;

    ActorProfile profile;

    Rigidbody rbEnemy;
    
    [SerializeField] float durationCooldown = 5f;
    [SerializeField] float cooldownShoot;
    [SerializeField] bool canShoot;

    ObjectCollision mcollision;
    public float distMinDetection;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rbEnemy = gameObject.GetComponent<Rigidbody>();
        mcollision = gameObject.GetComponent<ObjectCollision>();
        profile = gameObject.GetComponent<ActorProfile>();
        cooldownShoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(profile.isDead)
        {
            return;
        }
        Vector3 direction = (gameManager.player.transform.position - transform.position).normalized;
        var isRay = Physics.Raycast(rbEnemy.position, rbEnemy.transform.TransformDirection(direction), distMinDetection);
        if (isRay == false)
        {
            rbEnemy.MovePosition(rbEnemy.position + direction * profile.speed * Time.deltaTime);
        }

        Shoot(direction);
    }

    void Shoot(Vector3 direction)
    {
        if (canShoot)
        {
            cooldownShoot -= Time.deltaTime;
            if (cooldownShoot <= 0)
            {
                cooldownShoot = durationCooldown;
                gameManager.Shoot(gameObject, bullet, direction);
            }
        }
    }

    public void RemoveEnemy()
    {
        gameManager.GetComponent<SpawnManager>().RemoveEnemy(gameObject);
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
