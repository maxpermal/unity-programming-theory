using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogBox : MonoBehaviour
{
    public GameObject gameover;
    public GameObject victory;
    public GameObject dlgBox;

    public void SetActive(string which, bool value)
    {
        switch(which)
        {
            case "gamever":
                gameover.SetActive(value);
                break;
            case "victory":
                victory.SetActive(value);
                break;
            case "dlgBox":
                dlgBox.SetActive(value);
                break;
        }
    }

    public void StartGame()
    {
        gameover.SetActive(false);
        victory.SetActive(false);
        dlgBox.SetActive(false);
    }
}
