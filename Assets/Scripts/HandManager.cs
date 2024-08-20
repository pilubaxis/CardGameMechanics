using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [Tooltip("Number of card per hand")]
    [SerializeField] private int handCount = 4;

    
    [SerializeField] private DeckManager deckManager;

    public List<CardObject> hand = new List<CardObject>();

    /// <summary>
    /// Populate players hands
    /// </summary>
    public void PopulateHand()
    {
        for (int i = 0; i < handCount; i ++)
        {
            CardObject card = deckManager.GetNextInDeck();
            if (card != null)
            {
                hand.Add(card);
            }
        }
    }
}
