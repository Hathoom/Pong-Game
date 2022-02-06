using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    //variable put in to figure out if left/right score zone
    // 0 is left score zone, 1 is right score zone.
    public int lrscore;

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
            AddScore(rscore);
            CheckWin(rscore);
            //spawn the next puck
            spawnArea.SpawnPuck(-1);
        }
        // left player scores
        if (lrscore == 1)
        {
            lscore++;
            Debug.Log("Left player scored" + " their score is: " + lscore);
            AddScore(lscore);
            CheckWin(lscore);

            //spawn the next puck
            spawnArea.SpawnPuck(1);
        }
    }

    public void AddScore(int score)
    {
        //check if this is left or right zone through score.
        if (lscore == score)
        {
            ui.SetLeftScore(score);
        }
        else
        {
            ui.SetRightScore(score);
        }
    }

    public void CheckWin(int score)
    {
        if (score >= 11)
        {
            if (lscore == score)
            {
                Debug.Log("Left Player wins!");
            }
            else
            {
                Debug.Log("Right Player wins!");
            }
        }
    }
}
