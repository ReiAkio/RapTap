using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject characterImage;
    [SerializeField] private DialogueListObject characterDialogueList;

    private TypewriterEffect typewriterEffect;
    private bool click = false;

    private void Start()
    {
        textLabel.text = string.Empty;
        typewriterEffect = GetComponent<TypewriterEffect>();
        StartCoroutine(ShowDialogue(characterDialogueList.DialogueList));
    }


    public Coroutine RunDialogue(CutsceneDialogueObject[] dialogueList)
    {
        return StartCoroutine(ShowDialogue(dialogueList));
    }

    private IEnumerator ShowDialogue(CutsceneDialogueObject[] dialogueList)
    {
        dialogueBox.SetActive(true);
        foreach (CutsceneDialogueObject characterDialogue in dialogueList)
        {
            ChangeImage(characterImage, characterDialogue.DialogueImage);
            yield return RunDialogue(characterDialogue);
        }
        dialogueBox.SetActive(false);
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

    private void ChangeImage(GameObject dialogueImage, Sprite characterImage)
    {
        dialogueImage.GetComponent<Image>().sprite = characterImage;
    }

    public void OnClick()
    {
        click = true;
    }
}

