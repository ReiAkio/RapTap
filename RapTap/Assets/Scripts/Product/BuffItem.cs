using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Os atributos do produto a ser comprado
/// </summary>
[CreateAssetMenu(fileName = "New Buff")]
public class BuffItem : Product
{
    public int buffClick;
    public Sprite image;
}
