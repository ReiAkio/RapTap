using UnityEngine;

public class MarketImage : MonoBehaviour
{
    void Start()
    {
        SetActiveFalse();
    }
    
    /// <summary>
    /// esse gameobject não está presente na tela - usado para sair quando chama a interface e quando comeca a cena
    /// </summary>
    public void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Trocar as interfaces de buff e visual na tela
    /// </summary>
    /// <param name="thisImage"></param>
    public void Changeimg(GameObject thisImage)
        {
            thisImage.SetActive(true);
            thisImage.transform.SetAsLastSibling();// Para 
            thisImage.transform.parent.GetChild(0).gameObject.SetActive(false);
        }
    
}
