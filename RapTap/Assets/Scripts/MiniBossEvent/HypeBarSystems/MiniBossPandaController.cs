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

        [SerializeField] private AudioManager audioScript;
        //private float timer;
        //private float clickTime;

        void Start()
        {
            _currentHype = 0;
            hypeBar.SetMaxHype(maxHype);
        }

    
        private void Update()
        {
            //timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetHype(10);
                //clickTime = timer;
                playerAnimator.SetBool("isRapping", true);
                audioScript.PlayRapMusic();
                audioScript.PlayClickSFX();
            }

            //if(playerAnimator.GetBool("isRapping") && timer - clickTime > 1)
            else if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                playerAnimator.SetBool("isRapping", false);
                audioScript.PauseRapMusic();
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




