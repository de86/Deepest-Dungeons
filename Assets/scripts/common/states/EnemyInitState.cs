using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitState : State {

  public EnemyInitState (StateMachine state) : base( state ) {}

	public override void Tick ()
  {
    Debug.Log("Initializing Enemy");
  }


  public override void OnStateEnter ()
  {
    Debug.Log("Entering State");
  }


  public override void OnStateExit ()
  {
    Debug.Log("Exiting State");
    stateMachine.SetState( new EnemyAttackState( stateMachine ) );
  }

}
