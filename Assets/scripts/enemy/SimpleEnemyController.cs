using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour {

  public SimpleEnemyStatsSO settings;

  private HealthController enemyHealth;
  private StaggerController stagger;
  private CharacterEventController enemyEventController;


  void Awake ()
  {
    enemyEventController = gameObject.GetComponent<CharacterEventController>();
  }


	void Start ()
  {
    enemyEventController.kill += OnKill;
    enemyEventController.stagger += OnStagger;
    enemyEventController.staggerEnd += OnStaggerEnd;

		enemyHealth = gameObject.GetComponent<HealthController>();
    stagger = gameObject.GetComponent<StaggerController>();
	}


  void OnMouseDown ()
  {
    enemyEventController.ReceiveDamage(10f);
    enemyEventController.ReceiveStagger(50f);
  }


  private void OnKill ()
  {
    Debug.Log("You killed the CacoDemon");
    gameObject.SetActive(false);
  }


  private void OnStagger () {
    Debug.Log("Enemy Staggered");
  }


  private void OnStaggerEnd () {
    Debug.Log("Stagger Ends");
  }
}
