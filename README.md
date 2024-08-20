# Card Game Mechanics - Unity Editor Only

This repository contains scripts for creating and managing the mechanics of a base card game within Unity, primarily focused on editor-time operations.

## Overview

This project includes essential scripts to handle the creation and management of a card deck, player hands, and table cards using Unity's `ScriptableObject` system. These mechanics are designed to be configurable within the Unity Editor, allowing for easy customization and extension of the card game.

## Scripts

### 1. DeckManager
The `DeckManager` script is responsible for generating and managing the card deck. It utilizes `CardObject` scriptable objects to create the deck. The deck can be configured to include or exclude duplicate cards, which will affect the total number of cards in the deck.

- **Key Features:**
  - Supports duplicate and non-duplicate deck creation.
  - Configurable deck size.
  - Handles weighted randomization based on card chances.

### 2. HandManager
The `HandManager` script deals with drawing cards from the deck to form the player's hand.

- **Key Features:**
  - Draws a specified number of cards from the deck to populate the player's hand.
  - Ensures the hand is filled with the appropriate number of cards at the start of the game.

### 3. TableCardsManager
The `TableCardsManager` script is responsible for managing the cards that are placed on the table.

- **Key Features:**
  - Populates the table with a set number of cards at the start.
  - Allows for the insertion of cards into specific positions on the table.

### 4. CardObject
The `CardObject` script defines the individual card data using Unity's `ScriptableObject`. Each card contains relevant information such as name, image, and the probability (chance) of appearing in the deck.

- **Key Features:**
  - Stores card-specific data.
  - Used by the `DeckManager` to generate and manage the card deck.
