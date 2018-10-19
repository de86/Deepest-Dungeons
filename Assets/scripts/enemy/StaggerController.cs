using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerController : MonoBehaviour {
  
  [SerializeField]
  private float staggerTime;
  [SerializeField]
  private float staggerLimit;
  
  public bool isStaggered { get; private set; }
  public FloatSO stagger;

  private CharacterEventController enemyEventController;


  void Awake ()
  {
    enemyEventController = gameObject.GetComponent<CharacterEventController>();

    enemyEventController.receiveStagger += OnReceiveStagger;
  }

  void Start ()
  {
    stagger.val = 0;
  }


  private void OnReceiveStagger (float staggerAmount)
  {
    ModifyStagger(staggerAmount);
  }


  public void ModifyStagger (float staggerAmount)
  {
    if ( !isStaggered )
    {
      stagger.val += staggerAmount;

      if ( stagger.val >= staggerLimit )
      {
        StartCoroutine(Stagger());
      }
    }
  }


  private void ResetStagger ()
  {
    isStaggered = false;
    stagger.val = 0;
    enemyEventController.StaggerEnd();
  }


  private IEnumerator Stagger()
  {
    isStaggered = true;
    BattleEventController.EnemyStaggered();
    enemyEventController.Stagger();

    yield return new WaitForSeconds(staggerTime);

    ResetStagger();
  }

}
