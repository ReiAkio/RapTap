using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketButtons : MonoBehaviour
{
    public void PressButton(GameObject thisImage)
    {
        thisImage.SetActive(true);
        thisImage.transform.SetAsLastSibling();
    }
}
