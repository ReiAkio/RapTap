using System.Collections;
using UnityEngine;

namespace MiniBossEvent
{
    public class MiniBossController : MonoBehaviour
    {
        [SerializeField] public int maxHype = 100;
        [SerializeField] public int hypePps;
        
        private int currentHype;
        
        public MiniBossHypeBar hypeBar;
        
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
