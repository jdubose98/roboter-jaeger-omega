using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnedEnemyTallyScript : MonoBehaviour {

    public int SpawnValueWorth;
    public GameObject LinkedSpawner;

    public void ResetTally()
    {
        LinkedSpawner.GetComponent<Spawner>().CurrentSpawnValue = LinkedSpawner.GetComponent<Spawner>().CurrentSpawnValue - SpawnValueWorth;
    }
}
