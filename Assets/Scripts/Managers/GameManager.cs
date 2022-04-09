using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Core;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public TextMeshProUGUI scoreText;
    private int score;

    SpawnManager spawnManager;
    GameObject uicanvas;

    public List<string> scencesList;
    public string currentScene;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        spawnManager = GetComponent<SpawnManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(currentScene == "MENU")
        {
            StartMenu();
        }
        else if (currentScene == "SCENE1")
        {
            StartGame();
        }
    }

    public void StartMenu()
    {

    }

    public void StartGame()
    {
        score = 0;
        IncreaseScore(0);

        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().StartGame();

        spawnManager.StartGame();
        
        uicanvas = GameObject.Find("UICanvas");
        uicanvas.GetComponent<ActiveDialogBox>().StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        EventManager.Tick();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score : " + score;
    }

    public void Shoot(GameObject src, GameObject bullet, Vector3 direction)
    {
        var pos = src.transform.position;
        pos.y = 0;
        GameObject missile = Instantiate(bullet, pos, src.transform.rotation);
        var bulletc = missile.GetComponent<BulletController>();
        bulletc.Shoot(src, Mathf.Atan2(direction.z, direction.x));
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
        if(currentScene == "SCENE1")
        {
            SceneManager.LoadScene("SampleScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        else if (currentScene == "MENU")
        {
            SceneManager.LoadScene("Menu", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
