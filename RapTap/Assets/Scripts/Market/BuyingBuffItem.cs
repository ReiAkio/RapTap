using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comprar Buff Itens dentro de um Botão
/// </summary>
public class BuyingBuffItem : MonoBehaviour
{
    public Clickable click;
    public BuffItem buffItem;
    private List<BuffItem> BuffItemList;
    private bool aux;

    private void Start()
    {
        aux = true;
    }

    /// <summary>
    /// Somente subtrai o valor do click 
    /// </summary>
    public void BuyProduct(){
        if (click.getScore() >= buffItem.cost && aux == true)
        {
            click.RemoveScore(buffItem.cost);
            aux = false;

        }
    }
    
    /// <summary>
    /// Get lista de buff
    /// </summary>
    /// <returns></returns>
    public List<BuffItem> GetBuffItemList()
    {
        return BuffItemList;
    }
}
