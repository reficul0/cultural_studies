using UnityEngine;

namespace Ansver
{
    public class Trigger : MonoBehaviour
    {
        public UIAnsver ansver;

        CManager manager;

        public void TriggerAnsver()
        {
            manager.OnUserAnsverChoice(ansver);
        }

        void Start()
        {
            InitializeManager();
        }
        private void InitializeManager()
        {
            manager = FindObjectOfType<CManager>();
        }
    } 
}
