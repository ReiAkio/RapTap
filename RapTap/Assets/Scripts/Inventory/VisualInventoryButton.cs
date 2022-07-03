using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualInventoryButton : MonoBehaviour
{
    public VisualItem visualItem;
    public GameObject redPanda;
    
    /// <summary>
    /// Ao apertar o botão do inventário troca o sprite da imagem do panda vermelho
    /// </summary>
    public void ChangeVisualItem()
    {
        redPanda.gameObject.GetComponent<Animator>().runtimeAnimatorController = visualItem.image as RuntimeAnimatorController;
    } 
}
