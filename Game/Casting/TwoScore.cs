using System;


namespace Unit05_cycle.Game.Casting{

    /// <summary>
    /// <para>The score of player Two.</para>
    /// <para>
    /// The responsibility of TwoScore is to keep track of Player two's score.
    /// </para>
    /// </summary>
    public class TwoScore : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of an TwoScore.
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