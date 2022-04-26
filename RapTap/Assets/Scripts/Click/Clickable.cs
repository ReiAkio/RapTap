using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text scoreText;
    private int score;

    public delegate void ClickAction();
    public static event ClickAction MouseDown;
    public static event ClickAction MouseUp;

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

        if(MouseDown != null)
        {
            MouseDown();
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Botão levantou

        if (MouseUp != null)
        {
            MouseUp();
        }
     
    }
}