using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWarning : MonoBehaviour
{
    // Start is called before the first frame update
    public void ActivateWarning()
    {
        gameObject.GetComponent<Animator>().SetBool("EnableClaw", false);
        transform.parent.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        StartCoroutine(ActivateVersusSign());
    }

    IEnumerator ActivateVersusSign()
    {
        yield return new WaitForSeconds(1);
        transform.parent.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
