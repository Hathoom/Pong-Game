using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    //variable put in to figure out if left/right score zone
    // 0 is left score zone, 1 is right score zone.
    public int lrscore;

    public ScoreArea otherArea;

    // score of the area
    private int score = 0;

    // color of the area
    private int color;


    // a reference to the ui so I can easily update the score.
    public UI ui;

    public PuckSpawn spawnArea;

    //when a puck hits a score area
    private void OnTriggerEnter(Collider other)
    {
        //destroy existing puck
        Destroy(other.gameObject);

        // right player scores
        if (lrscore == 0)
        {
            score++;
            Debug.Log("Right player scored" + " their score is: " + score);
            CheckWin(score);
            SetScore();
            //spawn the next puck
            spawnArea.SpawnPuck(-1);
        }
        // left player scores
        if (lrscore == 1)
        {
            score++;
            Debug.Log("Left player scored" + " their score is: " + score);
            CheckWin(score);
            SetScore();
            //spawn the next puck
            spawnArea.SpawnPuck(1);
        }
    }

    // alter the ui to show the current score
    public void SetScore()
    {
        //set this area's text color
        SetColor();
        //set the other area's text color
        otherArea.SetColor();

        //check if this is left or right zone through score.
        if (lrscore == 1)
        {
            ui.SetLeftScore(score, color);
            ui.SetRightScore(otherArea.GetScore(), otherArea.GetColor());
        }
        else
        {
            ui.SetRightScore(score, color);
            ui.SetLeftScore(otherArea.GetScore(), otherArea.GetColor());
        }
    }

    // check for a win
    public void CheckWin(int score)
    {
        if (score >= 11)
        {
            //determine which side won
            if (lrscore == 1)
            {
                Debug.Log("Game Over, Left Player wins!");
                otherArea.ResetScore();
                ResetScore();
            }
            else
            {
                Debug.Log("Game Over, Right Player wins!");
                otherArea.ResetScore();
                ResetScore();
            }
        }
    }

    //reset the score to 0
    public void ResetScore()
    {
        score = 0;
        SetScore();
    }

    //get the score
    public int GetScore()
    {
        return score;
    }

    public void SetColor()
    {
        if (score > otherArea.GetScore())
        {
            color = 1;
        }
        else if (score == otherArea.GetScore())
        {
            color = 2;
        }
        else
        {
            color = 3;
        }
    }

    public int GetColor()
    {
        return color;
    }
}
