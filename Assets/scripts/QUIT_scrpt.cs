using UnityEngine;

public class QUIT_scrpt : MonoBehaviour
{      
    public void DoExitGame() 
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }
}
