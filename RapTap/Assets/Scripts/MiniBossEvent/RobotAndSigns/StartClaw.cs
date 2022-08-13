using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartClaw : MonoBehaviour
{

    public void RetrieveClaw()
    {
        transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("EnableClaw", true);
        transform.GetChild(2).gameObject.GetComponent<Animator>().SetBool("Warning", true);
    }
}
