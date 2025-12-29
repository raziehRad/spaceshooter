using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField]private int maxHp=5;
   private int currentHp;
   private void Start()
   {
      currentHp=maxHp;
   }

  
   public void TakeDamage(int value)
   {
      currentHp-=value;
      if  (currentHp <=0)
      {
          GameManager.Instance.HUDManager.ActiveLosePanel();
      }
      GameManager.Instance.HUDManager.SetHp(currentHp);
   }
   public void SetHealth()
   {
      GameManager.Instance.HUDManager.SetHp(currentHp);
   }
}
