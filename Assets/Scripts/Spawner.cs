using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public int numberOfObjects = 50; // Number of objects to spawn
    public Vector3 spawnAreaSize = new Vector3(10, 10, 10); // Size of the spawn area
    public float initialVelocity = 2f; // Initial velocity for the floating effect

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Calculate a random position within the defined spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            // Instantiate the object at the random position
            GameObject newObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

            // Add random initial velocity to simulate floating in space
            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomVelocity = new Vector3(
                    Random.Range(-initialVelocity, initialVelocity),
                    Random.Range(-initialVelocity, initialVelocity),
                    Random.Range(-initialVelocity, initialVelocity)
                );
                rb.velocity = randomVelocity;

                // Ensure the object bounces off surfaces
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            // Ensure the object's collider is set to bounce
            Collider col = newObject.GetComponent<Collider>();
            if (col != null)
            {
                PhysicMaterial bounceMaterial = new PhysicMaterial();
                bounceMaterial.bounciness = 1.0f; // Maximum bounciness
                col.material = bounceMaterial;
            }
        }
    }
}
