using Unit05_cycle.Game.Casting;
using Unit05_cycle.Game.Directing;
using Unit05_cycle.Game.Scripting;
using Unit05_cycle.Game.Services;


namespace Unit05_cycle
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("cycletwo", new CycleTwo());
            cast.AddActor("cycleone", new CycleOne());
            cast.AddActor("onescore", new OneScore());
            cast.AddActor("twoscore", new TwoScore());
            

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlCycleOneAction(keyboardService));
            script.AddAction("input", new ControlCycleTwoAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}