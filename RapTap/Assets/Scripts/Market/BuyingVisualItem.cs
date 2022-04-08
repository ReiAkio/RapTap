using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comprar Buff Itens dentro de um Botão
/// </summary>
public class BuyingVisualItem : MonoBehaviour
{
    public Clickable click;
    public VisualItem visualItem;
    private List<VisualItem> VisualItemList;
    private bool aux;
    
    private void Start()
    {
        aux = true;
    }
    
    /// <summary>
    /// Somente subtrai o valor do click 
    /// </summary>
    public void BuyProduct(){
        if (click.getScore() >= visualItem.cost && aux == true)
        {
            click.RemoveScore(visualItem.cost);
            aux = false;
        }
    }
    
    /// <summary>
    /// Get lista de visual
    /// </summary>
    /// <returns></returns>
    public List<VisualItem> GetVisualItemList()
    {
        return VisualItemList;
    }
}
