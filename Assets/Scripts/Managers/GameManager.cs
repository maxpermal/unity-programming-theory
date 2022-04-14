using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Core;

public class GameManager : MonoBehaviour
{
    // public static GameManager Instance;

    public GameObject player;
    public TextMeshProUGUI scoreText;
    private int score;
    private GameObject uicanvas;

    MainManager mainManager;
    SpawnManager spawnManager;

    // void Awake()
    // {
    //     Debug.Log("Awake ");
    //     if (Instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     Instance = this;
    //     DontDestroyOnLoad(gameObject);
    // }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        loadedAtStart = false;
    }

    public void Start()
    {
        mainManager = MainManager.Instance;
        spawnManager = mainManager.gameObject.GetComponent<SpawnManager>();
    }

    public void StartGame()
    {
        Debug.Log("Start Gamemanager : " + mainManager.CurrentScene);

        if(mainManager.CurrentScene == "MENU") return;
        
        score = 0;
        scoreText = GameObject.Find("Score Text ").GetComponent<TextMeshProUGUI>();
        IncreaseScore(0);

        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().StartGame();
        
        uicanvas = GameObject.Find("UICanvas");
        uicanvas.GetComponent<ActiveDialogBox>().StartGame();

        spawnManager.StartGame();
    }

    bool loadedAtStart = false;
    void Update()
    {
        if(loadedAtStart == false)
        {       
            StartGame();
            loadedAtStart = true;
        }
    }

    public void QuitGame()
    {
        uicanvas.GetComponent<ActiveDialogBox>().QuitGame();
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

    public void RemoveEnemy(GameObject enemy)
    {
        spawnManager.RemoveEnemy(enemy);
    }

    public void LoadAScene(string name)
    {
        throw new System.NotImplementedException();
    }
}
