
namespace Game.Core
{
    public static partial class EventManager
    {
        public class GameEvent : System.IComparable<GameEvent>
        {
            public string Name { get; protected set; } = "";

            public int CompareTo(GameEvent other) => tick.CompareTo(other.tick);
            public virtual void Execute() { }

            internal float tick;
            internal virtual void ExecuteEvent()
            {
                if (Precondition())
                {
                    Execute();
                }
            }
            internal virtual bool Precondition() => true;
            internal virtual void Cleanup() { }
        }
    }
}