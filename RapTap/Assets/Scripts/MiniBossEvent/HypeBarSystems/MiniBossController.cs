using System;
using System.Collections;
using UnityEngine;

namespace MiniBossEvent
{
    public class MiniBossController : MonoBehaviour
    {
        [SerializeField] public int maxHype;
        [SerializeField] public int hypePps;
        [SerializeField] public Animator enemyAnimator;
        
        private int currentHype;
        
        public MiniBossHypeBar hypeBar;
        
        void Start()
        {
            currentHype = 0;
            hypeBar.SetMaxHype(maxHype);
            StartCoroutine(RaiseHypeBar());
        }

        private void Update()
        {
            enemyAnimator.SetBool("isRapping", false);

            if (enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                enemyAnimator.SetBool("isRapping", true);   
            }
        }

        IEnumerator RaiseHypeBar()
        {
            while (true)
            {
                GetHype(hypePps);
                yield return new WaitForSeconds(1);
            }
        }
        
        private void GetHype(int hypepoints) 
        {
            currentHype += hypepoints;
            hypeBar.SetHype(currentHype);
        }
    }
}
