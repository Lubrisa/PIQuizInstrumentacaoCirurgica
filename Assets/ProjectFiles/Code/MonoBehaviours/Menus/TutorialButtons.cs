using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quiz
{
    public class TutorialButtons : MonoBehaviour
    {
        public void StartGame() => SceneManager.LoadScene(2);
       
    }
}
