using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : Task
{

    public string BoidKey;

    // Use this for initialization
    public override void Reset()
    {
        
    }

    // Update is called once per frame
    public override NodeResult Execute()
    {
        GameObject Boid = (GameObject)(tree.GetValue(BoidKey));
        LineRenderer render = tree.gameObject.GetComponent<LineRenderer>();

        if (Boid != null)
        {
            Vector3 point1 = Boid.transform.position;
            Vector3 point2 = tree.gameObject.transform.position;

            render.positionCount = 2;
            render.SetPosition(0, point1);
            render.SetPosition(1, point2);

            render.enabled = true;
        }
        else
        {
            render.enabled = false;
        }


        return NodeResult.SUCCESS;
    }
}
