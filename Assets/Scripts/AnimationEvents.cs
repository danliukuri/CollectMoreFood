using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    public void DeactiveThisGameobject() => gameObject.SetActive(false);
    public void StartGameplay() => GameplayHandler.StartGameplay();
    public void ResumeGameplay() => GameplayHandler.ResumeGameplay();
    public void GoToMainMenu() => SceneManager.LoadScene(0);
}