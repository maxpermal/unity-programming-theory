using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Core;

public class MainManager : MonoBehaviour
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

    void OnEnable()
    {
        Debug.Log("MainManager.OnEnable");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.Log("MainManager.OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("MainManager.OnSceneLoaded: " + scene.name);
        // switch (scene.name.ToUpper())
        // {
        //     case "MENU":
        //         StartMenu();
        //         break;
        //     default:
        //         StartGame(scene.name);
        //         break;
        // }
    }

    public GameManager gameManager { get; private set; }
    public SpawnManager spawnManager { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MainManager.Start");
        gameManager = GetComponent<GameManager>();
        spawnManager = GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EventManager.Tick();
    }

    public void StartMenu()
    {
        Debug.Log("MainManager.StartMenu");
    }

    public void StartGame()
    {
        Debug.Log("MainManager.StartGame");
        gameManager.StartGame();
        spawnManager.StartGame();
    }

    public void QuitGame()
    {
        Debug.Log("MainManager.QuitGame");
        spawnManager.QuitGame();
        gameManager.QuitGame();
    }

    public void OnReStartGame()
    {
        Debug.Log("MainManager.OnReStartGame");
        new RestartGameEventDecorator();
    }

    public void OnGotoMenu()
    {
        Debug.Log("MainManager.OnGotoMenu");
        new GotoMenuEventDecorator();
    }

    public void OnStartGame()
    {
        Debug.Log("MainManager.OnStartGame");
        new StartScene1EventDecorator();
    }

    public void OnQuit()
    {
        Debug.Log("MainManager.OnQuit");
        Application.Quit();
    }

    public void LoadAScene(string name)
    {
        Debug.Log("MainManager.LoadAScene " + name);

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
