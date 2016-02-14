namespace Pyramid2000.Engine.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        string Location { get; set; }
        bool Packable { get; set; }
        bool Treasure { get; set; }
        string LongDescription { get; set; }
        string ShortDescription { get; set; }
        int Time { get; set; }
    }
}
