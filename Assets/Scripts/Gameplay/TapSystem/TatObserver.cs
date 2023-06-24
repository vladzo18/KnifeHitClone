using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.TapSystem
{
    public class TapObserver : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action Tapped;

        private void Start()
        {
            _button.onClick.AddListener(() => Tapped?.Invoke());
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}