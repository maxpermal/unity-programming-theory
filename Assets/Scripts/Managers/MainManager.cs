using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Core;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    SpawnManager spawnManager;

    public List<string> scencesList;
    [SerializeField] string currentScene;
    public string CurrentScene => currentScene;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = SpawnManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        EventManager.Tick();
    }

    public void OnReStartGame()
    {
        new RestartGameEventDecorator();
    }

    public void OnGotoMenu()
    {
        new GotoMenuEventDecorator();
    }

    public void OnStartGame()
    {
        new StartScene1EventDecorator();
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void LoadAScene(string name)
    {
        currentScene = name;
        if (CurrentScene.ToUpper() == "SCENE1")
        {
            SceneManager.LoadScene("SampleScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        else if (CurrentScene.ToUpper() == "MENU")
        {
            SceneManager.LoadScene("Menu", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
