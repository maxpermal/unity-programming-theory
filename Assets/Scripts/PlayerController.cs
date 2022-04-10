using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ActorController
{
    public void StartGame()
    {
        body.velocity = Vector3.zero;
        profile.StartGame();
        canShoot = true;
    }

    override protected void Update()
    {
        if (profile.isDead) return;
        inputs.vertical = Input.GetAxis("Vertical");
        inputs.horizontal = Input.GetAxis("Horizontal");
        inputs.attack = Input.GetKeyDown(KeyCode.LeftControl);
        base.Update();
    }

    override protected void FixedUpdate()
    {
        if (profile.isDead) return;
        base.FixedUpdate();
    }
}
