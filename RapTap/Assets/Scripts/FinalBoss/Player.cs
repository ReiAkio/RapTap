using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 start;
    private Vector3 end;
    private float swipeDistance;
    private int activePos;
    public GameObject Explosion;
    public GameObject parent;

    void Start()
    {
        swipeDistance = 200;
        activePos = 0;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit detected");
        Instantiate(Explosion, this.transform.position, Quaternion.identity, parent.transform);
        Destroy(other.gameObject);
    }


    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                start = touch.position;
                end = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                end = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                end = touch.position;
                if ((end.x - start.x > swipeDistance) && activePos < 1)
                {
                    MovePlayer(GetComponent<Transform>(), 1);
                }
                else if ((end.x - start.x < -swipeDistance) && activePos > -1)
                {
                    MovePlayer(GetComponent<Transform>(), -1);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > 540 && activePos < 1)
            {
                MovePlayer(GetComponent<Transform>(), 1);
                Debug.Log("right");
            }
            else if (Input.mousePosition.x < 540 && activePos > -1)
            {
                MovePlayer(GetComponent<Transform>(), -1);
                Debug.Log("left");
            }
        }
    }

    private void MovePlayer(Transform player, int i)
    {
        player.position += Vector3.right * 270 * i;
        activePos += i;
    }

}
