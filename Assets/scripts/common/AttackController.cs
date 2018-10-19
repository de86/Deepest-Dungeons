using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

  [SerializeField]
  private FloatSO Attack;


  public void SetAttack (int newAttackVal)
  {
    this.Attack.val += newAttackVal;
  }


  public float GetAttack ()
  {
    return this.Attack.val;
  }

}
