using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quiz
{
    public class SummaryButton : MonoBehaviour
    {
        public AudioSource AudioClick;
        public void MainMenu()
        {
            AudioClick.Play();
            Invoke("DelaySceneButton", 0.2f);
        }

        //Delay entre as cenas
        public void DelaySceneButton() //Delay do botão play
        {
            SceneManager.LoadScene(0);
        }
    }
}
