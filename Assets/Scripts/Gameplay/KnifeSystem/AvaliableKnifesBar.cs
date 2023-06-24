using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.KnifeSystem
{
    public class AvailableKnifesBar : MonoBehaviour, IKnifesBar
    {
        [SerializeField] private List<Image> _icons;
        [SerializeField] private Color _offColor;

        private int _knifesCount;
        private int _current;
        
        public void SetKnifesCount(int value)
        {
            _knifesCount = value;
            SetInitialView();
        }

        public void SubtractKnife()
        {
            _icons[_current++].color = _offColor;
        }

        private void SetInitialView()
        {
            int count = _icons.Count - _knifesCount;
            _current = count;
            
            for (int i = 0; i < _icons.Count; i++)
            {
                if (count > 0)
                {
                    _icons[i].enabled = false;
                    count--;
                }
                else
                {
                    _icons[i].enabled = true;
                }
            }
        }
    }
}