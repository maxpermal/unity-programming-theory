using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialog : MonoBehaviour
{
    public GameObject canvasDlg;
    private float timer;
    private float duration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        canvasDlg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasDlg.activeSelf == true)
        {
            if(timer<duration)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                canvasDlg.SetActive(false);
            }
        }
    }
}
