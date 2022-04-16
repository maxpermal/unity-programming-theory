using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] boss;
    [SerializeField] GameObject[] enemies;
    [SerializeField] float distanceFromPlayer;

    GameObject player;

    [SerializeField] int waveNumber = 0;
    [SerializeField] int enemiesMultiPerWave;
    [SerializeField] int bossNumber = 0;
    [SerializeField] private bool forceNextWave;
    List<GameObject> spawnEnemies = new List<GameObject>();
    
    public bool isEnable = false;

    MainManager mainManager;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SpawnManager.Start");
        mainManager = MainManager.Instance;
        gameManager = mainManager.gameObject.GetComponent<GameManager>();
        isEnable = false;
    }

    public void StartGame()
    {
        Debug.Log("SpawnManager.StartGame");
        isEnable = true;
        waveNumber = 0;

        SetPlayerPositionInWave();

        if (IsInvoking("SpawnAllEnemiesForWave") == false)
        {
            InvokeRepeating("SpawnAllEnemiesForWave", 2, 2);
        }
    }

    public void QuitGame()
    {
        Debug.Log("SpawnManager.QuitGame");
        isEnable = false;
        CancelInvoke("SpawnAllEnemiesForWave");
        ClearEnemiesList();
    }

    #region start game private methods

    void ClearEnemiesList()
    {
        for (var i = spawnEnemies.Count - 1; i >= 0; i--)
        {
            var en = spawnEnemies[i];
            spawnEnemies.Remove(en);
            Destroy(en);
        }
        spawnEnemies.Clear();
    }

    void SetPlayerPositionInWave()
    {
        player = GameObject.Find("Player");
        if (waveNumber == 0)
        {
            var controller = player.GetComponent<PlayerController>();
            controller.transform.position = new Vector3(-2, 1, -3);
        }
    }

    #endregion

    void SpawnAllEnemiesForWave()
    {
        if (isEnable == false)
        {
            return;
        }
        if ((spawnEnemies.Count > 0 && forceNextWave == false))
        {
            return;
        }
        if (waveNumber >= 3)
        {
            new VictoryEventDecorator();
            return;
        }

        Debug.Log("SpawnAllEnemiesForWave");
        forceNextWave = false;
        waveNumber++;
        SpawnBoss();
        SpawnMobs();
    }

    #region spawn enemies

    void SpawnBoss()
    {
        if (waveNumber % 3 == 0)
        {
            Vector3 randPos = GetRandomPositionFromCenter(player.transform.position, distanceFromPlayer);
            SpawnEnemy(boss[bossNumber], player.transform.position + randPos);
        }
    }

    void SpawnMobs()
    {
        int nbEnemies = enemiesMultiPerWave * waveNumber;
        for (int i = 0; i < nbEnemies; i++)
        {
            Vector3 randPos = GetRandomPositionFromCenter(player.transform.position, distanceFromPlayer / 2);
            int randTypeEnemy = Random.Range(0, enemies.Length);
            SpawnEnemy(enemies[randTypeEnemy], player.transform.position + randPos);
        }
    }

    Vector3 GetRandomPositionFromCenter(Vector3 position, float radius)
    {
        float angle = Random.Range(0, 360);
        Vector3 randPos = position;
        randPos.z += Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
        randPos.x += Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
        return randPos;
    }

    void SpawnEnemy(GameObject enemy, Vector3 position)
    {
        var newEnemy = Instantiate(enemy, position, enemy.transform.rotation);
        spawnEnemies.Add(newEnemy);
    }

    #endregion

    public void RemoveEnemy(GameObject enemy)
    {
        spawnEnemies.Remove(enemy);
    }
}
