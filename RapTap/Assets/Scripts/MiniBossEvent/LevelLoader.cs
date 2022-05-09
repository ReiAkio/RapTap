using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniBossEvent
{
    public class LevelLoader : MonoBehaviour
    {
        public Clickable click;
    
        void Update()
        {
            if (click.getScore() == 30)
            {
                LoadNextMiniBoss();
            }
        }

        public void LoadNextMiniBoss()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
