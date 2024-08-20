using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private int deckCount = 10;
    [Tooltip("If true, the deck will include duplicate cards. In this case, the deck count will reflect the total number of card options, including duplicates.")]
    [SerializeField] private bool deckHasDuplicates = true;
    [SerializeField] private List<CardObject> cards = new List<CardObject>();

    [SerializeField] private Stack<CardObject> stackDeck = new Stack<CardObject>();


    [Header("References")]
    [SerializeField] private HandManager handManager;
    [SerializeField] private TableCardManager tableCardManager;
    void Start()
    {
        GenerateCardDeck();
        tableCardManager.PopulateTable();
        handManager.PopulateHand();
    }

    public void GenerateCardDeck()
    {
        if (deckHasDuplicates)
        {
            float totalWeight = 0f;

            // Calculate the total weight based on card chances
            foreach (var card in cards)
            {
                totalWeight += card.chance;
            }

            for (int i = 0; i < deckCount; i++)
            {
                float randomValue = Random.Range(0f, totalWeight);
                float cumulativeWeight = 0f;

                foreach (var card in cards)
                {
                    cumulativeWeight += card.chance;

                    // Select the card if the random value is within the cumulative weight range
                    if (randomValue <= cumulativeWeight)
                    {
                        stackDeck.Push(CreateUniqueCardInstance(card));
                        break;
                    }
                }
            }
        }
        else
        {
            if (cards.Count == 0)
            {
                Debug.LogWarning("No cards available to generate the deck.");
                return;
            }

            // Shuffle the cards
            List<CardObject> shuffledCards = Shuffle(cards);

            for (int i = 0; i < Mathf.Min(deckCount, shuffledCards.Count); i++)
            {
                stackDeck.Push(CreateUniqueCardInstance(shuffledCards[i]));
            }
        }
    }



    /// <summary>
    /// Shuffles the list
    /// </summary>
    /// <param name="cardsList"></param>
    /// <returns></returns>
    private List<CardObject> Shuffle(List<CardObject> cardsList)
    {
        List<CardObject> shuffledList = new List<CardObject>(cardsList);
        int n = shuffledList.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            CardObject value = shuffledList[k];
            shuffledList[k] = shuffledList[n];
            shuffledList[n] = value;
        }
        return shuffledList;
    }

    /// <summary>
    /// Creates a unique instance of the provided CardObject
    /// </summary>
    /// <param name="card">The original CardObject to clone</param>
    /// <returns>A new unique CardObject instance</returns>
    private CardObject CreateUniqueCardInstance(CardObject card)
    {
        CardObject uniqueCard = ScriptableObject.CreateInstance<CardObject>();
        uniqueCard.cardName = card.cardName;
        uniqueCard.cardImage = card.cardImage;
        uniqueCard.chance = card.chance;
        return uniqueCard;
    }

    /// <summary>
    /// Gets the next card in deck
    /// </summary>
    /// <returns> next card </returns>
    public CardObject GetNextInDeck()
    {
        CardObject card = null;
        if (stackDeck.Count <= 0)
        {
            Debug.Log("No More Cards left on Deck");
        }
        else
        {
            card = stackDeck.Pop();
        }

        return card;
    }
}
