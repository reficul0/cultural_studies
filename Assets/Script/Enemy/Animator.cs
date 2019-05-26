using UnityEngine;

namespace Enemy
{
    public class Animator : MonoBehaviour
    {
        UnityEngine.Animator animator;
        public AudioSource source;
        public AudioClip enemyAttack;
        public AudioClip enemyInhel;

        void Start()
        {
            animator = GetComponent<UnityEngine.Animator>();
        }

        public void PlayAttack()
        {
            animator.SetTrigger("Attack");
        }
        public void OnEnemyInhel()
        {
            source.PlayOneShot(enemyInhel);
        }
        public void OnEnemyAttack()
        {
            source.PlayOneShot(enemyAttack);
        }

        public void PlayAttacked()
        {
            animator.SetTrigger("Attacked");
        }

        public void PlayDie()
        {
            animator.SetBool("Die", true);
        }
    } 
}
