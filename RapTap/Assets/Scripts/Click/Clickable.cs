using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text scoreText;
    private int score;
    private int click = 1;

    public void Score()
    {
        score += click;
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
    
    public int getClick()
    {
        return click;
    }
    
    public int setClick(int newClick)
    {
        click = newClick;
        return click;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Botão Abaixou
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Botão levantou
    }
}