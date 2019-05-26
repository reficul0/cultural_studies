using Ansver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    public Reaction reaction;
    public void OnEnemyAttacked()
    {
        reaction.OnEnemyAttacked();
    }
}
