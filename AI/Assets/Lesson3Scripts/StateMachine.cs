using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachinee : MonoBehaviour
{
    public Dictionary<Type, BaseState> states { get; private set; }
    public BaseState currentState { get; private set; }

    private void Update()
    {
        if(currentState == null)
            SwitchToNewState(states.Values.First().GetType());
        
        var nextState = currentState?.Tick();
        if (nextState != null && nextState!= currentState?.GetType())
            SwitchToNewState(nextState);
    }

    private void SwitchToNewState(Type nextState)
    {
        BaseState oldState = currentState;
        BaseState newState = states[nextState];
        
        currentState?.OnExit(newState);
        currentState = newState;
        currentState?.OnEnter(oldState);
    }
}
