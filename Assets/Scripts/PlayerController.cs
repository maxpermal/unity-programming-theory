using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public ActorType type;
    public GameObject bullet;

    ActorProfile profile;

    private Rigidbody body;
    private Vector3 direction;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        body = GetComponent<Rigidbody>();
        profile = gameObject.GetComponent<ActorProfile>();
    }

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.forward;
    }

    public void StartGame()
    {
        body.velocity = Vector3.zero;
        profile.StartGame();
    }

    private Vector3 PlayerPos;
    // Update is called once per frame
    void Update()
    {
        if (profile.isDead) return;
        Shoot();
    }

    void FixedUpdate()
    {
        if (profile.isDead) return;
        PlayerPos = transform.position;
        MovePlayer();
    }

    private void MovePlayer()
    {
        // var dt = Time.deltaTime;
        // var v0 = 0;
        // var F = 0;
        // var m = 1;
        // var x0 = 0;
        // var v = v0 + F/m * dt;
        // var x = x0 + v * dt;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
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

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gameManager.Shoot(gameObject, bullet, new Vector3(direction.x, 0, direction.z));
        }
    }
}
