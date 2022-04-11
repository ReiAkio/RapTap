using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueList")]

public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
