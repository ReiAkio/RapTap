using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Comprar Buff Itens dentro de um Botão
/// </summary>
public class BuyingBuffItem : MonoBehaviour
{
    public Clickable click;
    public BuffItem buffItem;
    private bool aux;
    
    [SerializeField]
    private int sumScore;

    private void Start()
    {
        aux = true;
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
            this.gameObject.GetComponent<Image>().color = Color.grey;

        }
    }
    
    private void BuffAction()
    {
        sumScore = buffItem.buffClick + click.getClick();
        click.setClick(sumScore);
    }
}
