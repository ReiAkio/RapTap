using UnityEngine;

/// <summary>
/// Ação ao apertar os Botões presente na Cena
/// </summary>
public class MarketButtons : MonoBehaviour
{

    public void PressButtonInventory(GameObject thisImage)
    {
        thisImage.SetActive(true);
        thisImage.transform.SetAsLastSibling();// Para 
        thisImage.transform.parent.GetChild(0).gameObject.SetActive(false);
        
    }
    
    public void PressButtonShop(GameObject thisImage)
    {
        thisImage.SetActive(true);
        thisImage.transform.SetAsLastSibling();// Para 
        thisImage.transform.parent.GetChild(0).gameObject.SetActive(false);
        thisImage.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        thisImage.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
