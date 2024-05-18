using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentHandRaiseHandler : MonoBehaviour
{
    public List<Button> studentButtons;
    private Button raisedHandButton;

    public void Start() {
        RaiseHand(0);
    }

    public void OnStudentButtonClick(DialogueTrigger dialogueTrigger)
    {
        ResetHands();
        dialogueTrigger.TriggerDialogue();
    }

    public void RaiseHand(int studentIndex)
    {
        if (raisedHandButton != null)
        {
            ResetHands();
        }


        raisedHandButton = studentButtons[studentIndex];
        SetHandImageActive(raisedHandButton, true);
    }

    void ResetHands()
    {
        if (raisedHandButton != null)
        {
            SetHandImageActive(raisedHandButton, false);
            raisedHandButton = null;
        }
    }

    void SetHandImageActive(Button button, bool isActive)
    {
        // Assuming the hand image is a child with the name "HandImage"
        Image[] images = button.GetComponentsInChildren<Image>(true);
        foreach (Image image in images)
        {
            if (image.gameObject.name == "Hand")
            {
                image.gameObject.SetActive(isActive);
                break;
            }
        }
    }
}
