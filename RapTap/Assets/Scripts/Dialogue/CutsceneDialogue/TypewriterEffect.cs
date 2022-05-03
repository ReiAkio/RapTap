using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;



public class TypewriterEffect : MonoBehaviour
{

    [SerializeField] private float textSpeed = 20f;
    [SerializeField] private float wait = 2f;
    [SerializeField] private float skipSpeedMultiplier;


    private bool isRunning = false;
    private bool skip = false;

    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;


        public Punctuation(HashSet<char> punctuations, float waitTime)
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (Punctuation punctuationCategory in punctuations)
        {
            if (punctuationCategory.Punctuations.Contains(character))
            {
                waitTime = punctuationCategory.WaitTime;
                return true;
            }
        }

        waitTime = default;
        return false;
    }

    private readonly List<Punctuation> punctuations = new List<Punctuation>()
    {
        new Punctuation(new HashSet<char>(){'.', '!', '?'}, 0f),
        new Punctuation(new HashSet<char>(){',', ';', ':'}, 0f)
    };

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
            int lastCharIndex = charIndex;
            if (skip)
            {
                t += Time.deltaTime * textSpeed * skipSpeedMultiplier;
                charIndex = Mathf.FloorToInt(t);
                charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
                for (int i = lastCharIndex; i < charIndex; i++)
                {
                    textLabel.text = textToType.Substring(0, i + 1);
                }
                yield return null;
            }
            else
            {
                t += Time.deltaTime * textSpeed;
                charIndex = Mathf.FloorToInt(t);
                charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
                for (int i = lastCharIndex; i < charIndex; i++)
                {
                    bool isLast = i >= textToType.Length - 1;

                    textLabel.text = textToType.Substring(0, i + 1);

                    if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i + 1], out _))
                    {
                        yield return new WaitForSeconds(waitTime);
                    }
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
