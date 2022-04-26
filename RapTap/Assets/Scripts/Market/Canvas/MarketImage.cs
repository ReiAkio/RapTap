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
    
}
