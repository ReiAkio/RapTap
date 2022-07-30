using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Comprar Buff Itens dentro de um Botão
/// </summary>
public class BuyingBuffItem : MonoBehaviour
{
    //teste serializacao
    public InventorySerialization inv;
    //

    public Clickable click;
    public BuffItem buffItem;
    private bool aux;
    
    [SerializeField]
    private int sumScore;

    private void Start()
    {
        aux = true;

        //teste serializacao
        aux = !inv.buffItems[buffItem.id];
        if(!aux)
            this.gameObject.GetComponent<Image>().color = Color.grey;
        //
    }



    /// <summary>
    /// Somente subtrai o valor do click e muda a cor para cinza
    /// </summary>
    public void BuyProduct(){
        if (click.getScore() >= buffItem.cost && aux == true)
        {
            click.RemoveScore(buffItem.cost);
            BuffAction();
            aux = false;
            //teste serializacao
            inv.OnBuyBuff(buffItem.id, !aux);
            //
            this.gameObject.GetComponent<Image>().color = Color.grey;

        }
    }
    
    /// <summary>
    /// Soma o valor do apertado pelo click e soma com o valor do buff
    /// </summary>
    private void BuffAction()
    {
        sumScore = buffItem.buffClick + click.getClick();
        click.setClick(sumScore);
    }
}
