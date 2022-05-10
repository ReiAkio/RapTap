using UnityEngine;
using UnityEngine.UI;

namespace MiniBossEvent
{
    public class MiniBossHypeBar : MonoBehaviour
    {

        public Slider slider;
        public Gradient gradient;
        public Image fill;
    
        public void SetMaxHype(int hype)
        {
            slider.maxValue = hype;
            slider.value = 0;
        
        }
    
        public void SetHype(int hype)
        {
            slider.value = hype;
        
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    
    }
}
