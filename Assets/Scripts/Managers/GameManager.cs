using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Core;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    public TextMeshProUGUI scoreText;
    private int score;
    private GameObject uicanvas;

    MainManager mainManager;

    void Awake()
    {
        Debug.Log("Awake ");
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
        mainManager = MainManager.Instance;

        Debug.Log("Start Gamemanager : " + mainManager.CurrentScene);
        StartGame();
    }

    public void StartGame()
    {
        scoreText = GameObject.Find("Score Text ").GetComponent<TextMeshProUGUI>();
        score = 0;
        IncreaseScore(0);

        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().StartGame();
        
        uicanvas = GameObject.Find("UICanvas");
        uicanvas.GetComponent<ActiveDialogBox>().StartGame();
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
}
