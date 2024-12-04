using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private Transform centerSpawner;
    [SerializeField] private float _maximumSpawnTime;
    [SerializeField] private float radius;

    private float _timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
        radius = 9;
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            Vector3 randomPos = Random.insideUnitCircle.normalized * radius;
            randomPos += centerSpawner.position;

            GameObject enemy = PoolManager.Instance.GetFromPool(_enemyPrefab);
            enemy.transform.position = randomPos;
            enemy.GetComponent<HealthController>().ResetHealth();
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
