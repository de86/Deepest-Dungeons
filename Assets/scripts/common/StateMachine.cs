﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

  private State currentState;

	private void Start () {
		SetState(new EnemyInitState(this));
	}
	
	
	private void Update () {
		currentState.Tick();
	}


  public void SetState(State state) {
    if (currentState != null)
    {
      currentState.OnStateExit();
    }

    currentState = state;

    if (currentState != null)
    {
      currentState.OnStateEnter();
    }
  }
}
