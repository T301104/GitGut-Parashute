using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        //load the main scene
        SceneManager.LoadScene("MainLevel");
    }

    public void Quit()
    {
        //turn off aplication
        Application.Quit();
    }
}
