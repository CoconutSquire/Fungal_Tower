using UnityEngine;

namespace FungalTower.Game.Data
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Fungal Tower/Card")]
    public class CardData : ScriptableObject
    {
        [Header("Identity")]
        public string cardName;
        [TextArea(2, 5)] public string description;
        public Sprite artwork;

        [Header("Cost & Classification")]
        [Min(0)] public int energyCost;
        public CardRarity rarity;
        public CardType type;

        [Header("Basic Effect Values")]
        public int damage;
        public int block;
        public int shield;
        public int heal;
        public int draw;
        public int power;
        public int burn;
        public int poison;
        
    }

    public enum CardRarity { Common, Uncommon, Rare, Special }
    public enum CardType { Attack, Skill, Power }
}
