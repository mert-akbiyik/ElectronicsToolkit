using PCBToolkit.Views;

namespace PCBToolkit
{
    public partial class MainPage : ContentPage
    {
        private double _handleStartY;
        private bool _isNavigating;

        private readonly Color _neutralBackground =
            Color.FromArgb("#0B0F14");

        private readonly Color _smdAmbientColor =
            Color.FromArgb("#0D1820");

        private readonly Color _thtAmbientColor =
            Color.FromArgb("#18120E");

        private readonly Color _neutralSliderColor =
            Color.FromArgb("#151D26");

        private readonly Color _neutralStrokeColor =
            Color.FromArgb("#687681");

        private readonly Color _neutralWaveColor =
            Color.FromArgb("#8998A3");

        private readonly Color _neutralLineColor =
            Color.FromArgb("#A7B1B9");

        private readonly Color _smdColor =
            Color.FromArgb("#4DB8FF");

        private readonly Color _thtColor =
            Color.FromArgb("#D9823B");

        public MainPage()
        {
            InitializeComponent();

            Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object? sender, EventArgs e)
        {
            StartWaveAnimation();
        }

        private void StartWaveAnimation()
        {
            new Animation
            {
                {
                    0, 1,
                    new Animation(v =>
                    {
                        Wave1.Scale = 1 + (v * 0.22);
                        Wave1.Opacity = 0.45 * (1 - v);
                    })
                },
                {
                    0.20, 1,
                    new Animation(v =>
                    {
                        Wave2.Scale = 1 + (v * 0.22);
                        Wave2.Opacity = 0.35 * (1 - v);
                    })
                },
                {
                    0.40, 1,
                    new Animation(v =>
                    {
                        Wave3.Scale = 1 + (v * 0.22);
                        Wave3.Opacity = 0.25 * (1 - v);
                    })
                }
            }
            .Commit(
                this,
                "SliderWaveAnimation",
                16,
                1800,
                Easing.Linear,
                repeat: () => true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _isNavigating = false;
            _handleStartY = 0;

            MainLayout.Opacity = 1;
            MainLayout.Scale = 1;
            MainLayout.BackgroundColor =
                _neutralBackground;

            SliderVisual.TranslationX = 0;
            SliderVisual.TranslationY = 0;

            SmdCard.Opacity = 1;
            ThtCard.Opacity = 1;

            // EN: Slider body always remains neutral
            // TR: Slider gövdesi her zaman nötr kalır
            DragHandle.BackgroundColor =
                _neutralSliderColor;

            DragHandle.Stroke =
                _neutralStrokeColor;

            SliderLightLine.BackgroundColor =
                _neutralLineColor;

            SliderLightLine.Shadow =
                CreateGlowShadow(
                    _neutralLineColor,
                    7,
                    0.45f);

            Wave1.Stroke =
                _neutralWaveColor;

            Wave2.Stroke =
                _neutralWaveColor;

            Wave3.Stroke =
                _neutralWaveColor;

            UpdateSliderShadow(
                _neutralStrokeColor,
                0.35f);
        }

        private async void OnDividerPanUpdated(
            object? sender,
            PanUpdatedEventArgs e)
        {
            if (_isNavigating)
                return;

            double contentHeight =
                ContentArea.Height;

            if (contentHeight <= 0)
                return;

            double maxY =
                (contentHeight / 4) + 15;

            if (maxY <= 0)
                return;

            double triggerDistance =
                maxY * 0.90;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    {
                        _handleStartY =
                            SliderVisual.TranslationY;

                        break;
                    }

                case GestureStatus.Running:
                    {
                        double newY =
                            _handleStartY + e.TotalY;

                        newY =
                            Math.Clamp(
                                newY,
                                -maxY,
                                maxY);

                        SliderVisual.TranslationY =
                            newY;

                        UpdateInteractiveState(
                            newY,
                            maxY);

                        break;
                    }

                case GestureStatus.Completed:
                    {
                        // EN: Upward selection opens the SMD menu
                        // TR: Yukarı seçim SMD menüsünü açar
                        if (SliderVisual.TranslationY <= -triggerDistance)
                        {
                            _isNavigating = true;

                            await SliderVisual.TranslateToAsync(
                                0,
                                -maxY,
                                180,
                                Easing.CubicOut);

                            UpdateInteractiveState(
                                -maxY,
                                maxY);

                            GiveHapticFeedback();

                            await NavigateWithTransitionAsync(
                                nameof(SmdPage));
                        }

                        // EN: Downward selection opens the THT menu
                        // TR: Aşağı seçim THT menüsünü açar
                        else if (SliderVisual.TranslationY >= triggerDistance)
                        {
                            _isNavigating = true;

                            await SliderVisual.TranslateToAsync(
                                0,
                                maxY,
                                180,
                                Easing.CubicOut);

                            UpdateInteractiveState(
                                maxY,
                                maxY);

                            GiveHapticFeedback();

                            await NavigateWithTransitionAsync(
                                nameof(ThtPage));
                        }

                        // EN: Return to neutral state when threshold is not reached
                        // TR: Eşiğe ulaşılmadığında nötr duruma dön
                        else
                        {
                            await ResetSliderAsync();
                        }

                        break;
                    }

                case GestureStatus.Canceled:
                    {
                        await ResetSliderAsync();

                        break;
                    }
            }
        }

        private void UpdateInteractiveState(
            double positionY,
            double maxY)
        {
            if (maxY <= 0)
                return;

            double progress =
                Math.Clamp(
                    Math.Abs(positionY) / maxY,
                    0,
                    1);

            bool isSmdDirection =
                positionY < 0;

            Color targetColor =
                isSmdDirection
                    ? _smdColor
                    : _thtColor;

            Color ambientTarget =
                isSmdDirection
                    ? _smdAmbientColor
                    : _thtAmbientColor;

            // EN: Keep the slider body neutral during interaction
            // TR: Etkileşim sırasında slider gövdesini nötr tut
            DragHandle.BackgroundColor =
                _neutralSliderColor;

            DragHandle.Stroke =
                _neutralStrokeColor;

            // EN: Only the inner line changes color
            // TR: Yalnızca iç çizgi renk değiştirir
            Color lineColor =
                InterpolateColor(
                    _neutralLineColor,
                    targetColor,
                    progress);

            SliderLightLine.BackgroundColor =
                lineColor;

            SliderLightLine.Shadow =
                CreateGlowShadow(
                    lineColor,
                    7 + (8 * progress),
                    (float)(0.45 + (0.45 * progress)));

            // EN: Animated waves follow the selected direction
            // TR: Animasyon dalgaları seçilen yönün rengini takip eder
            Color waveColor =
                InterpolateColor(
                    _neutralWaveColor,
                    targetColor,
                    progress);

            Wave1.Stroke = waveColor;
            Wave2.Stroke = waveColor;
            Wave3.Stroke = waveColor;

            // EN: Apply a subtle ambient tint to the page
            // TR: Sayfaya hafif ortam rengi uygula
            MainLayout.BackgroundColor =
                InterpolateColor(
                    _neutralBackground,
                    ambientTarget,
                    progress * 0.85);

            // EN: Fade only the opposite card
            // TR: Yalnızca karşı kartı hafifçe soldur
            double fadedOpacity =
                1 - (0.38 * progress);

            if (isSmdDirection)
            {
                SmdCard.Opacity = 1;
                ThtCard.Opacity =
                    fadedOpacity;
            }
            else
            {
                ThtCard.Opacity = 1;
                SmdCard.Opacity =
                    fadedOpacity;
            }

            // EN: Only the outer glow follows the active color
            // TR: Yalnızca dış glow aktif rengi takip eder
            UpdateSliderShadow(
                targetColor,
                (float)(0.30 + (0.55 * progress)));
        }

        private async Task ResetSliderAsync()
        {
            Task sliderTask =
                SliderVisual.TranslateToAsync(
                    0,
                    0,
                    180,
                    Easing.CubicOut);

            Task smdOpacityTask =
                SmdCard.FadeToAsync(
                    1,
                    180,
                    Easing.CubicOut);

            Task thtOpacityTask =
                ThtCard.FadeToAsync(
                    1,
                    180,
                    Easing.CubicOut);

            await Task.WhenAll(
                sliderTask,
                smdOpacityTask,
                thtOpacityTask);

            MainLayout.BackgroundColor =
                _neutralBackground;

            // EN: Restore the fixed neutral slider body
            // TR: Sabit nötr slider gövdesini geri yükle
            DragHandle.BackgroundColor =
                _neutralSliderColor;

            DragHandle.Stroke =
                _neutralStrokeColor;

            SliderLightLine.BackgroundColor =
                _neutralLineColor;

            SliderLightLine.Shadow =
                CreateGlowShadow(
                    _neutralLineColor,
                    7,
                    0.45f);

            Wave1.Stroke =
                _neutralWaveColor;

            Wave2.Stroke =
                _neutralWaveColor;

            Wave3.Stroke =
                _neutralWaveColor;

            UpdateSliderShadow(
                _neutralStrokeColor,
                0.35f);

            _handleStartY = 0;
        }

        private async Task NavigateWithTransitionAsync(
            string route)
        {
            // EN: Softly fade and scale the current screen before navigation
            // TR: Geçişten önce mevcut ekranı yumuşakça soldur ve küçült
            Task fadeTask =
                MainLayout.FadeToAsync(
                    0.82,
                    150,
                    Easing.CubicOut);

            Task scaleTask =
                MainLayout.ScaleToAsync(
                    0.985,
                    150,
                    Easing.CubicOut);

            await Task.WhenAll(
                fadeTask,
                scaleTask);

            await Shell.Current.GoToAsync(
                route);
        }

        private static Color InterpolateColor(
            Color start,
            Color end,
            double progress)
        {
            progress =
                Math.Clamp(
                    progress,
                    0,
                    1);

            double red =
                start.Red +
                ((end.Red - start.Red) * progress);

            double green =
                start.Green +
                ((end.Green - start.Green) * progress);

            double blue =
                start.Blue +
                ((end.Blue - start.Blue) * progress);

            double alpha =
                start.Alpha +
                ((end.Alpha - start.Alpha) * progress);

            return new Color(
                (float)red,
                (float)green,
                (float)blue,
                (float)alpha);
        }

        private static Shadow CreateGlowShadow(
              Color color,
              double radius,
              float opacity)
        {
            return new Shadow
            {
                Brush = color,
                Offset = new Point(0, 0),
                Radius = (float)radius,
                Opacity = opacity
            };
        }

        private void UpdateSliderShadow(
            Color color,
            float opacity)
        {
            DragHandle.Shadow =
                new Shadow
                {
                    Brush = color,
                    Offset = new Point(0, 0),
                    Radius = 18,
                    Opacity = opacity
                };
        }

        private void GiveHapticFeedback()
        {
            bool hapticEnabled =
                Preferences.Default.Get(
                    "HapticEnabled",
                    true);

            if (!hapticEnabled)
                return;

            try
            {
                HapticFeedback.Default.Perform(
                    HapticFeedbackType.Click);
            }
            catch (FeatureNotSupportedException)
            {
                // EN: Ignore devices without haptic feedback support
                // TR: Haptic desteği olmayan cihazlarda işlem yapma
            }
        }

        protected override bool OnBackButtonPressed()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                bool exit =
                    await DisplayAlertAsync(
                        "Electronics Toolkit",
                        "Uygulamadan çıkmak istiyor musunuz?",
                        "Evet",
                        "Hayır");

                if (exit)
                {
                    Application.Current?.Quit();
                }
            });

            return true;
        }

        private async void OnLinkedInTapped(
            object? sender,
            TappedEventArgs e)
        {
            await Launcher.Default.OpenAsync(
                "https://www.linkedin.com/in/mert-akbiyik");
        }

        private async void OnGitHubTapped(
            object? sender,
            TappedEventArgs e)
        {
            await Launcher.Default.OpenAsync(
                "https://github.com/mert-akbiyik");
        }

        private async void OnSettingsTapped(
            object? sender,
            TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(
                nameof(SettingsPage));
        }

        private void OnPageSizeChanged(
            object? sender,
            EventArgs e)
        {
            if (Width <= 0 || Height <= 0)
                return;

            double widthScale =
                Width / 412.0;

            double heightScale =
                Height / 915.0;

            double scale =
                Math.Min(
                    widthScale,
                    heightScale);

            scale =
                Math.Clamp(
                    scale,
                    0.82,
                    1.15);

            // EN: Scale header and footer from the Pixel 7 reference layout
            // TR: Header ve footer'ı Pixel 7 referans tasarımına göre ölçekle
            double headerHeight =
                90 * scale;

            double footerHeight =
                70 * scale;

            MainLayout.RowDefinitions[0].Height =
                new GridLength(
                    headerHeight);

            MainLayout.RowDefinitions[2].Height =
                new GridLength(
                    footerHeight);

            // EN: Keep content padding responsive
            // TR: İçerik padding değerini responsive tut
            double contentPadding =
                Math.Clamp(
                    18 * widthScale,
                    12,
                    22);

            ContentArea.Padding =
                new Thickness(
                    contentPadding);

            // EN: Scale the settings button within safe limits
            // TR: Ayarlar butonunu güvenli sınırlar içinde ölçekle
            double settingsSize =
                Math.Clamp(
                    34 * scale,
                    30,
                    38);

            SettingsButton.WidthRequest =
                settingsSize;

            SettingsButton.HeightRequest =
                settingsSize;

            SettingsButton.Margin =
                new Thickness(
                    0,
                    -2 * scale,
                    Math.Clamp(
                        24 * widthScale,
                        16,
                        28),
                    0);

            SettingsIcon.FontSize =
                Math.Clamp(
                    24 * scale,
                    21,
                    26);

            // EN: Keep the capsule slider responsive
            // TR: Kapsül slider'ı responsive tut
            double sliderScale =
                Math.Clamp(
                    scale,
                    0.88,
                    1.05);

            SliderVisual.Scale =
                sliderScale;

            // EN: Keep footer spacing responsive
            // TR: Footer boşluklarını responsive tut
            double footerHorizontalPadding =
                Math.Clamp(
                    14 * widthScale,
                    8,
                    16);

            double footerVerticalPadding =
                Math.Clamp(
                    8 * scale,
                    5,
                    9);

            FooterArea.Padding =
                new Thickness(
                    footerHorizontalPadding,
                    footerVerticalPadding);

            FooterArea.ColumnSpacing =
                Math.Clamp(
                    14 * widthScale,
                    7,
                    16);

            // EN: Reduce footer button padding on small screens
            // TR: Küçük ekranlarda footer buton paddinglerini azalt
            if (Width < 360)
            {
                LinkedInButton.Padding =
                    new Thickness(
                        8,
                        6);

                GitHubButton.Padding =
                    new Thickness(
                        8,
                        6);
            }
            else
            {
                LinkedInButton.Padding =
                    new Thickness(
                        12,
                        7);

                GitHubButton.Padding =
                    new Thickness(
                        10,
                        6);
            }
        }
    }
}