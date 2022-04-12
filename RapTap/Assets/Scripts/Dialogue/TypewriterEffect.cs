using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{

    [SerializeField] private float textSpeed = 20f;
    [SerializeField] private float wait = 2f;
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }
    
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {

        textLabel.text = string.Empty;
        yield return new WaitForSeconds(wait);

        float t = 0;
        int charIndex = 0;
        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * textSpeed;
            charIndex = Mathf.FloorToInt(t);
            textLabel.text = textToType.Substring(0, charIndex);

            yield return null; 
        }
        textLabel.text = textToType;
    }



}
