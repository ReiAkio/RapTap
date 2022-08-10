using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWarning : MonoBehaviour
{
    // Start is called before the first frame update
    public void ActivateWarning()
    {
        transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("EnableClaw", true);
    }
}
