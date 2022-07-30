using UnityEngine;
using UnityEngine.Serialization;

namespace MiniBossEvent
{
    public class MiniBossPandaController : MonoBehaviour
    {
        [SerializeField] public int maxHype;
        [SerializeField] MiniBossHypeBar hypeBar;
        [SerializeField] public Animator playerAnimator;
        
        private int _currentHype;

        void Start()
        {
            _currentHype = 0;
            hypeBar.SetMaxHype(maxHype);
        }

    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetHype(10);
                playerAnimator.SetBool("isRapping", true);
            }
            
            else if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                playerAnimator.SetBool("isRapping", false);
            }
        }


        public void GetHype(int hypepoints) 
        {
            _currentHype += hypepoints;
            hypeBar.SetHype(_currentHype);
        }

        void AnimationEnded()
        {
            playerAnimator.SetInteger("nLoops", playerAnimator.GetInteger("nLoops") - 1);
        }
    }
}




