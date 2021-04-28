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

        private void GameStats_OnAsteroidsDestroyedChanged(object sender, System.EventArgs e)
        {
            asteroidsCounter.text = GameStats.AsteroidsDestroyed.ToString();
        }
    }
}
