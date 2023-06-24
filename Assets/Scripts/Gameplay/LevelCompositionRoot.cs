using Gameplay.KnifeSystem;
using Gameplay.LogSystem;
using Gameplay.TapSystem;
using UnityEngine;

namespace Gameplay
{
    public class LevelCompositionRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _knifePrefab;
        [SerializeField] private Transform _knifePosition;
        [SerializeField] private AvailableKnifesBar _availableKnifesBar;
        [SerializeField] private TapObserver _tapObserver;
        [SerializeField] private LogView _logView;
        [SerializeField] private CurrencyBox _currencyBox;

        private KnifeMain _knifeMain;
        private LogMain _logMain;
        
        private void Start()
        {
            KnifeFactory knifeFactory = new KnifeFactory(_knifePrefab);
            KnifeThrower knifeThrower = new KnifeThrower(knifeFactory, 7, _knifePosition.position);
            _knifeMain = new KnifeMain(knifeThrower, _tapObserver, _availableKnifesBar);
            _logMain = new LogMain(_logView, _currencyBox);
            _availableKnifesBar.SetKnifesCount(7);
            
        
            _knifeMain.Initialize();
            _logMain.Initialize();
        }
        
        private void OnDestroy()
        {
            _knifeMain.Dispose();
            _logMain.Dispose();
        }
    }
}