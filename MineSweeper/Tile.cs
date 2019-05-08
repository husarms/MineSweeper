using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Tile
    {
        public Tile(bool isCovered = true, bool hasMine = false)
        {
            IsCovered = isCovered;
            HasMine = hasMine;
            Icon = isCovered ? "[]" : hasMine ? "()" : " ";
        }
        public bool IsCovered { get; set; }
        public bool HasMine { get; set; }
        public string Icon { get; set; }
    }
}
