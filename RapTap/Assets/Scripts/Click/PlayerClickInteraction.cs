using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickInteraction : MonoBehaviour
{
    public GameObject crowd;
    public GameObject enemy;
    public GameObject musicalNote1;
    public GameObject musicalNote2;

    private Animator PlayerAnimator;
    private Animator EnemyAnimator;

    private int playerDisplacement;
    private int crowdDisplacement;
    private int enemyHealth = 20;
    private Vector3 musicSpawnPos = new Vector3(620, 590, 0);
    private float runTime = 0;
    private float clickTime = -10;
    

    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimator = enemy.transform.GetChild(0).gameObject.GetComponent<Animator>();
        PlayerAnimator = GetComponent<Animator>();
        EnemyAnimator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        runTime += Time.deltaTime;
        if(PlayerAnimator.GetBool("isRapping"))
        {
            if (runTime - clickTime > 1)
            {
                PlayerAnimator.SetBool("isRapping", false);
            }
        }
        
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
        clickTime = runTime;
        PlayerAnimator.SetBool("isRapping", true);
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
            EnemyAnimator.speed = 1.5f;
            enemyHealth = 20;
        }
    }

    void AnimationEnded()
    {
        PlayerAnimator.SetInteger("nLoops",PlayerAnimator.GetInteger("nLoops")-1);
    }
}
