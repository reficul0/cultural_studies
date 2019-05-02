using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ansver
{
    public class Reaction : MonoBehaviour
    {
        public Text reaction;

        public void ReactCorrect()
        {
            reaction.text = "correct";
        }
        public void ReactInorrect()
        {
            reaction.text = "incorrect";
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
