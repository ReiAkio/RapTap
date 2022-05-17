using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniBossEvent
{
    public class MainLl : MonoBehaviour
    {
        [SerializeField] Clickable click;
    
        [SerializeField] public Animator transition;
        
        void Update()
        {
            if (click.getScore() == 30)
            {
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
