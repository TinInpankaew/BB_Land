using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BB_land.EventArg;
using BB_land.Inputs;
using BB_land.Services.World;
using BB_land.World.Boom;
using BB_land.World.Events;

namespace BB_land.World.Components
{
    internal class ComponentTest : Component
    {
        private readonly IEventRunner eventRunner;
        private readonly Input input;
        private readonly IReadOnlyList<Entity> entities;

        public ComponentTest(IComponentOwner owner, IEventRunner eventRunner, Input input, IReadOnlyList<Entity> entities) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.input = input;
            this.entities = entities;
            input.NewInput += InputOnNewInput;
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == Common.Inputs.Z)
            {
                eventRunner.RunEvents(new List<IEvent> { new EventBoom("player", entities, new Booms()) });
            }
        }

        public override void Update(double gameTime)
        {
            input.Update(gameTime);
        }
    }
}
