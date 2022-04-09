using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;

namespace Game.Core
{
    public static partial class EventManager
    {
        static ConcurrentQueue<GameEvent> events = new ConcurrentQueue<GameEvent>();

        public static void Schedule(GameEvent ev)
        {
            ev.tick = Time.time;
            events.Enqueue(ev);
        }

        static public int Tick()
        {
            var time = Time.time;
            var executedEventCount = events.Count;
            while (executedEventCount > 0)
            {
                if( events.TryDequeue(out var ev))
                {
                    if (ev.tick <= time)
                    {
                        var tick = ev.tick;
                        ev.ExecuteEvent();
                        if (ev.tick > tick)
                        {
                            events.Enqueue(ev);
                        }
                        else
                        {
                            ev.Cleanup();
                        }
                    }
                }
                executedEventCount--;
            }
            return events.Count;
        }
    }
}