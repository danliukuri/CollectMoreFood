using TMPro;
using UnityEngine;

namespace GameHandlers
{
    public class ScoreCounter : MonoBehaviour
    {
        #region Properties
        public static int Score { get; set; }
        public static int ScoreToLose { get; set; }
        #endregion

        #region Fields
        [Header("Main scores")]
        [SerializeField] GameObject scoreContainer;
        [SerializeField] TMP_Text scoreTMP;
        [SerializeField] GameObject highScoreContainer;
        [SerializeField] TMP_Text highScoreTMP;
        [Header("Gameplay scores")]
        [SerializeField] TMP_Text scoreToLoseTMP;
        [Header("Gameover scores")]
        [SerializeField] TMP_Text gameoverHighScoreTMP;
        [SerializeField] TMP_Text gameovercurrentGameScoreTMP;

        static ScoreCounter instance;
        #endregion

        #region Methods
        void Awake()
        {
            if (instance == null)
                instance = this;
        }
        void Start()
        {
            ResetScore();
            TryToOutputHighScore();
        }

        public static void UpdateScoreText()
        {
            instance.scoreTMP.text = Score.ToString();
        }
        public static void UpdateScoreToLose()
        {
            instance.scoreToLoseTMP.text = ScoreToLose.ToString();
        }

        void TryToOutputHighScore()
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            if (highScore > 0)
            {
                highScoreContainer.SetActive(true);
                highScoreTMP.text = highScore.ToString();
            }
        }
        static void TryToSaveScore()
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            if (Score > highScore)
                highScore = Score;

            if (highScore > 0)
                PlayerPrefs.SetInt("HighScore", highScore);
        }

        public static void OutputGameoverScores()
        {
            TryToSaveScore();
            instance.gameoverHighScoreTMP.text = PlayerPrefs.GetInt("HighScore").ToString();
            instance.gameovercurrentGameScoreTMP.text = Score.ToString();
            ResetScore();
        }
        public static void ResetScore()
        {
            ScoreToLose = 0;
            Score = 0;
        }
        #endregion
    }
}