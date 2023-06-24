namespace Gameplay.LogSystem
{
    public class LogMain
    {
        private readonly LogView _logView;
        private readonly CurrencyBox _currencyBox;

        public LogMain(LogView logView, CurrencyBox currencyBox)
        {
            _logView = logView;
            _currencyBox = currencyBox;
        }

        public void Initialize()
        {
            foreach (var appleView in _logView.AppleViews)
            {
                appleView.AppleSplited += OnAppleSplited;
            }
        }

        public void Dispose()
        {
            foreach (var appleView in _logView.AppleViews)
            {
                appleView.AppleSplited -= OnAppleSplited;
            }
        }

        private void OnAppleSplited()
        {
            _currencyBox.SetCurrency(2);
        }
    }
}