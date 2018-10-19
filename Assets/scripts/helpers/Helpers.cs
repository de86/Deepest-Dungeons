using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
  public static ChanceItem GetRandomItemFromList (List<ChanceItem> itemList)
  {
    int chanceTotal = 0;
    itemList.ForEach(i => { chanceTotal += i.chance; });

    int roll = new System.Random().Next(0, chanceTotal);
    
    ChanceItem item = itemList[0];

    for (int i = 0; i < itemList.Count; i++)
    {
      if (roll >= itemList[i].chance)
      {
        item = itemList[i];
      }
    }

    return item;
  }

}