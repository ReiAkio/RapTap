using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue/DialogueList")]

public class DialogueListObject : ScriptableObject
{
    [SerializeField] private DialogueObject[] dialogueList;

    public DialogueObject[] DialogueList => dialogueList;
}
