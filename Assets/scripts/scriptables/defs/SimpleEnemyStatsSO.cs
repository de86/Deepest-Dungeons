using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new SimpleEnemyStatsSO", menuName = "Enemy/SimpleEnemyStatsSO")]
public class SimpleEnemyStatsSO : ScriptableObject {

  [SerializeField]
	private float health;
  private float stagger;
  [SerializeField]
  private float staggerLimit;
  [SerializeField]
  private float staggerTime;
  [SerializeField]
  private float attack;
  [SerializeField]
  private float mana;

  public int adsfaf;

  public float GetHealth ()
  {
    return health;
  }
  public void SetHealth ( float newHealth )
  { 
    health += newHealth;
  }


  public float GetStagger ()
  {
    return stagger;
  }
  public void SetStagger ( float newStagger )
  { 
    stagger += newStagger;
  }
  public void ResetStagger ()
  { 
    stagger = 0;
  }


  public float GetStaggerLimit ()
  {
    return staggerLimit;
  }


  public float GetStaggerTime ()
  {
    return staggerTime;
  }


  public float GetAttack ()
  {
    return attack;
  }


  public float GetMana ()
  {
    return mana;
  }
  public void SetMana ( float newMana )
  {
    mana += newMana;
  }
}
