using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shared
{
    public class PersistenceManager
    {
        public static List<int> GetScoreList()
        {
            List<int> scores = new List<int>
            {
                PlayerPrefs.GetInt(Constants.FIRST_SCORE, 0),
                PlayerPrefs.GetInt(Constants.SECOND_SCORE, 0),
                PlayerPrefs.GetInt(Constants.THIRD_SCORE, 0),
                PlayerPrefs.GetInt(Constants.FOURTH_SCORE, 0),
                PlayerPrefs.GetInt(Constants.FIFTH_SCORE, 0)
            };

            return scores;
        }

        public static void AddScore(int score)
        {
            List<int> currentScore = GetScoreList();
            currentScore.Add(score);
            currentScore.Sort();
            currentScore.Reverse();
            
            SetScore(currentScore[0], 
                    currentScore[1], 
                    currentScore[2],
                    currentScore[3],
                    currentScore[4]);
        }

        public static void SetScore(int first, int second, int third, int fourth, int fifth)
        {
            PlayerPrefs.SetInt(Constants.FIRST_SCORE, first);
            PlayerPrefs.SetInt(Constants.SECOND_SCORE, second);
            PlayerPrefs.SetInt(Constants.THIRD_SCORE, third);
            PlayerPrefs.SetInt(Constants.FOURTH_SCORE, fourth);
            PlayerPrefs.SetInt(Constants.FIFTH_SCORE, fifth);
        }
    }
}