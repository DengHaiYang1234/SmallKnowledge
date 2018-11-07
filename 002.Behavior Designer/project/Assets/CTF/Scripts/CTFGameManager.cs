using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class CTFGameManager : MonoBehaviour
{
    private static CTFGameManager _instance;

    public static CTFGameManager Instance
    {
        get { return _instance; }
    }

    private List<BehaviorTree> flagNotTakenBehaviorTrees = new List<BehaviorTree>();

    private List<BehaviorTree> flagTakenBehaviorTrees = new List<BehaviorTree>();

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        BehaviorTree[] bts = FindObjectsOfType<BehaviorTree>();
        foreach (var bt in bts)
        {
            if (bt.Group == 1)
                flagNotTakenBehaviorTrees.Add(bt);
            else
                flagTakenBehaviorTrees.Add(bt);
        }
    }

    public void TakenFlag()
    {
        foreach (var bt in flagNotTakenBehaviorTrees)
        {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt))
                bt.DisableBehavior();
        }

        foreach (var bt in flagTakenBehaviorTrees)
        {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt) == false)
                bt.EnableBehavior();
        }
            
    }

    public void DropFlag()
    {
        foreach (var bt in flagNotTakenBehaviorTrees)
        {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt) == false)
                bt.EnableBehavior();
        }

        foreach (var bt in flagTakenBehaviorTrees)
        {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt))
                bt.DisableBehavior();
        }
    }


}
