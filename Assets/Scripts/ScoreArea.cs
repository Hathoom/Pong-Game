using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    //variable put in to figure out if left/right score zone
    // 0 is left score zone, 1 is right score zone.
    public int lrscore;

    public ScoreArea otherArea;

    // both score values, each should only care about 1, 
    // I will need to improve this
    private int lscore = 0;
    private int rscore = 0;

    // a reference to the ui so I can easily update the score.
    public UI ui;

    public PuckSpawn spawnArea;

    private void OnTriggerEnter(Collider other)
    {
        //destroy existing puck
        Destroy(other.gameObject);

        // right player scores
        if (lrscore == 0)
        {
            rscore++;
            Debug.Log("Right player scored" + " their score is: " + rscore);
            CheckWin(rscore);
            SetScore();
            //spawn the next puck
            spawnArea.SpawnPuck(-1);
        }
        // left player scores
        if (lrscore == 1)
        {
            lscore++;
            Debug.Log("Left player scored" + " their score is: " + lscore);
            CheckWin(lscore);
            SetScore();

            //spawn the next puck
            spawnArea.SpawnPuck(1);
        }
    }

    public void SetScore()
    {
        //check if this is left or right zone through score.
        if (lrscore == 1)
        {
            ui.SetLeftScore(lscore);
        }
        else
        {
            ui.SetRightScore(rscore);
        }
    }

    public void CheckWin(int score)
    {
        if (score >= 11)
        {
            if (lscore == score)
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

    public void ResetScore()
    {
        lscore = 0;
        rscore = 0;
        SetScore();
    }
}
