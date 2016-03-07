using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] Transform TargetEnemy;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 10, 10);
    }

    void SpawnEnemy()
    {
        GameObject clone = Instantiate(EnemyPrefab);
        clone.transform.position = gameObject.transform.position;
        clone.GetComponent<RaycastTest>().Target = TargetEnemy.gameObject;
        clone.GetComponent<movement>().target = TargetEnemy;
        Debug.Log("Spawned enemy");
    }

}
