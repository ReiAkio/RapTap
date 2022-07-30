using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniBossEvent
{
    public class MainLl : MonoBehaviour
    {
        [SerializeField] Clickable click;

        [SerializeField] public Animator transition;

        [SerializeField] public int scoretriggerBoss;

        public SaveButtonScript saveButton;

        public int countEventAlreadyHappen = 1;
        void Update()
        {
            if (click.getScore() >= scoretriggerBoss && countEventAlreadyHappen == 1)
            {
                countEventAlreadyHappen += 1;
                saveButton.OnClick();
                LoadNextMiniBoss();
            }
        }

        public void LoadNextMiniBoss()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene(levelIndex);
        }
    }
}