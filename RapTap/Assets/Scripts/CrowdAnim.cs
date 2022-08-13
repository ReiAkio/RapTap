using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnim : MonoBehaviour
{
    [SerializeField] private float animationOffset;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().Play("Crowd_Movement", 0, animationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
