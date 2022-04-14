using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // public static SpawnManager Instance;

    public GameObject[] boss;
    public GameObject[] enemies;
    public float distanceFromPlayer;

    GameObject player;

    public int waveNumber = 0;
    public int enemiesMultiPerWave;
    List<GameObject> spawnEnemies = new List<GameObject>();
    int bossNumber = 0;
    [SerializeField] private bool forceNextWave;
    public bool isEnable = false;

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

    // Start is called before the first frame update
    void Start()
    {
        isEnable = false;
    }

    public void StartGame()
    {
        Debug.Log("Start SpawnManager");
        isEnable = true;
        waveNumber = 0;

        SetPlayerPositionInWave();

        ClearEnemiesList();
        if (IsInvoking("SpawnAllEnemiesForWave") == false)
        {
            InvokeRepeating("SpawnAllEnemiesForWave", 2, 2);
        }
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
        //Debug.Log("SpawnAllEnemiesForWave");
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
