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

        [Header("Presentation")]
        [Tooltip("Character portrait or artwork.")]
        public Sprite artwork;

        [Header("Passive Skill")]
        [Tooltip("Name of the character's passive skill.")]
        public string passiveSkillName = "Passive Skill";

        [TextArea(2, 6)]
        [Tooltip("Description of the character's passive skill.")]
        public string passiveSkillDescription;

        [Header("Starting Deck")]
        [Tooltip("Cards included in this character's starting deck. Add CardData assets here in the desired decklist.")]
        public List<CardData> startingDeck = new List<CardData>();
    }
}
