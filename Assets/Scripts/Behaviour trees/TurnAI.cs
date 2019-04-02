using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAI : BehaviorTree
{
    public float timeToWait = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        SwarmLeaderAI leaderAI = GetComponentInParent<SwarmLeaderAI>();

        Selector TreeRoot = new Selector();
        Sequence Turn = new Sequence();
        Wait wait = new Wait();
        RequestTurn requestTurn = new RequestTurn();

        SetValue("SwarmLeaderAI", leaderAI);
        SetValue("TimeToWait", timeToWait);

        requestTurn.leaderAIKey = "SwarmLeaderAI";

        wait.TimeToWaitKey = "TimeToWait";

        Turn.children.Add(wait);
        Turn.children.Add(requestTurn);
        TreeRoot.children.Add(Turn);
        TreeRoot.tree = this;
        Turn.tree = this;
        wait.tree = this;
        requestTurn.tree = this;
        root = TreeRoot;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
