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

namespace Pyramid2000.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public GamePartViewModel GamePartViewModel { get; } = new GamePartViewModel();
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();

        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                //Value = suspensionState[nameof(Value)]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                //suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

    }

    public class GamePartViewModel : ViewModelBase
    {
        private IPrinter _printer;
        private IGameState _gameState;
        private IGame _game;
        private IPlayer _player;
        private IRooms _rooms;
        private IItems _items;
        private IParser _parser;

        public void SetupGame(IPrinter printer)
        {
            IResources resources = new Resources();
            _printer = printer;
            _items = new Items(resources);
            _player = new Player(_items);
            _player.CurrentRoom = "room_1";
            _parser = new Parser(_player, _printer, _items, App.GameSettings, resources);
            _rooms = new Rooms(_items, resources);
            _gameState = new GameState();
            IScripter scripter = new Scripter(_printer, _items, _rooms, _player, _gameState, App.GameSettings, resources);
            _rooms.Scripter = scripter;

            IDefaultScripter defaultScripter = new DefaultScripter(resources);

            _inventoryItems.Clear();

            _game = new Game(_player, _printer, _parser, scripter, _rooms, defaultScripter, _items, _gameState);

            _game.Init();
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
                            _game.ProcessPlayerInput(command);
                            UpdateInventoryItems();
                            UpdateAchievements();
                        }));
            }
        }


        public void GotoSettings() => NavigationService.Navigate(typeof(Views.SettingsPage), 0);
        public void GotoAbout() => NavigationService.Navigate(typeof(Views.SettingsPage), 1);
        //public void GotoInstructionsPage() => NavigationService.Navigate(typeof(Views.SettingsPage), Value);

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
            var items = _player.Items;
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

        public bool GameOver { get { return _gameState.GameOver; } }

        public string State { get { return _game.State; } set { _game.State = value; } }

        public bool IsReincarnating { get { return _gameState.AskToReincarnate; } }

        public string CurrentRoomName { get { return _player.CurrentRoom; } }

        public IRoom CurrentRoom { get { return _rooms.GetRoom(_player.CurrentRoom); } }

        public bool IsRoomLit { get { return _rooms.IsRoomLit(CurrentRoomName); } }

        public IGameSettings Settings { get { return App.GameSettings; } }

        private ObservableCollection<IAchievement> _achievements = new ObservableCollection<IAchievement>();
        public ObservableCollection<IAchievement> Achievements { get { return _achievements; } }

        private ObservableCollection<IItem> _inventoryItems = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> InventoryItems { get { return _inventoryItems; } }

        public IList<string> GetWords(bool noun) { return _parser.GetWords(noun); }
    }

}

