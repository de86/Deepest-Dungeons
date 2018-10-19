using UnityEngine;

public static class BattleEventController {

  public delegate void __PlayerHit(float attackVal);
  public static event  __PlayerHit playerHit;

  public static void PlayerHit (float attackVal)
  {
    if (playerHit != null)
    {
      playerHit(attackVal);
    }
  }

  public delegate void __EnemyStaggered();
  public static event  __EnemyStaggered enemyStaggered;

  public static void EnemyStaggered ()
  {
    if (enemyStaggered != null)
    {
      enemyStaggered();
    }
  }

}