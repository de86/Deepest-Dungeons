using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

  public float initialHealth;

  [SerializeField]
  private SimpleEnemyStatsSO stats;
  private CharacterEventController enemyEventController;

  void Awake ()
  {

    enemyEventController = gameObject.GetComponent<CharacterEventController>();
    enemyEventController.receiveDamage += OnReceiveHit;
  }


  void Start ()
  {
    stats.SetHealth(initialHealth);
  }


  private void ModifyHealth (float increment)
  {
    stats.SetHealth(stats.GetHealth() + increment);
  }


  public float GetHealth ()
  {
    return stats.GetHealth();
  }


  public bool GetIsAlive ()
  {
    return stats.GetHealth() > 0;
  }


  private void OnReceiveHit (float damage)
  {
    ModifyHealth(-damage);
    float newHealth = stats.GetHealth();
    Debug.Log("Enemy Hit: " + GetHealth());

    if (newHealth < 1) {
      enemyEventController.Kill();
    }
  }

}
