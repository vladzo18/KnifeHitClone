using UnityEngine;

namespace Gameplay.KnifeSystem
{
    public class KnifeThrower
    {
        private readonly KnifeFactory _knifeFactory;
        private readonly Vector3 _knifePosition;
        private readonly int _throwsCount;

        private KnifeView _currentKnife = null;
        private int _currentThrows = 0;

        public KnifeThrower(KnifeFactory knifeFactory, int throwsCount, Vector3 knifePosition)
        {
            _knifeFactory = knifeFactory;
            _throwsCount = throwsCount;
            _knifePosition = knifePosition;
        }

        public void TakeKnife()
        {
            _currentKnife = _knifeFactory.CreateKnife(_knifePosition).GetComponent<KnifeView>();
        }
        
        public void ThrowKnife()
        {
            if (_currentThrows == _throwsCount)
            {
                return;
            }
            
            _currentKnife.MakeThrow();
            _currentKnife = null;
            _currentThrows--;
        }
    }
}