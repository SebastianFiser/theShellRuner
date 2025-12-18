using UnityEngine;
using TMPro;

public class TxtInput : MonoBehaviour

{    
    
    void printText(string text)
    {
        Debug.Log(text);
    }

    public void GetInsideText(string text)
    {
        if (text != "")
        {
            printText(text);
        }
    }
    
}
