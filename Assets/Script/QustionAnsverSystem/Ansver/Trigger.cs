using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ansver
{
    public class Trigger : MonoBehaviour
    {
        public UIAnsver ansver;

        Manager manager;

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
            manager = FindObjectOfType<Manager>();
        }
    } 
}
