using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickInteraction : MonoBehaviour
{
    public GameObject crowd;
    public GameObject enemy;
    public GameObject musicalNote1;
    public GameObject musicalNote2;

    private int playerDisplacement;
    private int crowdDisplacement;
    private int enemyHealth = 20;
    private Vector3 musicSpawnPos = new Vector3(620, 590, 0);
    private Animator EnemyAnimation;

    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimation = enemy.transform.GetChild(0).gameObject.GetComponent<Animator>();
        EnemyAnimation.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Clickable.MouseDown += playerMouseDown;
        Clickable.MouseUp += playerMouseUp;
    }


    void OnDisable()
    {
        Clickable.MouseDown -= playerMouseDown;
        Clickable.MouseUp -= playerMouseUp;
    }

    void playerMouseDown ()
    {
        playerDisplacement = Random.Range(2, 7);
        crowdDisplacement = Random.Range(3, 6);
        transform.position = new Vector2(transform.position.x + playerDisplacement, transform.position.y + (playerDisplacement - 2));
        transform.localScale = transform.localScale / 1.02f;
        crowd.transform.position = new Vector2(crowd.transform.position.x, crowd.transform.position.y + crowdDisplacement);
        enemy.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y + crowdDisplacement);
        enemyHealth -= 1;
        if (Random.Range(0, 2) == 1)
        {
            Instantiate(musicalNote1, musicSpawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(musicalNote2, musicSpawnPos, Quaternion.identity);
        }

    }

    void playerMouseUp ()
    {
        transform.position = new Vector2(transform.position.x - playerDisplacement, transform.position.y - (playerDisplacement - 2));
        transform.localScale = transform.localScale * 1.02f;
        crowd.transform.position = new Vector2(crowd.transform.position.x, crowd.transform.position.y - crowdDisplacement);
        enemy.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y - crowdDisplacement);

        if (enemyHealth <= 0)
        {
            EnemyAnimation.speed = 1.5f;
            enemyHealth = 20;
        }
    }

}
