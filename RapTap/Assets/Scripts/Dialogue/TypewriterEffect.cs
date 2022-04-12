using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{

    [SerializeField] private float textSpeed = 20f;
    [SerializeField] private float wait = 2f;
    [SerializeField] private float skipSpeedMultiplier;

    private bool isRunning = false;
    private bool skip = false;

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }
    
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {

        textLabel.text = string.Empty;
        yield return new WaitForSeconds(wait);
        skip = false;
        float t = 0;
        int charIndex = 0;
        isRunning = true;
        while (charIndex < textToType.Length)
        {
            if (skip)
            { 
                t += Time.deltaTime * textSpeed * skipSpeedMultiplier;
                charIndex = Mathf.FloorToInt(t);
                if(charIndex > textToType.Length)
                {
                    textLabel.text = textToType;
                }
                else
                {
                    textLabel.text = textToType.Substring(0, charIndex);
                }
                yield return null;
            }
            else
            {
                t += Time.deltaTime * textSpeed;
                charIndex = Mathf.FloorToInt(t);
                if (charIndex > textToType.Length)
                {
                    textLabel.text = textToType;
                }
                else
                {
                    textLabel.text = textToType.Substring(0, charIndex);
                }
                yield return null;
            }
        }
        textLabel.text = textToType;
    }

    public void OnSkipClick()
    {
        if (isRunning)
        {
            skip = true;
        }
    }

}
