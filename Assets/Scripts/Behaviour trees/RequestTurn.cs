using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestTurn : Task
{
    public string leaderAIKey;

    public override NodeResult Execute()
    {
        int direction = Random.Range(0, 3);
        Turning newTurn = Turning.STRAIGHT;
        switch(direction)
        {
            case 0:
                {
                    newTurn = Turning.STRAIGHT;
                    break;
                }
            case 1:
                {
                    newTurn = Turning.LEFT;
                    break;
                }
            case 2:
                {
                    newTurn = Turning.RIGHT;
                    break;
                }
        }
        SwarmLeaderAI leaderAI = (SwarmLeaderAI)tree.GetValue(leaderAIKey);
        leaderAI.SetValue("TurnRequested", newTurn);
        return NodeResult.SUCCESS;
    }

    public override void Reset()
    {
    }
}
