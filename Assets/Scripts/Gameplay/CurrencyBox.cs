using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class CurrencyBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyText;

        public void SetCurrency(int value)
        {
            _currencyText.text = value.ToString();
        }
    }
}