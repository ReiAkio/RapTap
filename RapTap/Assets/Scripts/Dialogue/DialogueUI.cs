using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject dialogueImage;
    [SerializeField] private DialogueImageObject testImage;
    [SerializeField] private DialogueObject[] testDialogue;
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject fadeImage;
    [SerializeField] private float fadeTime;




    private TypewriterEffect typewriterEffect;

    private bool click = false;

    private int i = 0;

    public void OnClick()
    {
        click = true;
    }

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        dialogueBox.SetActive(true);
        textLabel.text = string.Empty;
        StartCoroutine(ShowDialogue(testDialogue));
    }


    private IEnumerator ShowDialogue(DialogueObject[] dialogueObjectList)
    {
        foreach (DialogueObject dialogueObject in dialogueObjectList)
        {
            ChangeImage(dialogueImage, testImage.DialogueImage);
            yield return Fade(fadeImage, true, fadeTime);
            i++;
            yield return RunDialogue(dialogueObject);
            yield return Fade(fadeImage, false, fadeTime);
        }
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    private Coroutine RunDialogue(DialogueObject dialogueObject)
    {
        return StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {        
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            click = false;
            while (click == false)
            {
                yield return null;
            }
            textLabel.text = string.Empty;
        }
    }

    private void ChangeImage(GameObject dialogueImage, Sprite[] imageFromList)
    {
        dialogueImage.GetComponent<Image>().sprite = imageFromList[i];
    }

    private IEnumerator FadeImage(GameObject Image, bool fadeInOut, float time) // true = fade in, false = fade out
    {
        if (fadeInOut)
        {
            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                Image.GetComponent<Image>().color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= time; i += Time.deltaTime)
            {
                Image.GetComponent<Image>().color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    public Coroutine Fade(GameObject Image, bool fadeInOut, float time)
    {
        return StartCoroutine(FadeImage(Image, fadeInOut, time));
    }

}
