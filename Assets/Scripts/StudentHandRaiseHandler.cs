using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentHandRaiseHandler : MonoBehaviour
{
    public List<Button> studentButtons;
    private Button raisedHandButton;
    public int startStudent;

    public void Start() {
        RaiseHand(startStudent);
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
    Debug.Log(button);
    Transform[] children = button.GetComponentsInChildren<Transform>(true);
    Debug.Log(children.Length);
    
    foreach (Transform child in children)
    {
        Debug.Log(child);
        // Check if the child is named "HandImage"
        if (child.gameObject.name == "Hand")
        {
            child.gameObject.SetActive(isActive);
            break;
        }
    }

    // Apply the isActive state to all children of the button
    foreach (Transform child in button.transform)
    {
        child.gameObject.SetActive(isActive);
    }
}
}
