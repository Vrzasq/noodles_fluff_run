using Assets.scripts.cat;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.scripts
{
    public class GameManager : MonoBehaviour
    {
        void Awake()
        {
            CatController.OnDeath += CatController_OnDeath;
        }

        void OnDisable()
        {
            CatController.OnDeath -= CatController_OnDeath;
        }

        private void CatController_OnDeath()
        {
            SceneManager.LoadScene("ForestLevel");
        }
    }
}
