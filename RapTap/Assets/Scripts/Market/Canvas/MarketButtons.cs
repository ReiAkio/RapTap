using UnityEngine;

/// <summary>
/// Ação ao apertar os Botões presente na Cena
/// </summary>
public class MarketButtons : MonoBehaviour
{
    public void PressShop(GameObject thisImage)
    {
        thisImage.SetActive(true);
        thisImage.transform.SetAsLastSibling(); // Para 
    }
    
    public void PressInventory(GameObject thisImage)
    {
        thisImage.SetActive(true);
        thisImage.transform.SetAsLastSibling(); // Para 
    }
}
