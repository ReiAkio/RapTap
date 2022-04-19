using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueText")]

public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}