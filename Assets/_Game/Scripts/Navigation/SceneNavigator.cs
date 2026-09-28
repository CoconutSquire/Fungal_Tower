using UnityEngine;
using UnityEngine.SceneManagement;

namespace FungalTower.Game.Navigation
{
    public class SceneNavigator : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            if (!string.IsNullOrWhiteSpace(sceneName)) SceneManager.LoadScene(sceneName);
        }

        public void ReturnToNavigation() => LoadScene("Navigation");
    }
}
