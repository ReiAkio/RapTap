using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
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

    public Sprite[] sprite;

    private void Awake()
    {
        aux = true;
        visualProduct.SetActive(true);
    }
    
    /// <summary>
    /// Permite a compra do produto e trocar o produto quando quiser
    /// </summary>
    public void BuyProduct(){
        // Somente subtrai o valor do click, muda a cor para cinza e adiciona na lista do inventário
        if (click.getScore() >= visualItem.cost && aux == true)
        {
            click.RemoveScore(visualItem.cost);
            aux = false;
            this.gameObject.GetComponent<Image>().color = Color.grey;
            Inventory();
        }

        // Quando quer trocar de produto, troca a imagem dele
        if (aux == false)
        {
            visualProduct.gameObject.GetComponent<Image>().sprite = visualItem.image;
        }

    }

    /// <summary>
    /// Adiciona os valores no inventário e troca a imagem do produto
    /// </summary>
    private void Inventory()
    {
        visualInventory.AddItem(visualItem);
        visualProduct.SetActive(true);
        visualProduct.gameObject.GetComponent<Image>().sprite = visualItem.image;
    }
    
    
}
