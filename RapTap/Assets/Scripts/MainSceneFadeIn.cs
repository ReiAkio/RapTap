using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneFadeIn : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    private RawImage BlackRec;

    // Start is called before the first frame update
    void Start()
    {
        BlackRec = GetComponent<RawImage>();
        StartCoroutine(FadeIn(fadeTime));
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private IEnumerator FadeIn(float time)
    {
        for (float i = time; i >= 0; i -= Time.deltaTime)
        {
            BlackRec.color = new Color(0, 0, 0, i / time);
            yield return null;
        }
    }
}
