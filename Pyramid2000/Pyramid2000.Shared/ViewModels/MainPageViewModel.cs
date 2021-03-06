﻿using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Pyramid2000.MVVM;
using Pyramid2000.Services;
using Pyramid2000.Engine.Implementation;
using System.ComponentModel;
using Pyramid2000;

namespace Pyramid2000.ViewModels
{
    public class MainPageViewModel
    {
        public GamePartViewModel GamePartViewModel { get; } = new GamePartViewModel();
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
    }

    public class SettingsPartViewModel : INotifyPropertyChanged
    {
        readonly ISettingsService _settings = SettingsService.Instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsPartViewModel()
        {
            _settings.PropertyChanged += _settings_PropertyChanged;
        }

        private void _settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        public bool ShowCompass { get { return _settings.ShowCompass; } }
        public int TextSize { get { return _settings.TextSize; } }
    }

    public class GamePartViewModel : ViewModelBase
    {
        private IPrinter _printer;
        private IGameState _gameState;
        private IGame _game;
        private IPlayer _player;
        private IRooms _rooms;
        private IParser _parser;

        public void SetupGame(IPrinter printer)
        {
            IResources resources = new Resources();
            _printer = printer;
            var items = new Items(resources);
            _player = new Player(items);
            _player.CurrentRoom = "room_1";
            _parser = new Parser(_player, _printer, items, App.GameSettings, resources);
            _rooms = new Rooms(items, resources);
            _gameState = new GameState();
            IScripter scripter = new Scripter(_printer, items, _rooms, _player, _gameState, App.GameSettings, resources);
            _rooms.Scripter = scripter;

            IDefaultScripter defaultScripter = new DefaultScripter(resources);

            _inventoryItems.Clear();

            _game = new Game(_player, _printer, _parser, scripter, _rooms, defaultScripter, items, _gameState);

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

        public NavigationCommand GotoSettingsPage { get { return new NavigationCommand(NavigationService, typeof(SettingsPage)); } }
        public NavigationCommand GotoAboutPage { get { return new NavigationCommand(NavigationService, typeof(About)); } }
        public NavigationCommand GotoInstructionsPage { get { return new NavigationCommand(NavigationService, typeof(Instructions)); } }

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

        public string CurrentRoomName {  get { return _player.CurrentRoom;  } }

        public IRoom CurrentRoom { get { return _rooms.GetRoom(_player.CurrentRoom); } }

        public bool IsRoomLit { get { return _rooms.IsRoomLit(CurrentRoomName); } }

        public IGameSettings Settings { get { return App.GameSettings; } }

        private readonly ObservableCollection<IAchievement> _achievements = new ObservableCollection<IAchievement>();
        public ObservableCollection<IAchievement> Achievements {  get { return _achievements; } }

        private readonly ObservableCollection<IItem> _inventoryItems = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> InventoryItems { get { return _inventoryItems; } }

        public IList<string> GetWords(bool noun) { return _parser.GetWords(noun); }
    }
}
