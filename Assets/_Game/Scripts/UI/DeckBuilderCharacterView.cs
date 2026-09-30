using TMPro;
using UnityEngine;
using FungalTower.Game.Data;

namespace FungalTower.Game.UI
{
    [DisallowMultipleComponent]
    public class DeckBuilderCharacterView : MonoBehaviour
    {
        [SerializeField] private CharacterDefinition character;
        [SerializeField] private CharacterDeckDefinition deck;
        [SerializeField] private TMP_Text characterText;
        [SerializeField] private TMP_Text deckText;

        private void OnValidate() => Refresh();

        public void Refresh()
        {
            if (characterText != null)
            {
                characterText.text = character == null
                    ? "Character: None"
                    : "Character: " + character.characterName + " " +
                      character.characterClass + " • " +
                      character.role + " • " +
                      character.biome;
            }

            if (deckText != null)
            {
                if (deck == null)
                {
                    deckText.text = "Deck: None";
                    return;
                }

                deckText.text = "Deck: " + deck.deckName + " Cards: " +
                    (deck.cards == null ? 0 : deck.cards.Count);
            }
        }
    }
}
