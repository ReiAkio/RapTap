using UnityEngine;

[CreateAssetMenu(menuName = "Cutscene/DialogueObject")]

public class CutsceneDialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    [SerializeField] Sprite dialogueImage;

    public Sprite DialogueImage => dialogueImage;
    public string[] Dialogue => dialogue;
}



