using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerController : MonoBehaviour {
  
  public bool isStaggered { get; private set; }

  [SerializeField]
  private SimpleEnemyStatsSO stats;
  private CharacterEventController enemyEventController;


  void Awake ()
  {
    enemyEventController = gameObject.GetComponent<CharacterEventController>();

    enemyEventController.receiveStagger += OnReceiveStagger;
  }

  void Start ()
  {
    stats.ResetStagger();
  }


  private void OnReceiveStagger (float staggerAmount)
  {
    ModifyStagger(staggerAmount);
  }


  public void ModifyStagger (float staggerAmount)
  {
    if ( !isStaggered )
    {
      float currentStagger = stats.GetStagger();
      stats.SetStagger(currentStagger + staggerAmount);

      if ( currentStagger >= stats.GetStaggerLimit() )
      {
        StartCoroutine(Stagger());
      }
    }
  }


  private void ResetStagger ()
  {
    isStaggered = false;
    stats.ResetStagger();
    enemyEventController.StaggerEnd();
  }


  private IEnumerator Stagger()
  {
    isStaggered = true;
    BattleEventController.EnemyStaggered();
    enemyEventController.Stagger();

    yield return new WaitForSeconds(stats.GetStaggerTime());

    ResetStagger();
  }

}
