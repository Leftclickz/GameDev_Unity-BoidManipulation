using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmLeaderAI : BehaviorTree
{
    public Catmul catmul;
    public TrackManager trackManager;
    public int trackIndex;
    // Start is called before the first frame update
    void Start()
    {
        Selector TreeRoot = new Selector();
        Sequence TrackRace = new Sequence();
        SelectNextGameObject SelectNextPoint = new SelectNextGameObject();
        MoveTo MoveToObject = new MoveTo();
        PlayerChangeLane ChangeLange = new PlayerChangeLane();

        SetValue("Catmul", catmul.sp);
        SetValue("CurrentPoint", catmul.sp[0]);
        SetValue("CurrentPointIndex", 0);
        //Default is going forwards along the path
        SetValue("Direction", 1);
        SetValue("TrackManager", trackManager);
        SetValue("TrackIndex", trackIndex);
        SetValue("TurnRequested", Turning.STRAIGHT);

        SetValue("Speed", 5.0f);
        SetValue("TurnSpeed", 2.0f);
        SetValue("Accuracy", 1.5f);

        SelectNextPoint.ArrayKey = "Catmul";
        SelectNextPoint.GameObjectKey = "CurrentPoint";
        SelectNextPoint.IndexKey = "CurrentPointIndex";
        SelectNextPoint.DirectionKey = "Direction";
        MoveToObject.TargetName = "CurrentPoint";
        ChangeLange.IndexKey = "CurrentPointIndex";
        ChangeLange.GameObjectKey = "CurrentPoint";
        ChangeLange.ArrayKey = "Catmul";

        TrackRace.children.Add(SelectNextPoint);
        TrackRace.children.Add(MoveToObject);
        TrackRace.children.Add(ChangeLange);
        TreeRoot.children.Add(TrackRace);
        TrackRace.tree = this;
        SelectNextPoint.tree = this;
        MoveToObject.tree = this;
        ChangeLange.tree = this;
        TreeRoot.tree = this;
        root = TreeRoot;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
