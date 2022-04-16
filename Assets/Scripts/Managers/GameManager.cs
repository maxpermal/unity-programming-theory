using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Core;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public GameObject Player { get; private set; }
    // ENCAPSULATION
    public TextMeshProUGUI ScoreText{ get; private set; }

    private int score;
    private GameObject uicanvas;

    MainManager mainManager;
    SpawnManager spawnManager;

    public void Start()
    {
        Debug.Log("Gamemanager.Start");
        mainManager = MainManager.Instance;
        spawnManager = mainManager.gameObject.GetComponent<SpawnManager>();
    }

    public void StartGame()
    {
        Debug.Log("Gamemanager.StartGame : " + mainManager.CurrentScene);

        Player = GameObject.Find("Player");
        Player.GetComponent<PlayerController>().StartGame();
  
        uicanvas = GameObject.Find("UICanvas");
        uicanvas.GetComponent<ActiveDialogBox>().StartGame();

        score = 0;
        ScoreText = GameObject.Find("Score Text ").GetComponent<TextMeshProUGUI>();
        IncreaseScore(0);
    }

    public void QuitGame()
    {
        Debug.Log("Gamemanager.QuitGame");
        uicanvas.GetComponent<ActiveDialogBox>().QuitGame();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        ScoreText.text = "Score : " + score;
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
        if (enemy.GetComponent<ActorProfile>() is ActorProfile p)
        {
            IncreaseScore(p.scoreValue);
        }
    }
}
