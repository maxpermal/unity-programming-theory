using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject startBtn;
    [SerializeField] GameObject quitBtn;
    [SerializeField] GameObject gotomenuBtn;
    [SerializeField] GameObject gotomenu1Btn;
    [SerializeField] GameObject restartBtn;
    public enum SceneId
    { 
        Menu,
        Scene1
    }

    public SceneId scene;
    void Start()
    {
        switch(scene)
        {
            case SceneId.Menu:
                MenuUIHandler();
                break;
            case SceneId.Scene1:
                GameUIHandler();
                break;
        }
    }

    public void MenuUIHandler()
    {
        Debug.Log("MenuUIHandler");
        startBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => MainManager.Instance.OnStartGame());
        quitBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => MainManager.Instance.OnQuit());
    }

    public void GameUIHandler()
    {
        Debug.Log("GameUIHandler");
        gotomenuBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=>MainManager.Instance.OnGotoMenu());
        gotomenu1Btn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=>MainManager.Instance.OnGotoMenu());
        restartBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=>MainManager.Instance.OnReStartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


