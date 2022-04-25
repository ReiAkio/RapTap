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
    public VisualInventory visualInventory;
    [Header("O GAMEOBJECT DO PRODUTO PRESENTE NA CENA")]
    public GameObject visualProduct;
    private bool aux;

    private void Awake()
    {
        aux = true;
        visualProduct.SetActive(false);
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
            Inventory();
        }

        if (aux == false)
        {
            visualProduct.gameObject.GetComponent<Image>().sprite = visualItem.image;
        }

    }

    private void Inventory()
    {
        visualInventory.AddItem(visualItem);
        visualProduct.SetActive(true);
        visualProduct.gameObject.GetComponent<Image>().sprite = visualItem.image;
    }
    
    
}
