using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class BulletController : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private float duration;
    public float Duration => duration;

    // ENCAPSULATION
    [SerializeField] float speed;
    public float Speed => speed;

    // ENCAPSULATION
    [SerializeField] GameObject shooter;
    public GameObject Shooter => shooter;

    public ParticleSystem explosionParticule;

    private Vector3 forwardDirection = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
        TransformationEditorAdaptator();
    }

    private void TransformationEditorAdaptator()
    {
        transform.Rotate(90f, 0f, 0f, Space.World);
        transform.Translate(Vector3.up * 0.5f, Space.World);
        forwardDirection = Vector3.up;
    }

    public void Shoot(GameObject shooter, float angle)
    {
        this.shooter = shooter;
        transform.Rotate(0, 0, angle * 180 / 3.1416f - 90f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            Destroy(gameObject);
            return;
        }

        var velocity = speed * forwardDirection;    
        transform.Translate(velocity* Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        var isPlayerHit = (shooter.tag == "Player" && other.gameObject.tag == "Enemy");
        var isEnemyHit = (shooter.tag == "Enemy" && other.gameObject.tag == "Player");
        if (isPlayerHit || isEnemyHit)
        {
            new DestroyBulletEventDecorator(gameObject);
            new EntityHitEventDecorator(shooter, other.gameObject);
        }
    }

    public void OnDestroy()
    {
        var particule = Instantiate(explosionParticule, transform.position, transform.rotation);
        particule.Play();
    }
}
