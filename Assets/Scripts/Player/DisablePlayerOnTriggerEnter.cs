using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerOnTriggerEnter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.GetComponent<ParticleSystemController>().Play();
            
            if(GameplayHandler.GameplayStarted)
            {
                ScoreCounter.Score++;
                ScoreCounter.UpdateScoreText();
            }
        }
    }
}
