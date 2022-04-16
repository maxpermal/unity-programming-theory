using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ActorProfile : MonoBehaviour
{
    public float speed;
    public float healthMax;
    public float health;
    public float attackBase;
    public float attack;
    public bool isDead;
    public UnityEngine.UI.Slider lifeSlider;
    public int scoreValue;

    void Start()
    {
        if(lifeSlider)
        {
            lifeSlider.maxValue = healthMax;
            lifeSlider.minValue = 0;
            lifeSlider.value = health;
        }
    }

    public void StartGame()
    {
        health = healthMax;
        attack = attackBase;
        isDead = false;
        Start();
    }

    public void ModifyHealth(float amount)
    {
        health += amount;
        lifeSlider.value += amount;
        if (health <= 0)
        {
            isDead = true;
        }
    }

    public void Hit(ActorProfile other)
    {
        other.ModifyHealth(-attack);
    }
}


public enum ActorType
{
    Player,
    EnemyHulk,
    EnemySmall,
}
