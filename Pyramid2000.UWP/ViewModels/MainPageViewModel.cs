using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Pyramid2000.Engine.Interfaces;
using Pyramid2000.Engine.Implementation;
using Pyramid2000.Engine;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.Storage;
using Pyramid2000.UWP.Services.GameSettingsServices;
using Pyramid2000.UWP.Services.GameService;

namespace Pyramid2000.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        readonly Services.SettingsServices.SettingsService _SettingService;

        public GamePartViewModel GamePartViewModel { get; } = new GamePartViewModel();

        public MainPageViewModel()
        {
            _SettingService = Services.SettingsServices.SettingsService.Instance;
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            // Ensure setting changes are respected
            SettingsChanged(null, null);

            if (suspensionState.Any())
            {
                GamePartViewModel.State = suspensionState["GameState"]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState["GameState"] = GamePartViewModel.State;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        private void SettingsChanged(Windows.Storage.ApplicationData sender, object args)
        {
            RaisePropertyChanged(nameof(TextSize));
        }

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public int TextSize { get { return _SettingService.TextSize; } }
        public bool ShowCompass { get { return _SettingService.ShowCompass; } }
    }

    public class GamePartViewModel : ViewModelBase
    {
        private IPrinter _printer;

        private readonly GameService _gameService = new GameService();

        public void SetupGame(IPrinter printer, string state = null)
        {
            _printer = printer;

            _gameService.PropertyChanged += Instance_PropertyChanged;
            _gameService.SetupGame(printer, state);
        }

        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "InventoryItems")
            {
                UpdateInventoryItems();
            }
        }

        public void PrintLn(string line)
        {
            _printer.PrintLn(line);
        }

        // Consider exposing IPrinter functionality via an ObservableCollection<string> instead of via interface
        // Alternatively expose via events 

        private DelegateCommand<string> _processPlayerInputCommand;
        public DelegateCommand<string> ProcessPlayerInputCommand
        {
            get
            {
                return _processPlayerInputCommand
                    ?? (_processPlayerInputCommand = new DelegateCommand<string>(
                        command =>
                        {
                            _gameService.ProcessPlayerInput(command);
                            //UpdateAchievements();
                        }));
            }
        }


        public void GotoSettings() => NavigationService.Navigate(typeof(Views.SettingsPage), 0);
        public void GotoAbout() => NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public DelegateCommand _rateAndReviewCommand;
        public DelegateCommand RateAndReviewCommand
        {
            get
            {
                return _rateAndReviewCommand
                    ?? (_rateAndReviewCommand = new DelegateCommand(
                        async () =>
                        {
                            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=33ddb4b9-5fc5-4a4d-bec3-5adc282c6b3a"));
                        }));
            }
        }

        private void UpdateInventoryItems()
        {
            var items = _gameService.PlayerItems;
            var toRemove = new List<IItem>();
            foreach (var item in _inventoryItems)
            {
                if (!items.Contains(item))
                {
                    toRemove.Add(item);
                }
            }
            foreach (var item in toRemove)
            {
                _inventoryItems.Remove(item);
            }

            foreach (var item in items)
            {
                if (!_inventoryItems.Contains(item))
                {
                    _inventoryItems.Add(item);
                }
            }
        }

        /*
        public void UpdateAchievements()
        {
            var achievements = _gameState.GetAchievements();

            var toRemove = new List<IAchievement>();
            foreach (var achievement in _achievements)
            {
                if (!achievements.Contains(achievement))
                {
                    toRemove.Add(achievement);
                }
            }
            foreach (var achievement in toRemove)
            {
                _achievements.Remove(achievement);
            }

            foreach (var achievement in achievements)
            {
                if (!_achievements.Contains(achievement))
                {
                    _achievements.Add(achievement);
                }
            }
        }
        */
        public bool GameOver { get { return _gameService.GameOver; } }

        public string State { get { return _gameService.State; } set { _gameService.State = value; } }

        public bool IsReincarnating { get { return _gameService.IsReincarnating; } }

        public string CurrentRoomName { get { return _gameService.CurrentRoomName; } }

        public IRoom CurrentRoom { get { return _gameService.CurrentRoom; } }

        public bool IsRoomLit { get { return _gameService.IsRoomLit; } }

        public IGameSettings Settings { get { return GameSettingsService.Instance; } }

        private readonly ObservableCollection<IAchievement> _achievements = new ObservableCollection<IAchievement>();
        public ObservableCollection<IAchievement> Achievements { get { return _achievements; } }

        private readonly ObservableCollection<IItem> _inventoryItems = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> InventoryItems { get { return _inventoryItems; } }

        public IList<string> GetWords(bool noun) { return null; /* _parser.GetWords(noun); */ }
    }

}

