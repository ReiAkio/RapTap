using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartClaw : MonoBehaviour
{
    // Start is called before the first frame update

    public void ActivateClaw()
    {
        transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("EnableClaw",true);
    }
}
