using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuUI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private string swapMenuTrigger = "swapMenu";
        [SerializeField] private Animator pauseMenuAnimator;
        [SerializeField] private CanvasGroup pauseCanvasGroup;
        private bool menuIsActive = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SwapMenuState();
        }

        public void SwapMenuState()
        {
            menuIsActive = !menuIsActive;
            pauseMenuAnimator.SetTrigger(swapMenuTrigger);
            Time.timeScale = menuIsActive ? 0f : 1f;
            pauseCanvasGroup.interactable = menuIsActive;
        }

        public void LoadScene(int buildIndex)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}