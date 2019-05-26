using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        public int health;
        public int numberOfHealth;

        public SpriteRenderer[] hearth;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        public void OnDamage(int damage)
        {
            health -= damage;
        }

        void Update()
        {
            for (int i = 0; i < hearth.Length; i++)
            {
                if (i < health)
                    hearth[i].sprite = fullHeart;
                else
                    hearth[i].sprite = emptyHeart;
                
                hearth[i].enabled = i < numberOfHealth;
            }
        }
    }
}