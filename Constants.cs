using System;
using Microsoft.VisualBasic;
using Unit05_cycle.Game.Casting;

namespace Unit05_cycle.Game
{
    /// <summary>
    /// <para>The settings for the game</para>
    /// <para>
    /// The responsibility of Constants is to keep track of the size of the game window and the settings for the game. 
    /// </para>
    /// </summary>
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Tron";
        public static int SNAKE_LENGTH = 8;

        public static Color RED = new Color(255, 0, 0);

        public static Color HEADRED = new Color(255, 100, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);

        public static Color BLUE = new Color(0, 0, 255);

        public static Color HEADBLUE = new Color(0, 100, 255);

    }
}

