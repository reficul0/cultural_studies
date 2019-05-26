using Question;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEndPanel : MonoBehaviour
{
    public Character.Mediator character;
    public Enemy.Mediator enemy;
    public Animator anim;

    private void OnEnable()
    {
    //    if (character.IsGameLost() || enemy.IsDie())
    //        anim.SetTrigger("end");
    }
    public Manager manager;
    public void PrintEventE()
    {
        manager.OnSceneLoaded();
    }
}
