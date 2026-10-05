using System.Collections.Generic;
using TMPro;
using UnityEngine;
using FungalTower.Game.Data;

namespace FungalTower.Game.UI
{
    [DisallowMultipleComponent]
    public class CharacterDeckSelector : MonoBehaviour
    {
        [Header("Editor-Authored Options")]
        [SerializeField] private CharacterDefinition[] characters;
        [SerializeField] private CharacterDeckDefinition[] decks;

        [Header("Dropdowns")]
        [SerializeField] private TMP_Dropdown characterDropdown;
        [SerializeField] private TMP_Dropdown deckDropdown;

        [Header("Selection Display")]
        [SerializeField] private TMP_Text selectionText;

        private readonly List<CharacterDeckDefinition> currentDecks = new List<CharacterDeckDefinition>();

        public CharacterDefinition SelectedCharacter { get; private set; }
        public CharacterDeckDefinition SelectedDeck { get; private set; }

        private void Awake()
        {
            if (characterDropdown != null)
                characterDropdown.onValueChanged.AddListener(SetCharacter);

            if (deckDropdown != null)
                deckDropdown.onValueChanged.AddListener(SetDeck);

            Refresh();
        }

        private void OnDestroy()
        {
            if (characterDropdown != null)
                characterDropdown.onValueChanged.RemoveListener(SetCharacter);

            if (deckDropdown != null)
                deckDropdown.onValueChanged.RemoveListener(SetDeck);
        }

        public void Refresh()
        {
            if (characters == null)
                characters = new CharacterDefinition[0];

            if (characterDropdown != null)
            {
                characterDropdown.ClearOptions();
                var options = new List<string>();
                foreach (var character in characters)
                    if (character != null)
                        options.Add(character.characterName);

                characterDropdown.AddOptions(options);
            }

            if (characters.Length > 0)
                SetCharacter(0);
            else
                UpdateDisplay();
        }

        public void SetCharacter(int index)
        {
            if (characters == null || characters.Length == 0)
            {
                SelectedCharacter = null;
                currentDecks.Clear();
                UpdateDeckOptions();
                return;
            }

            index = Mathf.Clamp(index, 0, characters.Length - 1);
            SelectedCharacter = characters[index];
            currentDecks.Clear();

            if (SelectedCharacter != null && decks != null)
            {
                foreach (var deck in decks)
                    if (deck != null && deck.character == SelectedCharacter)
                        currentDecks.Add(deck);
            }

            UpdateDeckOptions();
        }

        public void SetDeck(int index)
        {
            if (currentDecks.Count == 0)
            {
                SelectedDeck = null;
                UpdateDisplay();
                return;
            }

            index = Mathf.Clamp(index, 0, currentDecks.Count - 1);
            SelectedDeck = currentDecks[index];
            UpdateDisplay();
        }

        private void UpdateDeckOptions()
        {
            SelectedDeck = null;

            if (deckDropdown != null)
            {
                deckDropdown.ClearOptions();
                var options = new List<string>();
                foreach (var deck in currentDecks)
                    options.Add(deck.deckName);

                deckDropdown.AddOptions(options);
            }

            if (currentDecks.Count > 0)
                SetDeck(0);
            else
                UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (selectionText == null)
                return;

            if (SelectedCharacter == null)
            {
                selectionText.text = "No character selected.";
                return;
            }

            var deckName = SelectedDeck != null ? SelectedDeck.deckName : "No curated deck";
            selectionText.text =
                SelectedCharacter.characterName + " " +
                SelectedCharacter.characterClass + " • " +
                SelectedCharacter.role + " • " +
                SelectedCharacter.biome + " " +
                "Deck: " + deckName;
        }
    }
}
