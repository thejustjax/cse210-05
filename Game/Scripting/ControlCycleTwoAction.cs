using Unit05_cycle.Game.Casting;
using Unit05_cycle.Game.Services;


namespace Unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls player two's bike.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move player two's bike.
    /// </para>
    /// </summary>
    public class ControlCycleTwoAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlCycleTwoAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("j"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
            cycletwo.TurnHead(direction);

        }
    }
}