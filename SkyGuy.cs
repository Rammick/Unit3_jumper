using System;
using System.Collections.Generic;
using System.Linq;

namespace unit03_jumper
{
    class SkyGuy
    {
        private int _lives = 6;
        private Terminal terminal = new Terminal(); 
        /// <summary>
        /// Constructs instance SkyGuy.
        /// </summary>     
        public SkyGuy()
        {
            
        }

        // the body of the skyguy
        private string[] body;

        // the parachute of the skyguy
        private List<string> parachute;

        /// <summary>
        /// Resets the board/parachute of the skyguy at start of new game.
        /// </summary>
        public void SetupParachute()
        {
            body = new string[2]
            {"   /|\\", "   / \\"};

            parachute = new List<string>() 
            {
            "   ___", "  /   \\ ", "  _____", "  \\   /" , "   \\ / ", "    0"
            };
            _lives = 6;
        }

        /// <summary>
        /// Prints the fixed body of skyguy.
        /// </summary>
        public void PrintGuy()
        {
            foreach (string i in body)
            {
                terminal.WriteText(i);
            }
        }
        /// <summary>
        /// Prints the parachute of skyguy in rows, indexed, and includes the head.
        /// </summary>
        public void PrintParachute()
        {
            foreach (string i in parachute)
            {
                terminal.WriteText(i);
            }
        }
        /// <summary>
        /// Removes the first object in the list parachute.
        /// <para>
        /// Subtracts lives if removing part of parachute.
         /// </para>
        /// </summary>
        public void UpdateParachute()
        {
            parachute.RemoveAt(0);
            _lives--;
            if (IsDead())
            {
                parachute.Add("    x");
            }
        }
        ///<summary>
        ///Changes head from 0 to x if lives at 0
        ///</summary>
        public bool IsDead()
        {
            return _lives < 1;
        }
    }
}