using UnityEngine;
using FungalTower.Game.Data;

namespace FungalTower.Game.UI
{
    public class CardLibraryController : MonoBehaviour
    {
        public enum OwnershipFilter { All, Obtained, Unobtained }
        public enum RarityFilter { All, Common, Uncommon, Rare, Special }
        public enum TypeFilter { All, Attack, Skill, Power }

        [Header("Editor-Authored Cards")]
        [Tooltip("Optional explicit list. When empty, CardLibraryItem components under Content are discovered automatically.")]
        [SerializeField] private CardLibraryItem[] cardItems;

        [Header("Current Filters")]
        [SerializeField] private OwnershipFilter ownershipFilter = OwnershipFilter.All;
        [SerializeField] private RarityFilter rarityFilter = RarityFilter.All;
        [SerializeField] private TypeFilter typeFilter = TypeFilter.All;

        private void Awake()
        {
            RefreshItems();
        }

        private void OnValidate()
        {
            if (!Application.isPlaying)
                return;

            RefreshItems();
        }

        public void SetOwnershipFilter(int value)
        {
            ownershipFilter = (OwnershipFilter)Mathf.Clamp(value, 0, 2);
            RefreshItems();
        }

        public void SetRarityFilter(int value)
        {
            rarityFilter = (RarityFilter)Mathf.Clamp(value, 0, 4);
            RefreshItems();
        }

        public void SetTypeFilter(int value)
        {
            typeFilter = (TypeFilter)Mathf.Clamp(value, 0, 3);
            RefreshItems();
        }

        public void ClearFilters()
        {
            ownershipFilter = OwnershipFilter.All;
            rarityFilter = RarityFilter.All;
            typeFilter = TypeFilter.All;
            RefreshItems();
        }

        public void RefreshItems()
        {
            if (cardItems == null || cardItems.Length == 0)
                cardItems = GetComponentsInChildren<CardLibraryItem>(true);

            foreach (var item in cardItems)
            {
                if (item == null)
                    continue;

                var data = item.Data;
                bool visible = data != null
                    && MatchesOwnership(item)
                    && MatchesRarity(data)
                    && MatchesType(data);

                item.gameObject.SetActive(visible);
            }
        }

        private bool MatchesOwnership(CardLibraryItem item)
        {
            return ownershipFilter switch
            {
                OwnershipFilter.All => true,
                OwnershipFilter.Obtained => item.Obtained,
                OwnershipFilter.Unobtained => !item.Obtained,
                _ => true
            };
        }

        private bool MatchesRarity(CardData data)
        {
            return rarityFilter == RarityFilter.All
                || data.rarity.ToString() == rarityFilter.ToString();
        }

        private bool MatchesType(CardData data)
        {
            return typeFilter == TypeFilter.All
                || data.type.ToString() == typeFilter.ToString();
        }
    }
}
