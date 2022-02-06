using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI leftScoreText;

    public void SetRightScore(int score)
    {
        rightScoreText.text = score.ToString();
    }

    public void SetLeftScore(int score)
    {
        leftScoreText.text = score.ToString();
    }
}
