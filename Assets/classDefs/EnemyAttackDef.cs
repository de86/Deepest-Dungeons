using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class EnemyAttackDef : ChanceItem
{
  public string name;
  public float attackPower;
  public float cooldown;

  [SerializeField]
  private bool isReady = true;

  public void Attack ()
  {
    BattleEventController.PlayerHit(attackPower);
    isReady = false;
    BeginCooldown();
  }


  public bool GetIsReady ()
  {
    return isReady;
  }


  private async Task BeginCooldown ()
  {
    await Task.Delay((int)(cooldown * 1000));
    isReady = true;
  }

}