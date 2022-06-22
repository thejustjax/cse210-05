using System;


namespace Unit05_cycle.Game.Casting{

    public class TwoScore : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public TwoScore()
        {
            AddPointsTwo(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPointsTwo(int points)
        {
            this.points += points;
            SetText($"Player Two: {this.points}");
        }
    }
}