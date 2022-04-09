using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCanvasOnTrigger : MonoBehaviour
{
    public GameObject character;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            character.GetComponent<QuestDialog>().canvasDlg.SetActive(true);
        }
    }
}
