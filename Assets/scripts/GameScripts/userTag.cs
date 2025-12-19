using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using System;
using System.Collections;

public class userTag : MonoBehaviour
{
    public TMP_Text tagText;
    public TMP_Text utTxt; 
    public RectTransform parentRect;     // přiřaď v Inspectoru nebo získej v Start()
    public RectTransform textAreaRect;   // přiřaď v Inspectoru
    IEnumerator Start()
    {
        string TagName = "Ultrasuperbignigga";
        string TagMachine = "Linuxproutrahacker";
        if (tagText != null)
        {
            tagText.text = TagName + "@" + TagMachine + ":~$";
        }
        else
        {
            Debug.LogWarning("Input Field is not assigned.");
        }
// vypisující funkce do prefixu v terminále
        yield return null;
        Sizing();
    }

    public void Sizing()
    {
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(utTxt.rectTransform);

        // získat parentRect automaticky, pokud není přiřazený:
        if (parentRect == null && transform.parent != null)
            parentRect = transform.parent.GetComponent<RectTransform>();

        if (parentRect == null)
        {
            Debug.LogWarning("userTag: parentRect is not assigned and parent has no RectTransform.");
            return;
        }

        float parentWidth = parentRect.rect.width;
        float utPreferredWidth = utTxt.preferredWidth;
        float spacing = 30f;
        float minTextAreaWidth = 50f;

        // cap utTxt width so both fields fit in parent
        float maxUtWidth = Mathf.Max(0f, parentWidth - minTextAreaWidth - spacing);
        float utWidth = Mathf.Min(utPreferredWidth, maxUtWidth);

        // compute remaining width for the text area
        float textAreaWidth = parentWidth - utWidth - spacing;
        textAreaWidth = Mathf.Max(minTextAreaWidth, textAreaWidth);

        // Apply sizes
        if (textAreaRect != null)
            textAreaRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textAreaWidth);
        else
            Debug.LogWarning("userTag: textAreaRect is not assigned.");

        if (utTxt != null && utTxt.rectTransform != null)
            utTxt.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, utWidth);
        else
            Debug.LogWarning("userTag: utTxt RectTransform is not available.");

        Debug.Log($"userTag Sizing: parentWidth={parentWidth}, utPreferred={utPreferredWidth}, utUsed={utWidth}, textArea={textAreaWidth}");
    }



}
