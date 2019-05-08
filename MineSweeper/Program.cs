using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    internal class Program
    {
        private static Field _field;

        private static void Main()
        {
            Console.WriteLine("*** Minesweeper ***");
            PlayGame();
        }

        private static void PlayGame()
        {
            while (true)
            {
                _field = new Field(10);
                ShowField();

                while (!_field.IsGameOver && !_field.IsGameWon)
                {
                    var x = GetInput("x");
                    var y = GetInput("y");
                    SelectTile(x, y);
                }

                if (_field.IsGameOver)
                {
                    Console.WriteLine("BOOM!!!! You died :(");
                }

                if (_field.IsGameWon)
                {
                    Console.WriteLine("You Won!!!");
                }

                Console.WriteLine("Press 'y' to play another game");
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key.ToString().ToLower() == "y")
                {
                    continue;
                }
                break;
            }
        }

        private static int GetInput(string coordinateName)
        {
            var inputIsValid = false;
            var input = 0;
            while (!inputIsValid)
            {
                Console.WriteLine($"Enter an {coordinateName} coordinate between 0 and {_field.Size - 1}:");
                var consoleInput = Console.ReadLine();

                if (!int.TryParse(consoleInput, out var parsedInput)) continue;
                if (parsedInput < 0 || parsedInput > _field.Size - 1) continue;

                input = parsedInput;
                inputIsValid = true;
            }
            return input;
        }

        private static void SelectTile(int x, int y)
        {
            var tile = _field.Tiles[x][y];
            _field.Tiles[x][y].IsCovered = false;

            ShowField();

            _field.IsGameOver = tile.HasMine;
            _field.IsGameWon = AreAllTilesUncovered();
        }

        private static bool AreAllTilesUncovered()
        {
            for (var y = 0; y < _field.Size; y++)
            {
                for (var x = 0; x < _field.Size; x++)
                {
                    var tile = _field.Tiles[x][y];
                    if (tile.IsCovered)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void ShowField()
        {
            Console.WriteLine("\r\n");
            for (var y = 0; y < _field.Size; y++)
            {
                var row = string.Empty;


                for (var x = 0; x < _field.Size; x++)
                {
                    var tile = _field.Tiles[x][y];
                    var tileGraphic = 
                        tile.IsCovered ? "[ ]" : tile.HasMine ? "(X)" : $" {tile.NumberOfMinesInProximity} ";
                    row += tileGraphic;
                }
                Console.WriteLine(row);
            }
            Console.WriteLine("\r\n");
        }
    }
}
