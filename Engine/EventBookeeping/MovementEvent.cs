using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vroom.Engine.Events
{
    public enum MovementDirection
    {
        FORWARD,
        BACKWARD,
        STOPPED,
        FOWARD_RIGHT,
        FORWARD_LEFT,
        BACKWARD_RIGHT,
        BACKWARD_LEFT,
    }

    public class MovementEvent
    {
        public bool IsFoward { get; set; }
        public bool IsStopped { get; set; }
        public double Angle { get; set; }


        public MovementDirection Direction { get; set; }

        public MovementEvent(MovementDirection direction, double angle)
        {
            Direction = direction;
            Angle = angle;
        }




    }
}
