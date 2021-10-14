using GameHandlers;
using UnityEngine;

public class PlayerLossOnTriggerExit : MonoBehaviour
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

            AudioController.PlayerLoss();
        }
    }
}