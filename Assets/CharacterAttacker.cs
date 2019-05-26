using Ansver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacker : MonoBehaviour
{
    public Reaction reaction;
    public void OnCharacterAttacked()
    {
        reaction.OnCharacterAttacked();
    }
}
