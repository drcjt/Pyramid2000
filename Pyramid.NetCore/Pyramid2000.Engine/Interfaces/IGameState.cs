using System.Collections.Generic;

namespace Pyramid2000.Engine.Interfaces
{
    public delegate void AwardAchievementHandler(IAchievement achievement);

    public interface IGameState
    {
        string LastRoom { get; set; }
        int TurnCount { get; set; }
        bool GameOver { get; set; }
        bool AskToReincarnate { get; set; }
        int ReincarnateCount { get; set; }
        int BatteryLife { get; set; }
        IList<IAchievement> GetAchievements();

        void AwardAchievement(IAchievement achievement);

        event AwardAchievementHandler AchievementAwarded;
    }
}
