using System;
using System.Collections.Generic;

namespace Stats
{
    public static class GameStats
    {
        public static event EventHandler OnAsteroidsDestroyedChanged;
        public static int AsteroidsDestroyed { get; private set; }
        
        private static Dictionary<string, float> highscores = new Dictionary<string, float>();
        
        public static void AddToAsteroidsDestroyed(int value)
        {
            if (value <= 0)
                return;

            AsteroidsDestroyed += value;
            OnAsteroidsDestroyedChanged?.Invoke(new object(), EventArgs.Empty);
        }

        public static void RemoveFromAsteroidsDestroyed(int value)
        {
            if (value >= 0)
                return;

            AsteroidsDestroyed -= value;
            OnAsteroidsDestroyedChanged?.Invoke(new object(), EventArgs.Empty);
        }
    }
}
