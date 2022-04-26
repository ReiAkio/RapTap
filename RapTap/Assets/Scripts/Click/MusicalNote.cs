using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalNote : MonoBehaviour
{
    private float velX;
    private float velY;

    // Start is called before the first frame update
    void Start()
    {
        velX = Random.Range(-700f,-100f);
        velY = Random.Range(300f, 600f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velX * Time.deltaTime, velY * Time.deltaTime, 0);
        if(transform.position.x < -47)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 1980)
        {
            Destroy(gameObject);
        }
    }
}
