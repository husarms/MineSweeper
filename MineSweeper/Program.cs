using System;
using System.Linq;
using System.Transactions;

namespace MineSweeper
{
    internal class Program
    {
        private static Field _field;

        private static void Main()
        {
            Console.WriteLine("*** Minesweeper ***");
            _field = new Field(10);
            ShowField();

            Console.WriteLine($"Enter an X coordinate between 0 and {_field.Size - 1}:");
            var xInput = Console.ReadLine();
            if (!int.TryParse(xInput, out var x))
            {

            }

            Console.WriteLine($"Enter an Y coordinate between 0 and {_field.Size - 1}:");
            var yInput = Console.ReadLine();
            if (!int.TryParse(yInput, out var y))
            {

            }

            SelectTile(x, y);
        }

        private static void PlayGame()
        {

        }

        private static void SelectTile(int x, int y)
        {
            var tile = _field.Tiles[x][y];
            _field.Tiles[x][y] = new Tile {IsCovered = false, HasMine = tile.HasMine};
            ShowField();

            if (tile.HasMine)
            {
                Console.WriteLine("BOOM!!!! You died.");
            }
            else
            {
                Console.ReadLine();
            }
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
                    row += tile.Icon;
                }

                Console.WriteLine(row);
            }
            Console.WriteLine("\r\n");
        }
    }
}
