using SDL_Sharp;

namespace Vroom.Engine.ControllerService.SupportedJoysticks
{
    public abstract class SDL_JoystickDeviceHandler
    {
        public Joystick _joystick;
        public SDL_JoystickDeviceHandler()
        {
            InitializeJoystick();
        }

        private void InitializeJoystick()
        {
            SDL.Init(SdlInitFlags.Joystick);

            if (SDL.NumJoysticks() > 0)
                _joystick = SDL.JoystickOpen(0);
            else
                throw new Exception("No joystick available");
        }

        public Event? PollEvents()
        {
            var isEventAvaialable = SDL.PollEvent(out Event e);

            if (isEventAvaialable == 1)
                return e;

            return null;
        }
    }
}
