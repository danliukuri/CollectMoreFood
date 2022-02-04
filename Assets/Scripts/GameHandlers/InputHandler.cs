using UnityEngine;

namespace GameHandlers
{
    public class InputHandler : MonoBehaviour
    {
#if UNITY_ANDROID
        const float interpolatationStepMultiplier = 8;
#endif
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
            float interpolatationStep = interpolatationStepMultiplier * Time.deltaTime;

            if (Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                float target = (touchPosition.x > Screen.width / 2) ? 1f : -1f;

                horizontalInput = Mathf.LerpUnclamped(horizontalInput, target, interpolatationStep);
            }
            else
                horizontalInput = (Mathf.Abs(horizontalInput) < interpolatationStep) ? 0f :
                    Mathf.LerpUnclamped(horizontalInput, 0f, interpolatationStep);
        }
#elif UNITY_STANDALONE || UNITY_WEBGL
        public static void GetHorizontalAxis(ref float horizontalInput) =>
            horizontalInput = Input.GetAxis("Horizontal");
#endif
    }
}