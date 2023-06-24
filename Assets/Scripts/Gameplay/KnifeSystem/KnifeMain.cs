using Gameplay.TapSystem;

namespace Gameplay.KnifeSystem
{
    public class KnifeMain
    {
        private readonly KnifeThrower _knifeThrower;
        private readonly TapObserver _tapObserver;
        private readonly IKnifesBar _knifesBar;
        
        public KnifeMain(KnifeThrower knifeThrower, TapObserver tapObserver, IKnifesBar knifesBar)
        {
            _knifeThrower = knifeThrower;
            _tapObserver = tapObserver;
            _knifesBar = knifesBar;
        }
        
        public void Initialize()
        {
            _tapObserver.Tapped += OnTap;
            _knifeThrower.TakeKnife();
        }
        
        public void Dispose()
        {
            _tapObserver.Tapped -= OnTap;
        }
        
        private void OnTap()
        {
            _knifeThrower.ThrowKnife();
            _knifeThrower.TakeKnife();
            _knifesBar.SubtractKnife();
        }
    }
}