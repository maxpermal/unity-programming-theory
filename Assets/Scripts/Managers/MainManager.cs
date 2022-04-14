using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Core;

public class MainManager : MonoBehaviour, IUiHandler
{
    public static MainManager Instance;

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

    GameManager gameManager;
    SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        spawnManager = GetComponent<SpawnManager>();
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
