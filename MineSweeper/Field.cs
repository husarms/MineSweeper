using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    public class Field
    {
        public Field(int size)
        {
            Size = size;
            Tiles = GenerateTiles(size);
            IsGameOver = false;
            IsGameWon = false;
        }

        private static Tile[][] GenerateTiles(int size)
        {
            var tiles = new List<List<Tile>>();

            for (var i = 0; i < size; i++)
            {
                var rows = new List<Tile>();
                for (var j = 0; j < size; j++)
                {
                    var tile = new Tile { HasMine = HasMineRandom() };
                    rows.Add(tile);
                }
                tiles.Add(rows);
            }

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    var numberOfMinesInProximity = GetNumberOfMinesInProximity(tiles, i, j);
                    tiles[i][j].NumberOfMinesInProximity = numberOfMinesInProximity;
                }
            }

            return tiles.Select(a => a.ToArray()).ToArray();
        }

        private static int GetNumberOfMinesInProximity(IReadOnlyList<List<Tile>> tiles, int x, int y)
        {
            var adjacentTiles = new List<Tile>(8);
            for (var dx = (x > 0 ? -1 : 0); dx <= (x < tiles.Count - 1 ? 1 : 0); ++dx)
            {
                for (var dy = (y > 0 ? -1 : 0); dy <= (y < tiles.Count - 1 ? 1 : 0); ++dy)
                {
                    if (dx != 0 || dy != 0)
                    {
                        adjacentTiles.Add(tiles[x + dx][y + dy]);
                    }
                }
            }
            return adjacentTiles.Count(t=> t.HasMine);
        }

        private static bool HasMineRandom()
        {
            var random = new Random();
            var prob = random.Next(100);
            return prob <= 20;
        }

        public int Size { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsGameWon { get; set; }
        public Tile[][] Tiles { get; set; }
    }
}
