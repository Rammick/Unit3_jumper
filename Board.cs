using System;
using System.Collections.Generic;
namespace unit03_jumper
{
    public class Board
    {
        ///instantiate terminal, guesses list, gameword list, letter, guess
        private Terminal terminal = new Terminal(); //creates 
        private List<string> guesses = new List<string>();
        private string _gameword;
        private string _letter;
        private string _guess;

        /// <summary>
        /// Create instance of board class.
        /// </summary>
        public Board(string word)
        {
            _gameword = word;
        }
        /// <summary>
        /// Adds the gameword to a string, if the guess is in the game word string, the guess letter is added to a string s, if not a dash is added. Returns s as dash or string.
        /// </summary>
        private string GenerateString()
        {
            string s = "";
            foreach (char letters in _gameword)
            {
                _letter = letters.ToString();
                if (guesses.Contains(_letter))
                {
                    s += _letter;

                }
                //saying if the letter guess was wrong
                else
                {
                    s += "_";
                }

            }
            return s;
        }
        /// <summary>
        /// Displays the board, replaces letter and displays it, or a dash. Calls the GeneratesString method for terminal to write.
        /// </summary>
        public void DisplayWord()
        {
            terminal.WriteText(GenerateString());
        }
        /// <summary>
        /// Gets the _guess from terminal and adds it to a list guesses.
        /// </summary>
        public string GetGuess()
        {
            _guess = terminal.ReadText("\n\nGuess a letter of the word: "); //saves the guess in variable "guess"
            terminal.WriteText("\n");
            guesses.Add(_guess);

            return _guess;
        }
        /// <summary>
        /// IsFinished returns true if _gameword string = s string.
        /// </summary>
        public bool IsFinished()
        {
            return _gameword == GenerateString();
        }
    }     
}