using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour {
  
  public List<EnemyAttackDef> Attacks;

  [SerializeField]
  private float minAttackCooldown;

  private enum AttackState 
  {
    Attacking,
    Waiting
  }
  private AttackState state = AttackState.Attacking;

	
  void Start ()
  {
    
  }

	// Update is called once per frame
	void Update ()
  {
		switch (state)
    {
      case AttackState.Attacking:
        ChooseAttack();
        break;

      default:
        break;
    }
	}


  private void ChooseAttack ()
  {
    List<ChanceItem> AvailableAttacks = GetAvailableAttacks().ConvertAll( enemyAttack => (ChanceItem) enemyAttack );

    if ( AvailableAttacks.Count > 0 )
    {
      EnemyAttackDef chosenAttack = (EnemyAttackDef)Helpers.GetRandomItemFromList(AvailableAttacks);
      chosenAttack.Attack();
      StartCoroutine(Wait(minAttackCooldown));
    } 
  }


  private List<EnemyAttackDef> GetAvailableAttacks ()
  {
    List<EnemyAttackDef> AvailableAttacks = new List<EnemyAttackDef>();
    Attacks.ForEach( Attack => { if ( Attack.GetIsReady()) AvailableAttacks.Add(Attack); });

    return AvailableAttacks;
  }


  private IEnumerator Wait (float waitTime)
  {
    state = AttackState.Waiting;

    yield return new WaitForSeconds(waitTime);

    state = AttackState.Attacking;
  }

}
