using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    public void BuyProduct(){
        if (click.getScore() >= visualItem.cost && aux == true)
        {
            click.RemoveScore(visualItem.cost);
            aux = false;
        }
    }
    
    public List<VisualItem> GetVisualItemList()
    {
        return VisualItemList;
    }
}
