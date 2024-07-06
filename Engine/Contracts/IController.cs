using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vroom.Engine.Events;

namespace Vroom.Engine.Contracts
{
    internal interface IController
    {
        private void SendMovementData(MovementEvent movementEvent) { }
        private void RequestGPS() { }

        private void RequestSpeed() { }

    }
}
