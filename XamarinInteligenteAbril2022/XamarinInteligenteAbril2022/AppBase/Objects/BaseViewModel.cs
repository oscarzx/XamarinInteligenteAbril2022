using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace XamarinInteligenteAbril2022.AppBase.Objects
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private string subtitle;
        public string Subtitle
        {
            get => subtitle;
            set => SetProperty(ref subtitle, value);
        }

        private string pageId;
        public string PageId
        {
            get => pageId;
            set => SetProperty(ref pageId, value);
        }

        private string icon;
        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public ICommand OnAppearingCommand { get; set; }

        public ICommand OnDisappearing { get; set; }

        public virtual void OnBackButtonPressed()
        {

        }

        public virtual void Save()
        {

        }

        private Dictionary<string, object> navigationParametersToSend;

        protected Dictionary<string, object> NavigationParametersToSend
        {
            get
            {
                if (navigationParametersToSend is null)
                    navigationParametersToSend = new();
                return navigationParametersToSend;
            }
        }
    }
}
