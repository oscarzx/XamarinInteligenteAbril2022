using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using XamarinInteligenteAbril2022.AppBase.Objects;

namespace XamarinInteligenteAbril2022.AppBase.Controls
{
    [ContentProperty("LayoutContent")]
    public class BindedPage : ContentPage
    {
        public static readonly BindableProperty LayoutContentProperty =
            BindableProperty.Create(nameof(LayoutContent), typeof(View), typeof(BindedPage),
                null, propertyChanged: OnContentChanged);
        public View LayoutContent
        {
            get => (View)GetValue(LayoutContentProperty);
            set => SetValue(LayoutContentProperty, value);

        }

        private static void OnContentChanged(BindableObject bindableObject, object oldValue, object newValue)
        {
            if (bindableObject is BindedPage bindedPage)
            {
                var ContentView = new ContentView
                {
                    ControlTemplate = App.Current.Resources["MasterTemplate"] as ControlTemplate,
                    Content = newValue as View
                };

                bindedPage.Content = ContentView;
            }
        }

        public static readonly BindableProperty PageIdProperty
            = BindableProperty.Create(nameof(PageId), typeof(string), typeof(BindedPage), "00");

        public string PageId
        {
            get => (string)GetValue(PageIdProperty);
            set => SetValue(PageIdProperty, value);
        }

        public static readonly BindableProperty SubtitleProperty
            = BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(BindedPage), "00");

        public string Subtitle
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is BaseViewModel context)
                context?.OnAppearingCommand?.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext is BaseViewModel context)
                context?.OnDisappearing?.Execute(null);
        }

        protected override bool OnBackButtonPressed()
        {
            if (BindingContext is BaseViewModel context)
                OnBackButtonPressed();
            return base.OnBackButtonPressed();

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            Binding titleBinding = new("Title");
            SetBinding(TitleProperty, titleBinding);

            Binding subtitleBinding = new("Subtitle");
            SetBinding(SubtitleProperty, subtitleBinding);

            Binding pageIdBinding = new("PageId");
            SetBinding(PageIdProperty, pageIdBinding);

            Binding isBusyBinding = new("isBusy");
            SetBinding(IsBusyProperty, isBusyBinding);
        }

        public BindedPage()
        {
            //Respeta área de arriba d la pantalla, solo para iOS
            //TODO: Se comenta línea para probar error
            On<iOS>().SetUseSafeArea(true);
        }
    }
}
