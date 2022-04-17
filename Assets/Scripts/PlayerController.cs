using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PlayerController : ActorController
{
    public void StartGame()
    {
        body.velocity = Vector3.zero;
        profile.StartGame();
    }
    
    // POLYMORPHISM
    protected override void UpdateInputs()
    {
        inputs.vertical = Input.GetAxis("Vertical");
        inputs.horizontal = Input.GetAxis("Horizontal");
        inputs.attack = Input.GetKeyDown(KeyCode.LeftControl);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            new OpenGameMenuEventDecorate();
        }
    }
}
