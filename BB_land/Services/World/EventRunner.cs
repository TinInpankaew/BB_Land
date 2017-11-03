using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.Inputs;
using BB_land.Services.Content;
using BB_land.World.Events;
using Microsoft.Xna.Framework.Graphics;

namespace BB_land.Services.World
{
    internal class EventRunner : IEventRunner
    {
        private int currentIndex;
        private IReadOnlyList<IEvent> currentEvents;
        private readonly IContentLoader contentLoader;

        public EventRunner(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;
        }

        public void RunEvents(IList<IEvent> events)
        {
            currentEvents = new ReadOnlyCollection<IEvent>(events);
            currentIndex = 0;
            foreach (var currentEvent in currentEvents)
            {
                currentEvent.LoadContent(contentLoader);
            }
            currentEvents[currentIndex].Initialize();
            Input.LockInput = true;
        }

        public void Update(double gameTime)
        {
            if (currentEvents == null)
                return;
            currentEvents[currentIndex].Update(gameTime);
            if (currentEvents[currentIndex].IsDone)
            {
                currentIndex++;
                if (currentIndex >= currentEvents.Count)
                {
                    currentEvents = null;
                    Input.LockInput = false;
                }
                else
                {
                    currentEvents[currentIndex].Initialize();
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentEvents?[currentIndex].Draw(spriteBatch);
        }
    }
}
