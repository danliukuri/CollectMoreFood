using Pool;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] GameObject particleSystemGameObject;

    public void Play()
    {
        PoolManager.GetGameObject(particleSystemGameObject.name, transform.position);
        particleSystemGameObject.GetComponent<ParticleSystem>().Play();
    }
}