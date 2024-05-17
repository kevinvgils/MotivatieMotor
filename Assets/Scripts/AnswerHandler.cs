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
    public void OnButtonClick(int index)
    {
        if (buttonText != null)
        {
            questionManager.EndQuestion(index);

        }
        else
        {
            Debug.LogError("Text component not found on the button.");
        }
    }
}
