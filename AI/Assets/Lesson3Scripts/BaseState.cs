using System;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.transform = gameObject.transform;
    }
    
    protected GameObject gameObject;
    protected Transform transform; //protected means its not public but the child class can access it

    public abstract Type Tick();
    public abstract void OnEnter(BaseState oldState);
    public abstract void OnExit(BaseState newState);
}
