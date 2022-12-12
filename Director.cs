using System;
using System.Collections.Generic;


namespace unit03_jumper
{
    class Director
    {  
        /// Instantiates skyguy, isplaying, terminal, the board, word, guess, userinput, replay 
        private SkyGuy skyguy = new SkyGuy();
        private bool isPlaying = true;
        private Terminal terminal = new Terminal();
        private Board board;
        private Word word = new Word();
        private string _userInput = " ";
        private string _guess;
        private bool _replay = false;

        public Director()
        {
            board = new Board(word.GetWord());

        }
        

        ///<summary>  Set up the game: pick a random word, display the initial look of the board.</summary>
        public void SetupGame()
        {
            isPlaying = true;
            skyguy.SetupParachute();
            skyguy.PrintParachute();
            skyguy.PrintGuy();
            board.DisplayWord();
            // needs board.Reset()
       }

        ///<summary> Start the actual game, looping through all the functions until the game is over.</summary>
        public void StartGame()
        {
            SetupGame();
            while (isPlaying == true)
            {
                if (_replay)
                {
                    SetupGame(); //resets the board for the next game
                    word.SetWord(); //picks a new word for the next game
                    _replay = false; //sets replay back to 0 so SetupGame isn't called multiple times
                }
                DoInput();
                DoUpdate();
                DoOutput();
                
            }
        }

        public void DoInput()
        {
            //ask the user for their letter guess
            _guess = board.GetGuess();
        }
        /// <summary>
        /// Checks if skyguy lost all parachute, game ends
        /// <para>
        /// Removes part of parachute if guess wrong.
         /// </para>
         /// <para>
        /// Checks if game over with matching guess string and  gameword string.
         /// </para>
        /// </summary>
        public void DoUpdate()
        {   
            if (skyguy.IsDead())
            {
                isPlaying = false;
                terminal.WriteText("\n\nBetter luck next time!");
            }

            if (!word.CheckGuess(_guess))
            {
                skyguy.UpdateParachute();
            }

            if (board.IsFinished())
            {
                isPlaying = false;
                skyguy.PrintParachute();
                skyguy.PrintGuy();
                board.DisplayWord();
                terminal.WriteText("You Win");
            }
            
            //if the game is over, ask user if they want to play again.
            if (isPlaying == false)
            {
                _userInput = terminal.ReadText("\nDo you want to play again? y/n?\n");
                terminal.WriteText($"\tUserInput was saved as: {_userInput}");
                _userInput = _userInput.ToUpper();
                if (_userInput == "Y")
                {
                    isPlaying = true;
                    _replay = true; //keep track that we are playing again
                    terminal.WriteText($"\tisPlaying saved as: {isPlaying}");
                }
                else
                {
                    isPlaying = false;
                    terminal.WriteText($"\tisPlaying saved as: {isPlaying}");
                }
            }
        }
        ///<summary>Displays the paracute, then the guy attatched to the parachute,and then the spaces where the word needs to filled.</summary>
        public void DoOutput()
        {
            
            skyguy.PrintParachute();
            skyguy.PrintGuy();
            terminal.WriteText(" \n");
            board.DisplayWord();
            
        }
    }
}

               