using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonSystem : MonoBehaviour
{
    public void ExitButton()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
