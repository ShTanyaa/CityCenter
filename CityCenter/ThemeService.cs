namespace CityCenter
{
    public class ThemeService
    {
        private bool _isLightTheme = true; 

        public bool IsLightTheme
        {
            get => _isLightTheme;
            set
            {
                if (_isLightTheme != value)
                {
                    _isLightTheme = value;
                    OnThemeChanged?.Invoke();
                }
            }
        }

        public event Action? OnThemeChanged;
    }
}
