
namespace Game.Core
{
    public static partial class EventManager
    {
        public abstract class GameEvent : System.IComparable<GameEvent>
        {
            public string Name { get; protected set; } = "";
            public float Tick => tick;

            public int CompareTo(GameEvent other) => tick.CompareTo(other.Tick);
            public abstract void Execute();

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