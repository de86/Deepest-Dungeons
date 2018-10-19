using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  private HealthController playerHealth;


  void Awake () {
    this.playerHealth = gameObject.GetComponent<HealthController>();
  }
  
}
