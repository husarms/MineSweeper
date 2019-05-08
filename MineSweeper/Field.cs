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
        }

        private static Tile[][] GenerateTiles(int size)
        {
            var tiles = new List<List<Tile>>();

            for (var i = 0; i < size; i++)
            {
                var rows = new List<Tile>();
                for (var j = 0; j < size; j++)
                {
                    var tile = new Tile{HasMine = HasMineRandom()};
                    rows.Add(tile);
                }
                tiles.Add(rows);
            }

            return tiles.Select(a => a.ToArray()).ToArray();
        }

        private static bool HasMineRandom()
        {
            var random = new Random();
            var prob = random.Next(100);
            return prob <= 20;
        }

        public int Size { get; set; }
        public Tile[][] Tiles { get; set; }
    }
}
