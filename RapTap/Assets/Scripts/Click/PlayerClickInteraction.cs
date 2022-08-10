using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickInteraction : MonoBehaviour
{
    [SerializeField] private AudioManager audioScript;

    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject musicalNote1;
    [SerializeField] private GameObject musicalNote2;
    [SerializeField] private GameObject musicalNote3;
    [SerializeField] private GameObject musicalNote4;

    private Animator PlayerAnimator;
    private Animator EnemyAnimator;
    [SerializeField] private Animator BoomboxAnimator;

    static public bool isRap;
    private int playerDisplacement;
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
        if(isRap)
        {
            if (runTime - clickTime > 1)
            {
                StopRapping();
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
        audioScript.PlayClickSFX();
        if (!isRap)
        {
            isRap = true;
            PlayerAnimator.SetBool("isRapping", isRap);
            BoomboxAnimator.SetBool("isRapping", isRap);
            audioScript.PlayRapMusic();
        }
        playerDisplacement = Random.Range(2, 7);
        transform.position = new Vector2(transform.position.x + playerDisplacement, transform.position.y + (playerDisplacement - 2));
        transform.localScale = transform.localScale / 1.02f;
        enemyHealth -= 1;
        switch(Random.Range(0, 4))
        {
            case 0:
                Instantiate(musicalNote1, musicSpawnPos, Quaternion.identity);
                break;
            case 1:
                Instantiate(musicalNote2, musicSpawnPos, Quaternion.identity);
                break;
            case 2:
                Instantiate(musicalNote3, musicSpawnPos, Quaternion.identity);
                break;
            case 3:
                Instantiate(musicalNote4, musicSpawnPos, Quaternion.identity);
                break;
        }
    }

    void playerMouseUp ()
    {
        transform.position = new Vector2(transform.position.x - playerDisplacement, transform.position.y - (playerDisplacement - 2));
        transform.localScale = transform.localScale * 1.02f;

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

    public void StopRapping ()
    {
        isRap = false;
        PlayerAnimator.SetBool("isRapping", isRap);
        BoomboxAnimator.SetBool("isRapping", isRap);
        audioScript.PauseRapMusic();
    }
}
