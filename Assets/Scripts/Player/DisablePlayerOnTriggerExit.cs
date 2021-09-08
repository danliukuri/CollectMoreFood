using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerOnTriggerExit : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);

            if (GameplayHandler.GameplayStarted)
            {
                ScoreCounter.ScoreToLose++;
                ScoreCounter.UpdateScoreToLose();
                GameplayHandler.CheckGameLose();
            }
        }
    }
}
