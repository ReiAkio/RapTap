using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueUICutscene : MonoBehaviour
{      
    [SerializeField] private TMP_Text textLabel;             
    [SerializeField] private GameObject dialogueImage;       
    [SerializeField] private DialogueListObject dialogues;  
    [SerializeField] private string nextScene;               
    [SerializeField] private GameObject fadeImage;           
    [SerializeField] private float fadeTime;
    
    private TypewriterEffect typewriterEffect;
    private bool click = false;


    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        textLabel.text = string.Empty;
        StartCoroutine(ShowDialogue(dialogues));
    }

    private IEnumerator ShowDialogue(DialogueListObject dialogueList)
    {
        foreach (CutsceneDialogueObject dialogueObject in dialogueList.DialogueList)
        {
            ChangeImage(dialogueImage, dialogueObject.DialogueImage);
            yield return Fade(fadeImage, true, fadeTime);
            yield return RunDialogue(dialogueObject);
            yield return Fade(fadeImage, false, fadeTime);
        }
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    private Coroutine RunDialogue(CutsceneDialogueObject dialogueObject)
    {
        return StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(CutsceneDialogueObject dialogueObject)
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

    private void ChangeImage(GameObject dialogueImage, Sprite image)
    {
        dialogueImage.GetComponent<Image>().sprite = image;
    }

    private IEnumerator FadeImage(GameObject Image, bool fadeInOut, float time) // true = fade in, false = fade out
    {
        if (fadeInOut)
        {
            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                Image.GetComponent<Image>().color = new Color(0, 0, 0, i/time);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= time; i += Time.deltaTime)
            {
                Image.GetComponent<Image>().color = new Color(0, 0, 0, i/time);
                yield return null;
            }
        }
    }

    private Coroutine Fade(GameObject Image, bool fadeInOut, float time)
    {
        return StartCoroutine(FadeImage(Image, fadeInOut, time));
    }

    public void OnClick()
    {
        click = true;
    }
}
