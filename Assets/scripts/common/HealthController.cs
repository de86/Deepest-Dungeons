using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

  [SerializeField]
  private FloatSO health;
  
  private CharacterEventController enemyEventController;

  public float initialHealth;


  void Awake ()
  {
    enemyEventController = gameObject.GetComponent<CharacterEventController>();
    enemyEventController.receiveDamage += OnReceiveHit;
  }


  void Start ()
  {
    health.val = initialHealth;
  }


  private void SetHealth (float initialHealth)
  {
    this.health.val = initialHealth;
  }


  private void ModifyHealth (float increment)
  {
    this.health.val += increment;
  }


  public float GetHealth ()
  {
    return this.health.val;
  }


  public bool GetIsAlive ()
  {
    return this.health.val > 0;
  }


  private void OnReceiveHit (float damage)
  {
    this.health.val -= damage;
    Debug.Log("Enemy Hit: " + this.health.val);

    if (this.health.val < 1) {
      enemyEventController.Kill();
    }
  }

}
