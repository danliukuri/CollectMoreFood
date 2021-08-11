using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabsToSpawn;
    [SerializeField] float spawnRate;
    
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnRate);
    }
    
    void Spawn()
    {
        Vector3 randomPosition = new Vector3(transform.position.x + (Random.value - 0.5f) * transform.lossyScale.x,
            transform.position.y,transform.position.z);
        GameObject gameObject = PoolManager.GetGameObject(prefabsToSpawn[Random.Range(0,prefabsToSpawn.Length)].name, randomPosition);
        gameObject.transform.rotation = Random.rotation;
        gameObject.GetComponent<Rigidbody>().AddTorque(Random.rotation.eulerAngles);
    }
}
