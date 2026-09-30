using System.Collections.Generic;
using UnityEngine;

namespace FungalTower.Game.Data
{
    [DisallowMultipleComponent]
    public class CharacterDefinition : MonoBehaviour
    {
        [Header("Identity")]
        [Tooltip("Display name used for this character.")]
        public string characterName = "New Character";

        [TextArea(3, 8)]
        [Tooltip("Character description shown in character information UI.")]
        public string description;

        
        public CharacterClass characterClass = CharacterClass.Warrior;
        public CharacterRole role = CharacterRole.Damage;
        public CharacterBiome biome = CharacterBiome.Forest;

        [Header("Presentation")]
        [Tooltip("Character portrait or artwork.")]
        public Sprite portrait;

        [Tooltip("Character sprite used during gameplay.")]
        public Sprite battleSprite;

        [Header("Base Stats")]
        [Min(1)] public int maxHealth = 50;
        [Min(0)] public int startingHealth = 50;
        [Min(0)] public int attack = 5;
        [Min(0)] public int defense = 0;
        [Min(0)] public int speed = 5;

        [Header("Passive")]
        [Tooltip("Name of the character's passive ability.")]
        public string passiveName = "Passive";

        [TextArea(2, 6)]
        [Tooltip("Description of the character's passive ability.")]
        public string passiveDescription;

        [Header("Starting Relic")]
        [Tooltip("Optional starting relic identifier. This remains editor-authored until a dedicated RelicData asset type is added.")]
        public string startingRelic;

        [Header("Starting Deck")]
        [Tooltip("Cards included in this character's starting deck. Add CardData assets here in the desired decklist.")]
        public List<CardData> startingDeck = new List<CardData>();

        [Header("Curated Decks")]
        [Tooltip("Decks this character can select in the Deck Builder and Battle loadout selector.")]
        public List<CharacterDeckDefinition> availableDecks = new List<CharacterDeckDefinition>();
    }

    

    public enum CharacterClass
    {
        
        Warrior,
        Defender,
        Rogue,
        Mage,
        Support
    }

    public enum CharacterRole
    {
        Damage,
        Tank,
        Support,
        Control,
        Hybrid
    }

    public enum CharacterBiome
    {
        Forest,
        Cave,
        Swamp,
        Mountain,
        Ruins,
        
    }
}
