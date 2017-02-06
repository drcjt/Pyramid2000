using System.ComponentModel;

using Pyramid2000.Engine.Implementation;
using Pyramid2000.Engine.Interfaces;
using Pyramid2000.Engine;
using Pyramid2000.UWP.Services.GameSettingsServices;
using System.Collections.Generic;

namespace Pyramid2000.UWP.Services.GameService
{
    public class GameService : INotifyPropertyChanged
    {
        private IPrinter _printer;
        private IGameState _gameState;
        private IGame _game;
        private IPlayer _player;
        private IRooms _rooms;
        private IItems _items;
        private IParser _parser;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetupGame(IPrinter printer, string state = null)
        {
            IResources resources = new Resources();
            _printer = printer;
            _items = new Items(resources);
            _player = new Player(_items);
            _player.CurrentRoom = "room_1";
            _parser = new Parser(_player, _printer, _items, GameSettingsService.Instance, resources);
            _rooms = new Rooms(_items, resources);
            _gameState = new GameState();
            IScripter scripter = new Scripter(_printer, _items, _rooms, _player, _gameState, GameSettingsService.Instance, resources);
            _rooms.Scripter = scripter;

            IDefaultScripter defaultScripter = new DefaultScripter(resources);

            _game = new Game(_player, _printer, _parser, scripter, _rooms, defaultScripter, _items, _gameState);

            if (state != null)
            {
                _game.State = state;
                OnPropertyChange("InventoryItems");
            }
            else
            {
                _game.Init();
            }
        }

        public void ProcessPlayerInput(string command)
        {
            _game.ProcessPlayerInput(command);
            OnPropertyChange("InventoryItems");
            OnPropertyChange("Achievements");
        }

        public string State { get { return _game.State; } set { _game.State = value; } }

        public bool GameOver { get { return _gameState.GameOver; } }

        public bool IsReincarnating { get { return _gameState.AskToReincarnate; } }

        public string CurrentRoomName { get { return _player.CurrentRoom; } }

        public IRoom CurrentRoom { get { return _rooms.GetRoom(_player.CurrentRoom); } }

        public bool IsRoomLit { get { return _rooms.IsRoomLit(CurrentRoomName); } }

        public IList<IItem> PlayerItems { get { return _player.Items; } }
    }
}
