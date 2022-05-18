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

        [SerializeField] public Animator transition;
        
        void Update()
        {
            if (bossHypeBar.slider.value == bossController.maxHype)
            {
                RestartBattle();
            }

            if (pandaHypeBar.slider.value == pandaController.maxHype)
            {
                ReturnToMain();
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
    }
}
