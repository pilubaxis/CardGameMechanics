using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCardManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private int tableStatrQuantity = 5;
    [SerializeField] private DeckManager deckManager = null;

    public List<CardObject> tableCards= new List<CardObject>();


    /// <summary>
    /// Populates the table
    /// </summary>
    public void PopulateTable()
    {
        for (int i = 0; i < tableStatrQuantity; i ++)
        {
            tableCards.Add(deckManager.GetNextInDeck());
        }
    }

    /// <summary>
    /// Can insert a card in the table cards list order.
    /// </summary>
    /// <param name="idToInsert"></param>
    /// <param name="cardToInsert"></param>
    public void InsertOnTable(int idToInsert, CardObject cardToInsert)
    {
        if (idToInsert < 0 || idToInsert > tableCards.Count)
        {
            Debug.LogWarning("Invalid index for insertion. Cannot insert card.");
            return;
        }

        // Insert the card at the specified index
        tableCards.Insert(idToInsert, cardToInsert);
        Debug.Log("Inserted card " + cardToInsert.name + " at position " + idToInsert);
    }
}


