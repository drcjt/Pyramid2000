namespace Pyramid2000.Engine.Interfaces
{
    public interface IGame
    {
        void ProcessPlayerInput(string input);
        void Init();

        string State { get; set; }
    }
}
