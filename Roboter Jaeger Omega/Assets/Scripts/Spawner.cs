using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject[] EnemyPrefab;
    [SerializeField] Transform TargetEnemy;
    [SerializeField] float SpawnDelay;
    [SerializeField] int MaximumSpawnValue; // Basically a limit as to how many enemies can be spawned.

    public int CurrentSpawnValue;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", SpawnDelay, SpawnDelay);
    }

    void SpawnEnemy()
    {

        int chosenSpawnedEnemy = Random.Range(0, EnemyPrefab.Length);

        Debug.Log(EnemyPrefab[chosenSpawnedEnemy].GetComponentInChildren<SpawnedEnemyTallyScript>().SpawnValueWorth + CurrentSpawnValue);
        

        if ((EnemyPrefab[chosenSpawnedEnemy].GetComponentInChildren<SpawnedEnemyTallyScript>().SpawnValueWorth + CurrentSpawnValue <= MaximumSpawnValue)) {
            CurrentSpawnValue = CurrentSpawnValue + EnemyPrefab[chosenSpawnedEnemy].GetComponentInChildren<SpawnedEnemyTallyScript>().SpawnValueWorth;
            GameObject clone = Instantiate(EnemyPrefab[chosenSpawnedEnemy]);
            clone.transform.position = gameObject.transform.position;
            clone.GetComponent<SpawnedEnemyTallyScript>().LinkedSpawner = gameObject;
            Debug.Log("Spawned enemy"); }
    }

}
