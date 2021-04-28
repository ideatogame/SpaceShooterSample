using HealthSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ship.Behaviour
{
    public class ShipHealth : Health
    {
        [SerializeField] private int deathSceneBuildIndex = 4;

        protected override void Death()
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(deathSceneBuildIndex);
        }
    }
}
