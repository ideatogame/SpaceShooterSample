using System;
using UnityEngine;

namespace Stats
{
    public class Score : MonoBehaviour
    {
        private float currentScore = 0f;

        private void AddToScore(float value)
        {
            currentScore += value;
        }

        private void OnDestroy() => SaveScore();

        private void SaveScore()
        {
            
        }
    }
}