using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogBox : MonoBehaviour
{
    public GameObject gameover;
    public GameObject victory;
    public GameObject options;
    public GameObject dlgBox;

    public void SetActive(string which, bool value)
    {
        switch(which.ToLower())
        {
            case "gameover":
                gameover.SetActive(value);
                break;
            case "victory":
                victory.SetActive(value);
                break;
            case "options":
                options.SetActive(value);
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
        options.SetActive(false);
    }

    public void QuitGame()
    {
        gameover.SetActive(false);
        victory.SetActive(false);
        dlgBox.SetActive(false);
        options.SetActive(false);
    }
}
