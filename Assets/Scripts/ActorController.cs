using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public GameObject bullet;

    protected GameManager gameManager;
    [SerializeField] protected ActorType type;
    public ActorType Type => type;

    protected ActorProfile profile;
    protected ActorInput inputs;

    protected Rigidbody body;
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected Vector3 storeDirection;
    [SerializeField] protected bool shootInput;

    public bool ShootInput => shootInput;
    public Vector3 Direction => direction;

    [SerializeField] protected float durationCooldown = 5f;
    [SerializeField] protected float cooldownShoot;
    [SerializeField] protected bool isShooting;


    virtual protected void Start()
    {
        gameManager = MainManager.Instance.gameManager;
        body = gameObject.GetComponent<Rigidbody>();
        profile = gameObject.GetComponent<ActorProfile>();
        inputs = new ActorInput();

        direction = Vector3.forward;
        storeDirection = Vector3.zero;
        isShooting = false;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if(inputs.attack)
        {
            Shoot(storeDirection);
        }
    }

    virtual protected void FixedUpdate()
    {
        MovePlayer(inputs.vertical, inputs.horizontal);
    }

    virtual protected void MovePlayer(float vertical, float horizontal)
    {
        vertical = Utils.Round(vertical);
        horizontal = Utils.Round(horizontal);
        body.MovePosition(body.position + vertical * Vector3.forward * profile.speed * Time.deltaTime + horizontal * Vector3.right * profile.speed * Time.deltaTime);
        LastDirection(horizontal, vertical);
    }

    private void LastDirection(float horizontal, float vertical)
    {
        direction.x = horizontal;
        direction.z = vertical;
        if (direction.magnitude > 0)
        {
            storeDirection = direction;
        }
    }

    virtual protected void Shoot(Vector3 shootdir)
    {
        if (isShooting == false)
        {
            gameManager.Shoot(gameObject, bullet, shootdir);
            StartCoroutine(ShootCorountine());
        }

        IEnumerator ShootCorountine()
        {
            isShooting = true;
            cooldownShoot = durationCooldown;
            while (cooldownShoot >= 0)
            {
                cooldownShoot -= Time.deltaTime;
                yield return null;
            }
            isShooting = false;
        }
    }
}


public struct ActorInput
{
    public float vertical;
    public float horizontal;
    public bool attack;
}