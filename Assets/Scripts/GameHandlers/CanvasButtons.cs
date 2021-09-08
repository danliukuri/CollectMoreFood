using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtons : MonoBehaviour
{
    #region Properties
    public float InvokeDelay { set; get; }
    #endregion

    #region Fields
    [SerializeField] float startMainMenuTime;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameplayStartCountdown;
    [SerializeField] GameObject gameplayMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameoverMenu;
    [SerializeField] GameObject settingsMenu;

    static CanvasButtons instance;
    Animator pauseMenuAnimator;
    Animator gameplayMenuAnimator;
    #endregion

    #region Methods
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            pauseMenuAnimator = pauseMenu.GetComponent<Animator>();
            gameplayMenuAnimator = gameplayMenu.GetComponent<Animator>();
        }
    }

    void Start()
    {
        Invoke(nameof(SetActiveMainMenu), startMainMenuTime);
    }

    void SetActiveMainMenu() => instance.mainMenu.SetActive(true);
    public void Invoke(string methodName) => Invoke(methodName, InvokeDelay);

    public void Play()
    {
        ScoreCounter.UpdateScoreText();
        ScoreCounter.UpdateScoreToLose();
        gameplayStartCountdown.SetActive(true);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        Application.OpenURL("https://yuriy-danyliuk.itch.io/");
#else
        Application.Quit();
#endif
    }

    public static void Pause()
    {
        instance.pauseMenu.SetActive(true);
        GameplayHandler.PauseGameplay();
    }
    public static void Unpause()
    {
        instance.pauseMenuAnimator.SetTrigger("Disappear");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToSettings()
    {
        settingsMenu.SetActive(true);
    }

    public static void StartGameplay()
    {
        instance.gameplayMenu.SetActive(true);
    }
    public static void FinishGameplay()
    {
        instance.gameoverMenu.SetActive(true);
        instance.gameplayMenuAnimator.SetTrigger("Disappear");
    }
    #endregion
}