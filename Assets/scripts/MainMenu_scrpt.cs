using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_scrpt : MonoBehaviour
{
    public void doPlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
