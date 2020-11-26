using UnityEngine;
using System.Collections;

public class GameAction 
{
    public enum Status { Ready, InProgress, Complete }
    public Status CurrentStatus { get; protected set; }

    public GameAction()
    {
        CurrentStatus = Status.Ready;
    }

    public virtual void Execute()
    {
        CurrentStatus = Status.InProgress;
    }
}
