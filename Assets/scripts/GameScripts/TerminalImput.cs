using UnityEngine;
using TMPro;

public class TxtInput : MonoBehaviour

{    
    public TMP_InputField inputField;
    void printText(string text)
    {
        Debug.Log(text);
        if (inputField != null)
        {
            inputField.SetTextWithoutNotify("");
        }
        else
        {
            Debug.LogWarning("Input Field is not assigned.");
        }
    }

    public void GetInsideText(string text)
    {
        if (text != "")
        {
            printText(text);
        }
    }
    
}
