using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public bool isCollide = false;

    void OnCollisionEnter(Collision other)
    {
        ObjectCollision obj = other.gameObject.GetComponent<ObjectCollision>();
        if (obj )
        {
            if (gameObject.tag == "Enemy" && other.gameObject.tag == "Enemy")
            {
                return;
            }
            obj.isCollide = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        ObjectCollision obj = gameObject.GetComponent<ObjectCollision>();
        if (obj)
        {
            obj.isCollide = false;
        }
    }
}
