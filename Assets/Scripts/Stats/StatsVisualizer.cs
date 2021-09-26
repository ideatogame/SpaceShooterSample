using TMPro;
using UnityEngine;

namespace Stats
{
    public class StatsVisualizer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI asteroidsCounter;

        private void Awake()
        {
            GameStats.OnAsteroidsDestroyedChanged += GameStats_OnAsteroidsDestroyedChanged;
        }

        private void GameStats_OnAsteroidsDestroyedChanged(int asteroidsDestroyed)
        {
            asteroidsCounter.SetText(asteroidsDestroyed.ToString());
        }
    }
}
