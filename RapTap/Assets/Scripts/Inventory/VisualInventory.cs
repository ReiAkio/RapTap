using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adiciona os valores no inventário
/// </summary>
public class VisualInventory : MonoBehaviour
{
   [SerializeField]
   private List<VisualItem> VisualItemList;
   

   public void AddItem(VisualItem visualItem)
   {  
      VisualItemList.Add(visualItem);
   }
}
