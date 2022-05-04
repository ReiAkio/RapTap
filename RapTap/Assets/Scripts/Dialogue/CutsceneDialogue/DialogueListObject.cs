using UnityEngine;

[CreateAssetMenu(menuName = "Cutscene/DialogueList")]

public class DialogueListObject : ScriptableObject
{
    [SerializeField] private CutsceneDialogueObject[] dialogueList;

    public CutsceneDialogueObject[] DialogueList => dialogueList;
}
