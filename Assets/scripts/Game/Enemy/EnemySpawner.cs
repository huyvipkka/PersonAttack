using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private float SpawnTime = 2f;
    [SerializeField] public int maxEnemy;
    [SerializeField] public int currentEnemy;
    float timer;
    private readonly List<Transform> spawnPoints = new();
    public static EnemySpawner Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple EnemySpawner instances detected!");
            Destroy(gameObject);
        }
    }

    private void Start() {
        for(int i = 0; i < transform.childCount; i++){
            spawnPoints.Add(transform.GetChild(i));
        }
        timer = 0;
        currentEnemy = 0;
    }

    void Update()
    {
        if(timer < SpawnTime) timer += Time.deltaTime;
        else if(currentEnemy < maxEnemy){
            int randomPos = Random.Range(0, spawnPoints.Count);
            int randomEne = Random.Range(0, _enemyPrefabs.Count);
            GameObject enemy = PoolManager.Instance.GetFromPool(_enemyPrefabs[randomEne]);

            enemy.transform.position = spawnPoints[randomPos].position;
            enemy.GetComponent<EnemyHealController>().ResetHealth();
            currentEnemy++;
            timer = 0;
        }
    }
}
