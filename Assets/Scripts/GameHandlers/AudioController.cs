using UnityEngine;
using Utilities.Audio;

namespace GameHandlers
{
    public class AudioController : MonoBehaviour
    {
        public static void PlayMenuTheme()
        {
            if (!AudioManager.FindAudioSource("MenuTheme").isPlaying)
                AudioManager.FadeInAndPlay("MenuTheme", 0.5f);
        }

        public static void StartGameplay()
        {
            AudioManager.Play("GameplayTheme");
        }
        public static void FinishGameplay()
        {
            AudioManager.Play("LastPlayerLoss");
            AudioManager.FadeOutAndStop("GameplayTheme", 1f);
            AudioManager.FadeInAndPlay("MenuTheme", 0.7f);
        }

        public static void PauseGameplay()
        {
            AudioManager.Play("PauseTheme");
            AudioManager.Pause("GameplayTheme");
        }
        public static void UnpauseGameplay()
        {
            AudioManager.Stop("PauseTheme");
        }
        public static void ResumeGameplay()
        {
            AudioManager.Unpause("GameplayTheme");
        }

        public static void PlayerCollection() => AudioManager.Play("PlayerCollection");
        public static void PlayerLoss() => AudioManager.Play("PlayerLoss");
    }
}