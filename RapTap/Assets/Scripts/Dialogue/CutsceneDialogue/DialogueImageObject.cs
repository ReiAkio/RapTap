using UnityEngine;

[CreateAssetMenu(menuName = "DialogueImage/ImageList")]

public class DialogueImageObject : ScriptableObject
{
    [SerializeField] private Sprite[] dialogueImage;

    public Sprite[] DialogueImage => dialogueImage;
}
