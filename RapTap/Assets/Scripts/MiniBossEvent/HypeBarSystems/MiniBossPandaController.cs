using UnityEngine;

namespace MiniBossEvent
{
    public class MiniBossPandaController : MonoBehaviour
    {
        [SerializeField] public int maxHype;
        
        private int _currentHype;

        [SerializeField] MiniBossHypeBar hypeBar;

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
            }
        }


        public void GetHype(int hypepoints) 
        {
            _currentHype += hypepoints;
            hypeBar.SetHype(_currentHype);
        }
    }
}




