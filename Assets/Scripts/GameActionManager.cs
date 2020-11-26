using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameActionManager : MonoBehaviour
{
    private Stack<GameAction> actionStack;
    private GameAction activeAction;

    private void Awake()
    {
        actionStack = new Stack<GameAction>();
        Services.GameActionManager = this;
    }

    public void AddAction(GameAction gameAction)
    {
        actionStack.Push(gameAction);
    }

    private void ProcessActions()
    {
        if(activeAction != null)
        {
            if(activeAction.CurrentStatus == GameAction.Status.Complete)
            {
                activeAction = null;
            }
        }
        else if(actionStack.Count > 0)
        {
            activeAction = actionStack.Pop();
            activeAction.Execute();
            if(activeAction.CurrentStatus == GameAction.Status.Complete)
            {
                activeAction = null;
                ProcessActions();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessActions();
    }
}
