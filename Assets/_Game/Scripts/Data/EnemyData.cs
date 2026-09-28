using UnityEngine;

namespace FungalTower.Game.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Fungal Tower/Enemy")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName;
        public Sprite artwork;
        [Min(1)] public int maxHealth = 20;
        [Min(0)] public int armor;
        [Min(0)] public int attackDamage = 5;
        [TextArea(2, 5)] public string description;
        [TextArea(2, 5)] public string designerNotes;
    }
}
