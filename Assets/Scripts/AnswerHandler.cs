using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
     private TMP_Text buttonText;
     public QuestionManager questionManager;

    void Start()
    {
        // Access the Text component of this button
        buttonText = GetComponentInChildren<TMP_Text>();

        if (buttonText == null)
        {
            Debug.LogError("Text component not found on the button.");
        }
    }

    // This method is called when the button is clicked
    public void OnButtonClick()
    {
        if (buttonText != null)
        {
            // Retrieve the text value of this button
            string textValue = buttonText.text;
            Debug.Log("Button Text: " + textValue);
            questionManager.EndQuestion(textValue);

        }
        else
        {
            Debug.LogError("Text component not found on the button.");
        }
    }
}
