using UnityEngine;
using System.Collections;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class DebrisShooter : TimedSpawner
{
    GameObject player;

    float time_alive = 0f;
    [SerializeField] float speed = 3f;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        this.StartCoroutine(SpawnRoutine());
    }
    protected override IEnumerator SpawnRoutine()
    {
        while (true)
        {
            time_alive += Time.deltaTime;
            Vector3 starting_point = base.transform.position;
            Vector3 ending_point = player.transform.position;

            Vector3 velocity_vector = (ending_point - starting_point);
            float dist = velocity_vector.magnitude;
            velocity_vector /= dist;
            velocity_vector *= speed;


            Debug.Log("Found " + player.name);
            //base.velocityOfSpawnedObject = new Vector3(Random.Range(-1, 1), Random.Range(-2,3), Random.Range(0, 5));
            base.velocityOfSpawnedObject = velocity_vector;

            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            yield return new WaitForSeconds(timeBetweenSpawns*10);
        }
    }
}