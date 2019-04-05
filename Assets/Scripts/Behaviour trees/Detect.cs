using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : Task
{

    public string BoidKey;
    public string LayerKey;

    // Use this for initialization
    public override void Reset()
    {
   
    }

    // Update is called once per frame
    public override NodeResult Execute()
    {
        Transform objtransform = tree.gameObject.transform;
        //layer mask of our boids, we'll flip this to go against all other masks.
        int layermask = 1 << (int)(tree.GetValue(LayerKey));

        RaycastHit hit;
        if (Physics.Raycast(objtransform.position, objtransform.forward, out hit, 20.0f, ~layermask))
        {
            GameObject Collision = hit.collider.gameObject;

            if (Collision.name.Contains("ConePrefab"))
            {
                tree.SetValue(BoidKey, Collision);
            }
            else
            {
                tree.SetValue(BoidKey, null);
            }
        }
        else
        {
            tree.SetValue(BoidKey, null);
        }
            return NodeResult.SUCCESS;
    }
}
