using System.Collections;
using UnityEngine;

/**
 * This component spawns the given object at fixed time-intervals at its object position.
 */
public class TimedSpawner: MonoBehaviour {
    [SerializeField]protected Mover prefabToSpawn;
    [SerializeField]protected Vector3 velocityOfSpawnedObject;
    [SerializeField] protected float timeBetweenSpawns = 1f;

    void Start() {
        this.StartCoroutine(SpawnRoutine());
        Debug.Log("Start finished");
    }

    protected virtual IEnumerator SpawnRoutine() {
        while (true) {
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
