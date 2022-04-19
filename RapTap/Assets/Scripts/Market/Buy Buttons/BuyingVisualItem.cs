using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// Somente subtrai o valor do click e muda a cor para cinza
    /// </summary>
    public void BuyProduct(){
        if (click.getScore() >= visualItem.cost && aux == true)
        {
            click.RemoveScore(visualItem.cost);
            aux = false;
            this.gameObject.GetComponent<Image>().color = Color.grey;
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
