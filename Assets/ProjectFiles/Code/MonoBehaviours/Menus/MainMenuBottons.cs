using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Quiz
{
    public class MainMenuBottons : MonoBehaviour
    {
        //Audios V
        public AudioSource AudioClick;

        public void StartButton()
        {
            AudioClick.Play();
            Invoke("DelayScenePlay", 0.2f);
        }


        public void CreditsButton()
        {
            AudioClick.Play();
            Invoke("DelaySceneCredits", 0.2f);
        }
     
      
        public void ExitButton()
        {
            AudioClick.Play();
            Invoke("DelaySceneExit", 0.2f);
        }


        //Delay entre as cenas
        public void DelayScenePlay() //Delay do botão play
        {
            SceneManager.LoadScene(1);
        }

        public void DelaySceneCredits() //Delay do botão Creditos
        {
            SceneManager.LoadScene(4);
        }

        public void DelaySceneExit() //Delay do botão Sair
        {
            Application.Quit();
#if UNITY_2023_1_OR_NEWER
            //UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

    }
}
