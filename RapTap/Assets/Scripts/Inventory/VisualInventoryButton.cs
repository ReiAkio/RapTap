using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualInventoryButton : MonoBehaviour
{
    public VisualItem visualItem;
    public GameObject redPanda;
    //teste serializacao
    public InventorySerialization inv;
    //

    /// <summary>
    /// Ao apertar o botão do inventário troca o sprite da imagem do panda vermelho
    /// </summary>
    public void ChangeVisualItem()
    {
        redPanda.gameObject.GetComponent<Animator>().runtimeAnimatorController = visualItem.image as RuntimeAnimatorController;
        redPanda.GetComponent<PlayerClickInteraction>().StopRapping();
        //serializacao
        inv.SetActive(visualItem.id);
    } 
}
