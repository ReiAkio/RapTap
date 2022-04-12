using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject dialogueImage;
    [SerializeField] private DialogueImageObject testImage;

    [SerializeField] private DialogueObject[] testDialogue;
    



    private TypewriterEffect typewriterEffect;

    private bool click = false;

    private int i = 0;

    private GameObject image;
    public void OnClick()
    {
        click = true;
    }

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        //CloseDialogue(); Fecha a Caixa de dialogo
        ShowDialogue(testDialogue[i]);
    }


    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        ChangeImage(dialogueImage, testImage.DialogueImage);
        StartCoroutine(StepThroughDialogue(dialogueObject));
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
            
        }
        if (i != testDialogue.Length -1)
        {
            i++;
            ShowDialogue(testDialogue[i]);
        }
        //CloseDialogue();
    }

    private void ChangeImage(GameObject dialogueImage, Sprite[] imageFromList)
    {
        dialogueImage.GetComponent<Image>().sprite = imageFromList[i];
    }

    private void EndScene()
    {

    }

    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
