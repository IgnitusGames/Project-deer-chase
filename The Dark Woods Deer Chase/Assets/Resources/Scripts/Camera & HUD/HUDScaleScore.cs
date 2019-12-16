using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScaleScore : MonoBehaviour
{
    public Sprite[] possibleScores;
    public Image scoreDisplay;

    public int score = 0;

    private void Start()
    {
        scoreDisplay.sprite = possibleScores[score];
    }
    public void updateHUDScore()
    {
        score++;
        scoreDisplay.sprite = possibleScores[score];
    }
}