using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Pyramid2000.MVVM;
using Pyramid2000.Services;

namespace Pyramid2000.ViewModels
{
    public class MainPageViewModel
    {
        public GamePartViewModel GamePartViewModel { get; } = new GamePartViewModel();
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
    }

    public class SettingsPartViewModel
    {
        ISettingsService _settings = SettingsService.Instance;

        public bool ShowCompass { get { return _settings.ShowCompass; } }
        public int TextSize { get { return _settings.TextSize; } }
    }

    public class GamePartViewModel
    {
        private IPrinter _printer;
        private IGameState _gameState;
        private IGame _game;
        private IPlayer _player;
        private IRooms _rooms;
        private IItems _items;

        public void SetupGame(IPrinter printer)
        {
            _printer = new Printer(printer, App.GameSettings);
            _items = new Items();
            _player = new Player(_items);
            _player.CurrentRoom = "room_1";
            IParser parser = new Parser(_player, _printer, _items, App.GameSettings);
            _rooms = new Rooms(_items);
            _gameState = new GameState();
            IScripter scripter = new Scripter(_printer, _items, _rooms, _player, _gameState, App.GameSettings);
            _rooms.Scripter = scripter;

            IDefaultScripter defaultScripter = new DefaultScripter();

            _inventoryItems.Clear();

            _game = new Game(_player, _printer, parser, scripter, _rooms, defaultScripter, _items, _gameState);

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

        public bool GameOver { get { return _gameState.GameOver; } }

        public string State { get { return _game.State; } set { _game.State = value; } }

        public string CurrentRoomName { get { return _player.CurrentRoom; } }

        public IRoom CurrentRoom { get { return _rooms.GetRoom(_player.CurrentRoom); } }

        public IGameSettings Settings { get { return App.GameSettings; } }


        private ObservableCollection<IItem> _inventoryItems = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> InventoryItems { get { return _inventoryItems; } }
    }
}
