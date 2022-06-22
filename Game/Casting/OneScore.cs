using System;


namespace Unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>The score of player one.</para>
    /// <para>
    /// The responsibility of OneScore is to keep track of Player one's score.
    /// </para>
    /// </summary>
    public class OneScore : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of an OneScore.
        /// </summary>
        public OneScore()
        {
            AddPointsOne(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPointsOne(int points)
        {
            this.points += points;
            SetText($"Player One: {this.points}");
        }
    }
}