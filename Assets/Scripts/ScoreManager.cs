using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int motType1;
    private int motType2;
    private int motType3;
    private int motType4;
    private int motType5;
    public TMP_Text textMot1;
    public TMP_Text textMot2;
    public TMP_Text textMot3;
    public TMP_Text textMot4;
    public TMP_Text textMot5;

    public void AddToScore(Answer givenAnswer) {
        if(givenAnswer.motType == MotivationType.Mot1) {
            motType1 += givenAnswer.coinAmount;
            textMot1.text = motType1.ToString(); 
        } else if(givenAnswer.motType == MotivationType.Mot2) {
            motType2 += givenAnswer.coinAmount;
            textMot2.text = motType2.ToString(); 
        } else if(givenAnswer.motType == MotivationType.Mot3) {
            motType3 += givenAnswer.coinAmount;
            textMot3.text = motType3.ToString(); 
        } else if(givenAnswer.motType == MotivationType.Mot4) {
            motType4 += givenAnswer.coinAmount;
            textMot4.text = motType4.ToString(); 
        } else if(givenAnswer.motType == MotivationType.Mot5) {
            motType5 += givenAnswer.coinAmount;
            textMot5.text = motType5.ToString(); 
        }
    }
}
