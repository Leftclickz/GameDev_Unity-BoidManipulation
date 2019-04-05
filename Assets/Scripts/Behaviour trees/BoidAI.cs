using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAI : BehaviorTree
{
    public float SpeedIncrementOnHit = 2.0f;
    public float TurnRateDecrementOnHit = 5.0f;
    private int  FlockMask;

    // Start is called before the first frame update
    void Start()
    {
        FlockMask = gameObject.layer;
        
        Sequence TreeRoot = new Sequence();
        Detect DetectNode = new Detect();
        Zap ZapNode = new Zap();
        DamageBoid DamageNode = new DamageBoid();
       
        TreeRoot.children.Add(DetectNode);
        TreeRoot.children.Add(ZapNode);
        TreeRoot.children.Add(DamageNode);

        Blackboard.Add("BoidTarget", null);
        Blackboard.Add("SpeedIncrement", SpeedIncrementOnHit);
        Blackboard.Add("TurnRateDecrement", TurnRateDecrementOnHit);
        Blackboard.Add("LayerMask", FlockMask);

        DetectNode.BoidKey = "BoidTarget";
        DetectNode.LayerKey = "LayerMask";
        ZapNode.BoidKey = "BoidTarget";
        DamageNode.BoidKey = "BoidTarget";
        DamageNode.SpeedKey = "SpeedIncrement";
        DamageNode.TurnRateKey = "TurnRateDecrement";

        TreeRoot.tree = this;
        DetectNode.tree = this;
        ZapNode.tree = this;
        DamageNode.tree = this;

        root = TreeRoot;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
