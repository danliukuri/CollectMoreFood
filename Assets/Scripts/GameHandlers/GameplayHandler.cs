using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayHandler : MonoBehaviour
{
    #region Properties
    public static bool GameplayStarted { get; private set; }
    public static bool GameplayPaused { get; private set; }
    #endregion

    #region Fields
    [SerializeField] ItemsSpawner itemsSpawner;
    [SerializeField] Transform items;

    [SerializeField] GameObject playerControlArea;
    [SerializeField] int scoreNumberToLose;
    
    static GameplayHandler instance;
    #endregion

    #region Methods
    void Awake()
    {
        if(instance == null)
            instance = this;
    }
    void Start()
    {
        instance.itemsSpawner.InvokeRepeatingSpawn();
        GameplayStarted = false;
    }

    public static void StartGameplay()
    {
        GameplayStarted = true;
        instance.playerControlArea.SetActive(true);
        instance.itemsSpawner.InvokeRepeatingSpawn();
        CanvasButtons.StartGameplay();
    }
    static void FinishGameplay()
    {
        GameplayStarted = false;
        instance.playerControlArea.SetActive(false);
        instance.itemsSpawner.CancelInvoke(nameof(instance.itemsSpawner.Spawn));
        ScoreCounter.OutputGameoverScores();
        CanvasButtons.FinishGameplay();
    }

    public static void PauseGameplay()
    {
        GameplayPaused = true;
        Time.timeScale = 0f;
    }
    public static void ResumeGameplay()
    {
        GameplayPaused = false;
        Time.timeScale = 1f;
    }

    public static void CheckGameLose()
    {
        if (ScoreCounter.ScoreToLose == instance.scoreNumberToLose) 
            FinishGameplay();
    }
    #endregion
}
