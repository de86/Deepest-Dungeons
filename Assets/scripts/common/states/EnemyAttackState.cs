using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State {

  public EnemyAttackState ( StateMachine state ) : base( state ) {}

  private EnemyAttackController attackController;

  public override void OnStateEnter ()
  {
    attackController = stateMachine.gameObject.GetComponent<EnemyAttackController>();
  }

  public override void Tick ()
  {
    if ( attackController != null )
    {
      attackController.Tick();
    }
    else
    {
      Debug.Log("Enemy Attack Controller Not Found");
    }
  }

  public override void OnStateExit ()
  {}

}
