using UnityEngine;
using UnityEngine.SceneManagement;

namespace Miscellaneous
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(int buildIndex) => SceneManager.LoadScene(buildIndex);

        public void QuitApplication() => Application.Quit();
    }
}
