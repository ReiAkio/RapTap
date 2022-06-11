using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class SaturationChange : MonoBehaviour
{
    //public PostProcessVolume vol;
    public PostProcessProfile prof;
    public ColorGrading colGrad;
    public ColorAdjustments colAdj;
    public PostProcessEffectSettings set;
    // Start is called before the first frame update
    void Start()
    {
        //colAdj.saturation.value = -100;
        //prof.TryGetSettings<ColorGrading>(out var colGrad);
        colGrad = prof.GetSetting<ColorGrading>();
        colGrad.saturation.value = -100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}