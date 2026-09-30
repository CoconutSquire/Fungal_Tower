using System.Collections.Generic;
using UnityEngine;

namespace FungalTower.Game.Data
{
    [CreateAssetMenu(fileName = "CharacterDeck", menuName = "Fungal Tower/Character Deck")]
    public class CharacterDeckDefinition : ScriptableObject
    {
        [Header("Identity")]
        [Tooltip("Display name for this curated deck.")]
        public string deckName = "New Deck";

        [TextArea(2, 5)]
        public string description;

        [Header("Character")]
        [Tooltip("The character this deck can be used by.")]
        public CharacterDefinition character;

        [Header("Cards")]
        [Tooltip("Cards in this curated deck. Edit this list directly in the Inspector.")]
        public List<CardData> cards = new List<CardData>();
    }
}
