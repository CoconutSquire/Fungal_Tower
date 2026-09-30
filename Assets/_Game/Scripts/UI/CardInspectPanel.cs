using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FungalTower.Game.Data;

namespace FungalTower.Game.UI
{
    [DisallowMultipleComponent]
    public class CardInspectPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panelRoot;
        [SerializeField] private CardView cardView;
        [SerializeField] private TMP_Text detailText;
        [SerializeField] private Button closeButton;

        public void Show(CardData data)
        {
            if (panelRoot != null) panelRoot.SetActive(true);
            if (cardView != null) cardView.SetData(data);
            if (detailText != null && data != null)
            {
                detailText.text =
                    data.cardName + " " +
                    data.description + " " +
                    "Cost: " + data.energyCost + " " +
                    "Rarity: " + data.rarity + " " +
                    "Type: " + data.type + " " +
                    "Damage: " + data.damage + " " +
                    "Block: " + data.block + " " +
                    "Shield: " + data.shield + " " +
                    "Heal: " + data.heal + " " +
                    "Draw: " + data.draw + " " +
                    "Power: " + data.power + " " +
                    "Burn: " + data.burn + " " +
                    "Poison: " + data.poison + " ";
            }
        }

        public void Hide()
        {
            if (panelRoot != null) panelRoot.SetActive(false);
        }

        private void Awake()
        {
            if (closeButton != null)
                closeButton.onClick.AddListener(Hide);
            Hide();
        }
    }
}
