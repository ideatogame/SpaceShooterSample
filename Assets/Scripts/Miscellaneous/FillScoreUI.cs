using System.Collections.Generic;
using Shared;
using TMPro;
using UnityEngine;

namespace Miscellaneous
{
    public class FillScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private List<int> scores;

        private void Awake()
        {
            List<int> scoreList = PersistenceManager.GetScoreList();
            scores = scoreList;
            string text = string.Empty;

            for (int i = 0; i < scoreList.Count; i++)
            {
                text += $"{i + 1}: {scoreList[i]:000}";
                
                if (i != scoreList.Count - 1)
                    text += "\n";
            }

            scoreText.SetText(text);
        }
    }
}