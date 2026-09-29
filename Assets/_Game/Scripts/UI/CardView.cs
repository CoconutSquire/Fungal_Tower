using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FungalTower.Game.Data;

namespace FungalTower.Game.UI
{
    public class CardView : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private CardData cardData;

        [Header("UI")]
        [SerializeField] private Image artworkImage;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text energyCostText;
        [SerializeField] private TMP_Text damageText;
        [SerializeField] private TMP_Text blockText;
        [SerializeField] private TMP_Text rarityText;
        [SerializeField] private TMP_Text typeText;

        public CardData Data => cardData;

        private void OnValidate() => Refresh();

        public void SetData(CardData data)
        {
            cardData = data;
            Refresh();
        }

        public void Refresh()
        {
            if (cardData == null) return;

            if (artworkImage != null)
            {
                artworkImage.sprite = cardData.artwork;
                artworkImage.enabled = cardData.artwork != null;
            }

            if (nameText != null) nameText.text = cardData.cardName;
            if (descriptionText != null) descriptionText.text = cardData.description;
            if (energyCostText != null) energyCostText.text = cardData.energyCost.ToString();
            if (damageText != null) damageText.text = cardData.damage > 0 ? cardData.damage.ToString() : string.Empty;
            if (blockText != null) blockText.text = cardData.block > 0 ? cardData.block.ToString() : string.Empty;
            if (rarityText != null) rarityText.text = cardData.rarity.ToString();
            if (typeText != null) typeText.text = cardData.type.ToString();
        }
    }
}