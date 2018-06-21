using System;
using System.Collections.Generic;

//Data of player
[Serializable]
public class PlayerData
{
    public int currentLevel;                    //Record max level that player can access
    public List<int> passedLevelScore;          //Record scores of every level that player passed

    //Initialize when create player data instance
    public PlayerData()
    {
        currentLevel = 1;
        passedLevelScore = new List<int>();
    }

    //Set max level that player can access
    public void setCurrentLevel(int level)
    {
        currentLevel = level;
    }

    //Get max level that player can access
    public int getCurrentLevel()
    {
        return currentLevel;
    }

    //Set scores of the level that player passed
    public void SetScore(int score,int level)
    {
        //if it's menu scene, do not need to record
        if (level <= 0)
        {
            return;
        }
        //If it wasn't recorded before, record the score
        if (passedLevelScore.Count < level)
        {
            passedLevelScore.Add(score);
        }
        //If it has been recorded before, modify the score
        else
        {
            //If the previous score is less than this time, modify it to this one
            if (score > passedLevelScore[level-1])
            {
                passedLevelScore[level - 1] = score;
            }
        }
    }

    //Clean the list
    public void Clean()
    {
        passedLevelScore.Clear();
        currentLevel = 1;
    }
}
