using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Quiz
{
    public class MainMenuBottons : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene(1);
        }
        public void CreditsButton()
        {
            SceneManager.LoadScene(5);
        }

        public void ExitButton()
        {
            Application.Quit();
#if UNITY_2023_1_OR_NEWER
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        
    }
}
