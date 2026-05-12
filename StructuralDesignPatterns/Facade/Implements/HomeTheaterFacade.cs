using System;
using System.Collections.Generic;
using System.Text;

namespace Facade.Implements
{
    public class HomeTheaterFacade
    {
        private Lights _lights;
        private Projector _projector;
        private SoundSystem _soundSystem;
        public HomeTheaterFacade(Lights lights, Projector projector, SoundSystem soundSystem) 
        {
            _lights = lights;
            _projector = projector;
            _soundSystem = soundSystem;
        }

        public void WatchMovie()
        {
            Console.WriteLine("Get ready to watch a movie...");
            _lights.On();
            _projector.On();
            _soundSystem.On();
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down the home theater...");
            _lights.Off();
            _projector.Off();
            _soundSystem.Off();
        }
    }
}
