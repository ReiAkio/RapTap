using System.Collections.Generic;
using UnityEngine;

public class VisualInventory : MonoBehaviour
{
   [SerializeField]
   private List<VisualItem> VisualItemList;
   

   public void AddItem(VisualItem visualItem)
   {  
      VisualItemList.Add(visualItem);
   }
}
