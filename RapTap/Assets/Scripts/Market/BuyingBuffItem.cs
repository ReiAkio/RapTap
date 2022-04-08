using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void BuyProduct(){
        if (click.getScore() >= buffItem.cost && aux == true)
        {
            click.RemoveScore(buffItem.cost);
            aux = false;

        }
    }
    
    public List<BuffItem> GetBuffItemList()
    {
        return BuffItemList;
    }
}
