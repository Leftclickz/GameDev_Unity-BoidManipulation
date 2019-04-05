using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoid : Task
{

    public string BoidKey;
    public string SpeedKey;
    public string TurnRateKey;

    // Use this for initialization
    public override void Reset()
    {

    }

    // Update is called once per frame
    public override NodeResult Execute()
    {
        GameObject BoidObj = (GameObject)(tree.GetValue(BoidKey));
        if (BoidObj != null)
        {
            Boid AILogic = BoidObj.GetComponent<Boid>();

            AILogic.speed += (float)(tree.GetValue(SpeedKey));
            AILogic.turnspeed -= (float)(tree.GetValue(TurnRateKey));
        }

        return NodeResult.SUCCESS;
    }
}
