using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace MiniBossEvent
{
    public class MiniBossController : MonoBehaviour
    {
        [SerializeField] public int maxHype;
        [SerializeField] public int hypePps;

        [SerializeField] MiniBossHypeBar hypeBar;
        
        private int currentHype;
        
        
        void Start()
        {
            currentHype = 0;
            hypeBar.SetMaxHype(maxHype);
            StartCoroutine(RaiseHypeBar());
        }

        IEnumerator RaiseHypeBar()
        {
            while (true)
            {
                GetHype(hypePps);
                yield return new WaitForSeconds(1);
            }
        }
        
        public void GetHype(int hypepoints) 
        {
            currentHype += hypepoints;
            hypeBar.SetHype(currentHype);
        }
    }
}
