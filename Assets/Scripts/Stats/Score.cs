using Shared;
using UnityEngine;

namespace Stats
{
    public class Score : MonoBehaviour
    {
        private int currentScore = 0;

        private void Awake()
        {
            GameStats.OnAsteroidsDestroyedChanged += SetScore;
        }
        
        private void OnDestroy()
        {
            GameStats.OnAsteroidsDestroyedChanged -= SetScore;
            SaveScore();
        }

        private void SetScore(int value) => currentScore = value;

        private void SaveScore() => PersistenceManager.AddScore(currentScore);
    }
}