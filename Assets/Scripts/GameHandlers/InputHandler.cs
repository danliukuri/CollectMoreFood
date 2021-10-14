using UnityEngine;

namespace GameHandlers
{
    public class InputHandler : MonoBehaviour
    {
        void Update()
        {
            if (GameplayHandler.GameplayStarted && Input.GetKeyDown(KeyCode.Escape))
            {
                if (!GameplayHandler.GameplayPaused)
                    CanvasButtons.Pause();
                else
                    CanvasButtons.Unpause();
                CanvasButtons.PlayButtonClickSound();
            }
        }
#if UNITY_ANDROID
        public static void GetHorizontalAxis(ref float horizontalInput)
        {
            const float interpolatationStep = 0.05f;

            if (Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                float target = (touchPosition.x > Screen.width / 2) ? 1f : -1f;

                horizontalInput = Mathf.LerpUnclamped(horizontalInput, target, interpolatationStep);
            }
            else
                horizontalInput = ((horizontalInput) < interpolatationStep) ? 0f :
                    Mathf.LerpUnclamped(horizontalInput, 0f, interpolatationStep);
        }
#elif UNITY_STANDALONE || UNITY_WEBGL
        public static void GetHorizontalAxis(ref float horizontalInput) =>
            horizontalInput = Input.GetAxis("Horizontal");
#endif
    }
}