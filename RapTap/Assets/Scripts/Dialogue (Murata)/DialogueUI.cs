using UnityEngine;
using TMPro;



public class DialogueUI : MonoBehaviour 
{
    [SerializeField] private TMP_Text textLabel;


    private void Start() 
    {
        GetComponent<TypeWriterEfct>().Run("This is a bit of text!\nHello.", textLabel);
    }
}
