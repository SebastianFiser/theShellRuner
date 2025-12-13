using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_scrpt : MonoBehaviour
{
    public void doPlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void openURLbmacf()
    {
        Application.OpenURL("https://github.com/SebastianFiser/theShellRuner/blob/main/REALLYREALLYSNEAKYFEATURE.md");
    }

    
}
