using UnityEngine;

/// <summary>
/// Os atributso do produto a ser comprado
/// </summary>
[CreateAssetMenu(fileName = "New VisualItem")]
public class VisualItem : Product
{
    public RuntimeAnimatorController image;
    public Sprite trueImage;
}
