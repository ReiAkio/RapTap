using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalloonDialogueUI : MonoBehaviour
{ 
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private float minTime = 0;
    private float maxTime = 30;

    private float spawnTime;
    private float time;


    private BalloonTypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<BalloonTypewriterEffect>();
        CloseDialogueBox();
        SetRandomTime();
        time = minTime;
    }


    void FixedUpdate()
    {
 
        time += Time.deltaTime;
 
        if(time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }
    }


    private void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(WalkthroughDialogue(dialogueObject));
    }


    private IEnumerator WalkthroughDialogue(DialogueObject dialogueObject)
    {
         foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitForSeconds(3);
        }
        CloseDialogueBox();
    }


    private void CloseDialogueBox() 
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }


    /* Instante de spawn do Balloon e chamada da função */

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }


    void SpawnObject()
    {
        time = 0;
        ShowDialogue(testDialogue);
    }
}