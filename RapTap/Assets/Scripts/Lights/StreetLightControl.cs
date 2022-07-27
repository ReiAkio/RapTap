using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLightControl : MonoBehaviour
{
    [SerializeField] private GameObject streetLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TurnOffLight()
    {
        streetLight.SetActive(false);
    }

    void TurnOnLight()
    {
        streetLight.SetActive(true);
    }
}
