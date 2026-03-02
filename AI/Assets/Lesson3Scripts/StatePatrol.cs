using System;
using UnityEngine;

public class StatePatrol : BaseState
{
    private readonly StateMachinee _owner;
    
    public StatePatrol(StateMachinee owner) : base(owner.gameObject){
        _owner = owner;
    }
    
    //runs every frame
    public override Type Tick(){
        return null;
    }
    
    //runs when we enter this state
    public override void OnEnter(BaseState oldState){
    
    }
    
    //runs when we exit this state
    public override void OnExit(BaseState newState){
    
    }
}
