using GameHandlers;
using UnityEngine;

public class PlayerCollectionOnTriggerEnter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.GetComponent<ParticleSystemController>().Play();

            if (GameplayHandler.GameplayStarted)
            {
                ScoreCounter.Score++;
                ScoreCounter.UpdateScoreText();
            }

            AudioController.PlayerCollection();
        }
    }
}