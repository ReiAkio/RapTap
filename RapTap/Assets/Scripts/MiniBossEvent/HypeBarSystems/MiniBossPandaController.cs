using UnityEngine;

namespace MiniBossEvent
{
    public class MiniBossPandaController : MonoBehaviour
    {
        [SerializeField] public int maxHype = 100;
        
        private int currentHype;

        public MiniBossHypeBar hypeBar;

        void Start()
        {
            currentHype = 0;
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
            currentHype += hypepoints;
            hypeBar.SetHype(currentHype);
        }
    }
}




