using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI leftScoreText;

    public void SetRightScore(int score, int color)
    {
        //change the score
        rightScoreText.text = score.ToString();
        
        //change the color
        if (color == 1)
        {
            rightScoreText.color = Color.green;
        }
        else if (color == 2)
        {
            rightScoreText.color = Color.white;
        }
        else if (color == 3)
        {
            rightScoreText.color = Color.red;
        }

    }

    public void SetLeftScore(int score, int color)
    {
        leftScoreText.text = score.ToString();

        //change the color
        if (color == 1)
        {
            leftScoreText.color = Color.green;
        }
        else if (color == 2)
        {
            leftScoreText.color = Color.white;
        }
        else if (color == 3)
        {
            leftScoreText.color = Color.red;
        }
    }

}
