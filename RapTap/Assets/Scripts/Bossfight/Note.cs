using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed;
    public GameObject player;

    private Rigidbody2D _rb;
    private Vector2 _screenBounds;

    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0, -speed);
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (transform.position.y < -_screenBounds.y * 2 && gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}

