using System;
using IAMPM.GameEngine.Interfaces;
using IAMPM.GameObjects.Exceptions;

namespace IAMPM.GameEngine.Implementations
{
    public class GameEngine : IGameEngine
    {
        private readonly IGame _game;

        public GameEngine(IGame game)
        {
            _game = game;
        }

        public void Start()
        {
            try
            {
                _game.PreStart();
            }
            catch (BaseException e)
            {
                Console.WriteLine("Expected excetion: " + e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}