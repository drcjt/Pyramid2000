using Script = System.Collections.Generic.List<System.Func<Pyramid2000.Engine.Interfaces.IScripter, bool>>;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IScripter
    {
        bool AwardAchievementX(string achievementName);
        bool MoveToRoomX(string roomID);
        bool AssertItemXIsInPack(string itemID);
        bool AssertItemXIsInCurrentRoom(string itemID);
        bool AssertItemXIsInCurrentRoomOrPack(string itemID);
        bool PrintMessageX(string message);
        bool PrintRoomDescription();
        bool MoveItemXToRoomY(string itemID, string roomID);
        bool Quit();
        bool PlayerDied();
        bool MoveItemXToLocationY(string itemID, string locationID);
        bool MoveItemXToCurrentRoom(string itemID);
        bool PrintScore();
        bool AssertItemXMatchesUserInput(string itemID);
        bool GetUserInputItem();
        bool GetItemXFromRoom(string itemID);
        bool PrintInventory();
        bool DropUserInputItem();
        bool DropItemX(string itemID);
        bool PrintOK();
        bool JumpToTopOfGameLoop();
        bool AssertRandomIsGreaterThanX(string number);
        bool MoveToRoomXIfItWasLastRoom(string roomID);
        bool MoveToLastRoom();
        bool AssertPackIsEmptyExceptForEmerald();
        bool SubScriptXAbortIfPass(Script script);
        bool Look();

        bool ParseScript(Script script, IItem item);
        bool ParseScriptRec(Script script);
    }
}
