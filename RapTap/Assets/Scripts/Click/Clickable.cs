using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text scoreText;
    private int score;
    public GameObject player;
    public GameObject crowd;
    public GameObject musicalNote1;
    public GameObject musicalNote2;
    public GameObject enemy;
    public Rigidbody2D enemyRb;
    private int playerDisplacement;
    private int crowdDisplacement;
    private Vector3 musicSpawnPos = new Vector3(620,590,0);
    private int enemyHealth = 20;

    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void RemoveScore(int qtt)
    {
        score -= qtt;
        scoreText.text = score.ToString();
    }

    public int getScore()
    {
        return score;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Botão Abaixou

        playerDisplacement = Mathf.RoundToInt(Random.Range(2, 7));
        crowdDisplacement = Mathf.RoundToInt(Random.Range(3, 6));

        player.transform.position = new Vector2(player.transform.position.x + playerDisplacement, player.transform.position.y + (playerDisplacement-2));
        player.transform.localScale = player.transform.localScale / 1.02f;
        crowd.transform.position = new Vector2(crowd.transform.position.x, crowd.transform.position.y + crowdDisplacement);
        enemy.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y + crowdDisplacement);
        enemyHealth -= 1;
        if(enemyHealth <= 0)
        {
            enemyRb.AddForceAtPosition(new Vector2(-800f, 2600f), new Vector2(enemy.transform.position.x + 20, enemy.transform.position.y - 30), ForceMode2D.Impulse);
            enemyHealth = 40;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Botão levantou

        player.transform.position = new Vector2(player.transform.position.x - playerDisplacement, player.transform.position.y - (playerDisplacement-2));
        player.transform.localScale = player.transform.localScale * 1.02f;
        crowd.transform.position = new Vector2(crowd.transform.position.x, crowd.transform.position.y - crowdDisplacement);
        enemy.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y - crowdDisplacement);
        if (Random.Range(0,2) == 1)
        {
            Instantiate(musicalNote1, musicSpawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(musicalNote2, musicSpawnPos, Quaternion.identity);
        }
        

    }
}