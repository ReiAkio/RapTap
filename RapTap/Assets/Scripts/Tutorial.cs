using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public string nextScene;
    public Clickable clickable;
    public TypewriterEffect typewriterEffect;
    private bool click = false;
    private bool run = false;
    private int i;
    private int option = 0;

    public GameObject dialogueBox;
    public TMP_Text textLabel;
    public DialogueListObject dialogues;
    public Button dialogueButton;
    public Button clickButton;
    public Button visualButton;
    public Button buffButton;
    public Button visualBuyButton;
    public Button buffBuyButton;
    public Button visualExitButton;
    public Button buffExitButton;
    public GameObject OptionButtons;

    public void Awake()
    {
        OptionButtons.SetActive(false);
    }

    public void Start()
    {
        StartCoroutine(RunTutorial(dialogues));
    }

    private IEnumerator RunTutorial(DialogueListObject dialogueList)
    {
        foreach (CutsceneDialogueObject dialogueObject in dialogueList.DialogueList)
        {
            switch (i)
            {
                case 0:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    clickButton.interactable = true;
                    dialogueBox.SetActive(false);
                    while(clickable.getScore() < 20)
                    {
                        yield return null;
                    }
                    clickButton.interactable = false;
                    break;
                case 1:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    visualButton.interactable = true;
                    while (run == false)
                    {
                        yield return null;
                    }
                    visualButton.interactable = false;
                    run = false;
                    break;
                case 2:
                    yield return RunDialogue(dialogueObject);
                    visualBuyButton.interactable = true;
                    while(run == false)
                    {
                        yield return null;
                    }
                    visualBuyButton.interactable = false;
                    run = false;
                    break;
                case 3:
                    yield return RunDialogue(dialogueObject);
                    visualExitButton.interactable = true;
                    while(run == false)
                    {
                        yield return null;
                    }
                    visualExitButton.interactable = false;
                    run = false;
                    break;
                case 4:
                    yield return RunDialogue(dialogueObject);
                    buffButton.interactable = true;
                    while (run == false)
                    {
                        yield return null;
                    }
                    buffButton.interactable = false;
                    run = false;
                    break;
                case 5:
                    yield return RunDialogue(dialogueObject);
                    buffBuyButton.interactable = true;
                    while (run == false)
                    {
                        yield return null;
                    }
                    buffBuyButton.interactable = false;
                    run = false;
                    break;
                case 6:
                    yield return RunDialogue(dialogueObject);
                    buffExitButton.interactable = true;
                    while (run == false)
                    {
                        yield return null;
                    }
                    buffExitButton.interactable = false;
                    run = false;
                    break;
                case 7:
                    yield return RunDialogue(dialogueObject);
                    clickButton.interactable = true;
                    dialogueBox.SetActive(false);
                    while (clickable.getScore() < 25)
                    {
                        yield return null;
                    }
                    clickButton.interactable = false;
                    break;
                case 8:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    dialogueBox.SetActive(false);
                    break;
            }
            i++;
        }
        OptionButtons.SetActive(true);
        while (option == 0) 
        {
            yield return null;
        }
        OptionButtons.SetActive(false);
        if(option == 1)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if(option == 2)
        {
            SceneManager.LoadScene(nextScene);
        }
        yield return null;
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
            dialogueButton.interactable = true;
            while (click == false)
            {
                yield return null;
            }
            dialogueButton.interactable = false;
            textLabel.text = string.Empty;
        }
    }


    public void OnClick()
    {
        click = true;
    }
    public void Run()
    {
        run = true;
    }
    public void Yes()
    {
        option = 1;
    }
    public void No()
    {
        option = 2;
    }
    public void Skip()
    {
        StopAllCoroutines();
        SceneManager.LoadScene(nextScene);
    }
}
