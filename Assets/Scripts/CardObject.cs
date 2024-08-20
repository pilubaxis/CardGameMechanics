using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardObject : ScriptableObject
{
    public string cardName = "";
    public Image cardImage = null;
    public int chance = 1; // The chance of this ingredient appearing
}
