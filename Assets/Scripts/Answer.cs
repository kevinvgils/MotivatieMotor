using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer
{
    [TextArea(2, 10)]
    public string answer;
    public MotivationType motType;
    public int coinAmount;
}