using UnityEngine;
using FungalTower.Game.Data;

namespace FungalTower.Game.UI
{
    [DisallowMultipleComponent]
    public class CardLibraryItem : MonoBehaviour
    {
        [Header("Collection")]
        [Tooltip("Whether this card has been obtained by the player.")]
        [SerializeField] private bool obtained = true;

        [Header("Presentation")]
        [SerializeField] private CardView cardView;

        public bool Obtained => obtained;
        public CardData Data => cardView != null ? cardView.Data : null;

        public void Inspect()
        {
            var library = GetComponentInParent<CardLibraryController>();
            if (library != null)
                library.Inspect(this);
        }

        public void SetObtained(bool value)
        {
            obtained = value;
        }

        private void Reset()
        {
            cardView = GetComponent<CardView>();
        }

        private void OnValidate()
        {
            if (cardView == null)
                cardView = GetComponent<CardView>();
        }
    }
}
