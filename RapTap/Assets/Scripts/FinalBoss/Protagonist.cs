using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit detected");
        GameObject e = Instantiate(Explosion) as GameObject;
        e.transform.position = transform.position;
        Destroy(other.gameObject);
    }
    /* this.gameObject.SetActive(false); */
}
