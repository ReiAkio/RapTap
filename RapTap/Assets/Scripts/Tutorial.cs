using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public bool tutorialIsDone;
    public string nextScene;
    public Clickable clickable;
    public TypewriterEffect typewriterEffect;
    private bool click = false;
    private bool run = false;
    private bool buffrun = false;
    private int i;

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
    public SaveButtonScript saveSystem;

    public void Awake()
    {
        tutorialIsDone = false;
    }

    public void Start()
    {
        if (tutorialIsDone)
        {
            SceneManager.LoadScene(nextScene);
        }
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
                    dialogueBox.SetActive(false);
                    visualButton.interactable = true;
                    while (run == false)
                    {
                        yield return null;
                    }
                    run = false;
                    break;
                case 2:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    clickable.setScore(10);
                    dialogueBox.SetActive(false);
                    visualBuyButton.interactable = true;
                    buffBuyButton.interactable = false;
                    while(run == false)
                    {
                        yield return null;
                    }
                    visualBuyButton.interactable = false;
                    run = false;
                    break;
                case 3:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    dialogueBox.SetActive(false);
                    visualExitButton.interactable = true;
                    while(run == false)
                    {
                        yield return null;
                    }
                    visualExitButton.interactable = false;
                    run = false;
                    break;
                case 4:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    dialogueBox.SetActive(false);
                    buffButton.interactable = true;
                    while (buffrun == false)
                    {
                        yield return null;
                    }
                    buffButton.interactable = false;
                    run = false;
                    break;
                case 5:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    clickable.setScore(10);
                    dialogueBox.SetActive(false);
                    buffBuyButton.interactable = true;
                    while (run == false)
                    {
                        yield return null;
                    }
                    
                    run = false;
                    break;
                case 6:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    dialogueBox.SetActive(false);
                    buffExitButton.interactable = true;
                    while (run == false)
                    {
                        yield return null;
                    }
                    buffExitButton.interactable = true;
                    run = false;
                    break;
                case 7:
                    dialogueBox.SetActive(true);
                    yield return RunDialogue(dialogueObject);
                    dialogueBox.SetActive(false);
                    clickButton.interactable = true;
                    dialogueBox.SetActive(false);
                    while (clickable.getScore() < 10)
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
        if(i == 9)
        {
            tutorialIsDone = true;
            saveSystem.OnClick();
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

    public void BuffRun()
    {
        buffrun = true;
    }

}
