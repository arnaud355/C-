using System;

namespace morpion
{
    public enum Player { Noone = 0,Rond,Croix }
    public struct Square
    {
        public Player Owner { get; }

        public Square(Player owner)
        {
            this.Owner = owner;
        }

        public override string ToString()
        {
            switch (Owner)
            {
                case Player.Noone:
                    return ".";
                case Player.Rond:
                    return "O";
                case Player.Croix:
                    return "X";
                default:
                    throw new Exception("Invalid state");
            }
        }
    }
}
