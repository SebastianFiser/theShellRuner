using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;
    public TMP_InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;
    void Update()
    {
        if (terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("kombinace vyplněna");
            //store whenever the user types
            string userInput = terminalInput.text;
            Debug.Log("uložený input: " + userInput);
            //clear field
            ClearInputField();

            //Instantiate Gamebject with dir prefix
            AddDirectoryLine(userInput);

            //move userinput line to the bottom
            userInputLine.transform.SetAsLastSibling();

            //refocus input
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    void ClearInputField()
    {
        terminalInput.text = "";
        terminalInput.SetTextWithoutNotify("");            
        terminalInput.ActivateInputField();
        Debug.Log("pole by mělo být vičištěno");
        
    }

    void AddDirectoryLine(string userInput)
    {
        //Resizing Commandline cont
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        //instant. dirline
        GameObject msg = Instantiate(directoryLine, msgList.transform);

        //Set child index
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        //set text of gameobj
        msg.GetComponentsInChildren<TMP_Text>()[1].text = userInput;
    }

}
