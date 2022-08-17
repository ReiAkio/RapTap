using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniBossEvent
{
    public class MiniBossLl : MonoBehaviour
    {
        [SerializeField] public MiniBossHypeBar bossHypeBar;
        [SerializeField] public MiniBossHypeBar pandaHypeBar;
        [SerializeField] public MiniBossController bossController;
        [SerializeField] public MiniBossPandaController pandaController;
        [SerializeField] public GameObject clickButton;
        [SerializeField] private AudioManager audioScript;
        [SerializeField] private Animator WarningSignAnimator;

        [SerializeField] public Animator transition;
        
        void Start()
        {
            StartCoroutine(WarningSignEvent());
        }

        void Update()
        {
            if (bossHypeBar.slider.value >= bossController.maxHype && pandaHypeBar.slider.value < pandaController.maxHype)
            {
                StartCoroutine(ResultsSignEvent(false));
            }

            if (pandaHypeBar.slider.value >= pandaController.maxHype && bossHypeBar.slider.value < bossController.maxHype)
            {
                StartCoroutine(ResultsSignEvent(true));
            }
        }

        private void RestartBattle()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void ReturnToMain()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene(levelIndex);
        }

        IEnumerator WarningSignEvent()
        {
            yield return new WaitForSeconds(7);

            clickButton.SetActive(true);
            bossController.enabled = true;
            audioScript.PlayBgMusic();
        }

        IEnumerator ResultsSignEvent(bool win)
        {
            clickButton.SetActive(false);
            bossController.hypePps = 0;
            //StopCoroutine(bossController.RaiseHypeBar());
            bossController.enabled = false;
            if (win)
            {
                WarningSignAnimator.SetBool("Won", true);
                yield return new WaitForSeconds(3);
                ReturnToMain();
            }
            else
            {
                WarningSignAnimator.SetBool("Lost", true);
                yield return new WaitForSeconds(3);
                RestartBattle();
            }
        }
    }
}
