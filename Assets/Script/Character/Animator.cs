using UnityEngine;

namespace Character
{
    public class Animator : MonoBehaviour
    {
        UnityEngine.Animator animator;
        public AudioSource source;
        public AudioClip playerShotSound;
        public AudioClip playerContactSound;

        void Start()
        {
            animator = GetComponent<UnityEngine.Animator>();
        }

        public void PlayAttack()
        {
            animator.SetTrigger("Attack");
        }

        public void SoundAttack()
        {
            source.PlayOneShot(playerShotSound);
        }
        public void SoundContact()
        {
            source.PlayOneShot(playerContactSound);
        }

        public void PlayAttacked()
        {
            animator.SetTrigger("Attacked");
        }

        public void PlayLostGame()
        {
            animator.SetBool("LostGame", true);
        }
    } 
}
