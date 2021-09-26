using System;

namespace Stats
{
    public static class GameStats
    {
        public static event Action<int> OnAsteroidsDestroyedChanged = delegate {  };
        private static int AsteroidsDestroyed { get; set; }
        
        public static void AddToAsteroidsDestroyed(int value)
        {
            if (value <= 0)
                return;

            AsteroidsDestroyed += value;
            OnAsteroidsDestroyedChanged.Invoke(AsteroidsDestroyed);
        }
    }
}
