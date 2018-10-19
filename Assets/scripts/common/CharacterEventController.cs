using UnityEngine;

public class CharacterEventController : MonoBehaviour {

  public delegate void __ReceiveDamage (float attackVal);
  public event  __ReceiveDamage receiveDamage;

  public void ReceiveDamage (float attackVal)
  {
    if (receiveDamage != null)
    {
      receiveDamage(attackVal);
    }
  }

  public delegate void __ReceiveStagger (float staggerkVal);
  public event  __ReceiveStagger receiveStagger;

  public void ReceiveStagger (float staggerVal)
  {
    if (receiveStagger != null)
    {
      receiveStagger(staggerVal);
    }
  }

  public delegate void __Stagger();
  public event  __Stagger stagger;

  public void Stagger ()
  {
    if (stagger != null)
    {
      stagger();
    }
  }


  public delegate void __StaggerEnd();
  public event  __StaggerEnd staggerEnd;

  public void StaggerEnd ()
  {
    if (staggerEnd != null)
    {
      staggerEnd();
    }
  }


  public delegate void __Kill ();
  public event  __Kill kill;

  public void Kill ()
  {
    if (kill != null)
    {
      kill ();
    }
  }

}