using System;

namespace RogueLikeGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" _    _  ____  __    ___  _____  __  __  ____");
            Console.WriteLine("( \\/\\/ )( ___)(  )  / __)(  _  )(  \\/  )( ___)");
            Console.WriteLine(" )    (  )__)  )(__( (__  )(_)(  )    (  )__)");
            Console.WriteLine("(__/\\__)(____)(____)\\___)(_____)(_/\\/\\_)(____)");
            Console.WriteLine(" ____  _____    ____  _____   ___  __  __  ____");
            Console.WriteLine("(_  _)(  _  )  (  _ \\(  _  ) / __)(  )(  )( ___)");
            Console.WriteLine("  )(   )(_)(    )   / )(_)( ( (_-. )(__)(  )__)");
            Console.WriteLine(" (__) (_____)  (_)\\ )(_____) \\___/(______)(____)");
            Console.WriteLine("\n\nPress any key to begin.");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine(" _    _  ____  __    ___  _____  __  __  ____");
            Console.WriteLine("( \\/\\/ )( ___)(  )  / __)(  _  )(  \\/  )( ___)");
            Console.WriteLine(" )    (  )__)  )(__( (__  )(_)(  )    (  )__)");
            Console.WriteLine("(__/\\__)(____)(____)\\___)(_____)(_/\\/\\_)(____)");
            Console.WriteLine(" ____  _____    ____  _____   ___  __  __  ____");
            Console.WriteLine("(_  _)(  _  )  (  _ \\(  _  ) / __)(  )(  )( ___)");
            Console.WriteLine("  )(   )(_)(    )   / )(_)( ( (_-. )(__)(  )__)");
            Console.WriteLine(" (__) (_____)  (_)\\ )(_____) \\___/(______)(____)");
            Console.WriteLine("\n");
            Console.WriteLine("_________________INSTRUCTIONS_________________");
            Console.WriteLine();
            Console.WriteLine("Find a treasure, get a point. Two points gets you out of this hell hole!");
            Console.WriteLine("\n\nÕ = You\n\n$ = Treasure\n\nŽ = Monster");
            Console.WriteLine("\n\nIf the monster gets to the treasure first, he may bury it!");
            Console.WriteLine("\n\nPress any key to continue.");
            Console.ReadKey(true);

            int size = 9;  // dimensions of board
            string[,] board = new string[size, size];
            string userInput = "";

            for (int row = 0; row < size; row++)  // Creates the grid
            {
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = "░";
                }
            }

            int playerX = 8; int playerY = 4;
            board[playerX, playerY] = "Õ";  // Player starting position

            var rando = (new Random());
            var rand1 = rando.Next(0, size - 1);
            var rand2 = rando.Next(0, size - 1);
            
            if (board[rand1, rand2] == board[playerX, playerY]) // ensures location does not match the player's location
            {
                while (rand1 == 8) { rand1 = rando.Next(0, size - 1); }
                while (rand2 == 4) { rand2 = rando.Next(0, size - 1); }
            }
            
            var rand3 = rando.Next(0, size - 1);  // generates random numbers to define treasure 2 location
            var rand4 = rando.Next(0, size - 1);
            
            if (board[rand3, rand4] == board[playerX, playerY]) // ensures the location does not match the player's location
            {
                while (rand3 == 8) { rand3 = rando.Next(0, size - 1); }
                while (rand4 == 4) { rand4 = rando.Next(0, size - 1); }
            }

            else if (board[rand3, rand4] == board[rand1, rand2])  // ensures treasure 2 doesn't overlap with treasure 1
            {
                while (rand3 == rand1) { rand3 = rando.Next(0, size - 1); }
                while (rand4 == rand2) { rand4 = rando.Next(0, size - 1); }
            }
            
            int treasureOneRow = rand1; int tray1Y = rand2;
            board[treasureOneRow, tray1Y] = "$";  // Treasure 1 starting position

            int tray2X = rand3; int tray2Y = rand4;
            board[tray2X, tray2Y] = "$";  // Treasure 2 starting position

            int monsterRow = 4; int monsterCol = 4;
            board[monsterRow, monsterCol] = "Ž";  // monster starting location

            string treasureFind = "You found a treasure!";
            string treasureFound = "You already found this treasure!";
            bool treasure1Found = false;
            bool treasure2Found = false;
            int points = 0;

            // Loop until the user presses q
            while (userInput != "q")
            {
                Console.Clear();

                if (points == 2)
                {
                    break;
                }
                DisplayTheBoard(board); //calling the function to draw the board
                Console.WriteLine();
                if (board[playerX, playerY] == board[monsterRow, monsterCol])
                {
                    Console.WriteLine("\nI can't believe you got caught by a monster that moves randomly.\n\nYou deserve this.");
                    userInput = "q";
                    Console.WriteLine();
                }
                if (board[playerX, playerY] == board[treasureOneRow, tray1Y])     //when user enters the same space that a treasure is in
                {
                    if (treasure1Found == false)             //denotes what happens the first time user enters this area, as bool was set to false
                    {
                        Console.WriteLine(treasureFind);    //tell user they found the treasure
                        points++;                           //add a point to the point total
                        treasure1Found = true;              //stop user from finding the same treasure more than once
                    }
                    else
                        Console.WriteLine(treasureFound);       // tells the user they already found the treasure that was in this space
                }

                if (board[playerX, playerY] == board[tray2X, tray2Y])
                {
                    if (treasure2Found == false)
                    {
                        Console.WriteLine(treasureFind);
                        points++;
                        treasure2Found = true;
                    }
                    else
                        Console.WriteLine(treasureFound);
                }

                // User controls
                Console.WriteLine("WASD to move. Q to quit.");
                Console.WriteLine("POINTS: " + points);      //points counter that gets increased by 1 when a treasure is found
                Console.WriteLine();
                if (points == 2)
                {
                    Console.WriteLine("YOU FOUND ALL THE TREASURE! YOU WON!");
                    Console.WriteLine("\nPress any key to finish.");
                    Console.WriteLine();
                }

                // Movement input
                // is a string so it can interact with the string[,] board
                // ReadKey(true) prevents the user input from being displayed
                userInput = Console.ReadKey(true).Key.ToString().ToLower();

                // Movement conditionals
                if (userInput == "w" && playerX > 0)                   // w -> Up
                {
                    board[playerX, playerY] = "░";            // Removes player token from previous position
                    board[(playerX -= 1), playerY] = "Õ";     // Moves player up one along row axis
                }
                // we were going to put an else that does nothing, but found that not putting the else also does nothing

                if (userInput == "a" && playerY > 0)                   // a -> Left
                {
                    board[playerX, playerY] = "░";
                    board[playerX, (playerY -= 1)] = "Õ";     // Moves player left one along column axis
                }

                if (userInput == "s" && playerX < size - 1)                   // s -> Down
                {
                    board[playerX, playerY] = "░";
                    board[(playerX += 1), playerY] = "Õ";     // Moves player down one along row axis
                }

                if (userInput == "d" && playerY < size - 1)                   // d -> Right
                {
                    board[playerX, playerY] = "░";
                    board[playerX, (playerY += 1)] = "Õ";     // Moves player right one along column axis
                }

                board[monsterRow, monsterCol] = "░";  // changing the monster's previous place to a board space
                
                int monsterMove = rando.Next(1, 5); // random number generator to define monster movement

                if (monsterMove == 1 && monsterRow > 0) { monsterRow--; }
                if (monsterMove == 2 && monsterRow < size - 1) { monsterRow++; }
                if (monsterMove == 3 && monsterCol > 0) { monsterCol--; }
                if (monsterMove == 4 && monsterCol < size - 1) { monsterCol++; }
                
                board[monsterRow, monsterCol] = "Ž";  // changes monster's new space to monster token
            } 

            Console.Clear();
            Console.WriteLine("  ▄████  ▄▄▄      ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  \n ██▒ ▀█▒▒████▄   ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒\n▒██░▄▄▄░▒██  ▀█▄ ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒\n░▓█  ██▓░██▄▄▄▄██▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  \n░▒▓███▀▒ ▓█   ▓██▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒\n ░▒   ▒  ▒▒  ▓▒█░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░\n  ░   ░   ▒   ▒▒ ░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░\n░ ░   ░   ░   ▒  ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ \n      ░       ░  ░      ░      ░  ░       ░ ░        ░     ░  ░   ░     \n                                                    ░                   ");
        }

        public static void DisplayTheBoard(string[,] placeBoard)
        {
            int size = 9;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(placeBoard[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}