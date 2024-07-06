using Vroom.Engine.Contracts;
using Vroom.Engine.Serial;
using Vroom.Engine.ControllerService.SupportedJoysticks;
using Vroom.Engine.Events;
using SDL_Sharp;

namespace Vroom.Engine.ControllerService.SupportedControllers
{
    public class LogitechJoystick: SDL_JoystickDeviceHandler, IController
    {
        private LoraService _loraService;

        //Array for for speed as this guys gonna be through the ringer...
        //[xAxis, yAxis]
        int[] CurrentPosition;

        MovementEvent CurrentMovement;

        LogitechJoystick(ref LoraService loraService)
        {
            _loraService = loraService;

            CurrentPosition = new int[2];
            CurrentPosition[0] = 0;
            CurrentPosition[1] = 0; 
        }
        private void SendMovementData(MovementEvent e)
        {
            _loraService.SendMovementDataToGoVroom(e);
        }

        private void RequestGPS()
        {
            _loraService.RequestGPSFromOtherLORA();
        }

        private void RequestSpeed()
        {
            _loraService.RequestSpeedFromOtherLORA();
        }
        
        private void HandleControllerEventsAsync()
        {
            var e = PollEvents();

            if (e != null)
            {
                EventHandler(e.Value);
            }
        }

        private void EventHandler(Event e)
        {
            //we only need joystick axis events and button events, and spesific ones for either

            if (e.Type == EventType.JoyButtonDown)
            {
                if (e.JButton.Button == 1)
                {
                    RequestGPS();
                }
                //need to figure out which button for speed
                else if (e.JButton.Button == 2)
                {
                    {
                        RequestSpeed();
                    }
                }
                else if (e.Type == EventType.JoyAxisMotion)
                {
                    var value = e.JAxis.Value;
                    if (e.JAxis.Axis == 0)
                    {
                        HandleXAxisMovement(value);
                    }
                    else if (e.JAxis.Axis == 1)
                    {
                        HandleYAxisMovement(value);
                    }
                     

                }

            }
        }

        //range is [-32768, 32767] for each direction

        private void HandleYAxisMovement(short value)
        {
            var oldDirection = CurrentMovement.Direction;

            if (value > 3000)
            {
                CurrentMovement.Direction = MovementDirection.FORWARD;

            }
            else if (value < -3000)
            {
                CurrentMovement.Direction = MovementDirection.BACKWARD;
            }
            else
                CurrentMovement.Direction = MovementDirection.STOPPED;

            if (CurrentMovement.Direction != oldDirection)
            {
                SendMovementData(CurrentMovement);
            }
        }

        private void HandleXAxisMovement(short value)
        {
            var lastKnownXAxis = CurrentPosition[0];
            CurrentPosition[0] = value;

            //gotta do this
        }






    }
}
