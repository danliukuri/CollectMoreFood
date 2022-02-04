using Pool;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabsToSpawn;
    [SerializeField] float spawnRate;
    
    public void InvokeRepeatingSpawn()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnRate);
    }

    public void Spawn()
    {
        Vector3 randomPosition = new Vector3(transform.position.x + (Random.value - 0.5f) * transform.lossyScale.x,
            transform.position.y,transform.position.z);
        GameObject gameObject = PoolManager.
            GetGameObject(prefabsToSpawn[Random.Range(0,prefabsToSpawn.Length)].name, randomPosition);
        gameObject.transform.rotation = Random.rotation;

        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        playerController.Reset();

        Rigidbody rgdbody = gameObject.GetComponent<Rigidbody>();
        rgdbody.Sleep();
        rgdbody.AddTorque(Random.rotation.eulerAngles);
    }
}