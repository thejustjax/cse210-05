using System;
using System.Collections.Generic;
using System.Data;
using Unit05_cycle.Game.Casting;
using Unit05_cycle.Game.Services;


namespace Unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private bool CycleOneLoose = false;
        private bool CycleTwoLoose = false;
        private int counter = 0;
        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleGrowth(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGrowth(Cast cast)
        {
            CycleOne cycleone = (CycleOne)cast.GetFirstActor("cycleone");
            CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
            OneScore onescore = (OneScore)cast.GetFirstActor("onescore");
            TwoScore twoscore = (TwoScore)cast.GetFirstActor("twoscore");
            twoscore.SetPosition(new Point(Constants.MAX_X -100, 0));
            counter = counter +1;
            if (counter % 15 == 0){
                cycleone.GrowTail(1);
                cycletwo.GrowTail(1);
                onescore.AddPointsOne(1);
                twoscore.AddPointsTwo(1);
            }

        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            //Snake snake = (Snake)cast.GetFirstActor("snake");
            //Actor head = snake.GetHead();
            //List<Actor> body = snake.GetBody();
            CycleOne cycleone = (CycleOne)cast.GetFirstActor("cycleone");
            Actor head1 = cycleone.GetHead();
            List<Actor> body1 = cycleone.GetBody();
            CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
            Actor head2 = cycletwo.GetHead();
            List<Actor> body2 = cycletwo.GetBody();

            foreach (Actor segment1 in body1)
            {
                foreach (Actor segment2 in body2)
                    if (segment1.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        CycleTwoLoose = true;
                    }
                    else if(segment2.GetPosition().Equals(head1.GetPosition()))
                    {
                        isGameOver = true; 
                        CycleOneLoose = true;  
                    }

                    else if(segment2.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        CycleTwoLoose = true;
                    }

                if (segment1.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    CycleOneLoose = true;
                }

            }

            



        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                CycleOne cycleone = (CycleOne)cast.GetFirstActor("cycleone");
                List<Actor> segments1 = cycleone.GetSegments();
                CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
                List<Actor> segments2 = cycletwo.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                if(CycleOneLoose == true)
                {
                    foreach (Actor segment in segments1)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
                if (CycleTwoLoose == true)
                {
                    foreach (Actor segment in segments2)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
                //food.SetColor(Constants.WHITE);
            }
        }
    }
}