using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderAI : MonoBehaviour
{
    public SwarmLeaderAI leaderAI;
    // Start is called before the first frame update
    void Start()
    {
        leaderAI = GetComponentInParent<SwarmLeaderAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leaderAI.SetValue("TurnRequested", Turning.LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            leaderAI.SetValue("TurnRequested", Turning.RIGHT);
        }
    }
}
