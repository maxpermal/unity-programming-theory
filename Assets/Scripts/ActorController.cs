using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    protected GameManager gameManager;
    public ActorType type;
    public GameObject bullet;

    protected ActorProfile profile;

    protected Rigidbody body;
    protected Vector3 direction;

    [SerializeField] protected float durationCooldown = 5f;
    [SerializeField] protected float cooldownShoot;
    [SerializeField] protected bool canShoot;


    // Start is called before the first frame update
    virtual protected void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        body = gameObject.GetComponent<Rigidbody>();
        profile = gameObject.GetComponent<ActorProfile>();
    }

    virtual protected void Start()
    {
        direction = Vector3.forward;
    }

    // Update is called once per frame
    virtual protected void Update()
    {

    }

    virtual protected void FixedUpdate()
    {
        if (profile.isDead) return;
        MovePlayer(direction);
    }

    virtual protected void MovePlayer(Vector3 moveDirection)
    {
        var vertical = moveDirection.z;
        var horizontal = moveDirection.x;
        body.MovePosition(body.position + vertical * Vector3.forward * profile.speed * Time.deltaTime + horizontal * Vector3.right * profile.speed * Time.deltaTime);
        LastDirection(horizontal, vertical);
    }

    private void LastDirection(float horizontal, float vertical)
    {
        var oldirection = direction;
        direction.x = Utils.Round(horizontal);
        direction.z = Utils.Round(vertical);
        if (direction.magnitude == 0f)
        {
            direction = oldirection;
        }
    }

    virtual protected void Shoot(Vector3 shootdirection)
    {
        if (canShoot)
        {
            gameManager.Shoot(gameObject, bullet, shootdirection);
            StartCoroutine(ShootCorountine());
        }

        IEnumerator ShootCorountine()
        {
            canShoot = false;
            cooldownShoot = durationCooldown;
            while (cooldownShoot >= 0)
            {
                cooldownShoot -= Time.deltaTime;
                yield return null;
            }
            canShoot = true;
        }
    }
}
