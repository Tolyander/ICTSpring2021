using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Food : GameObject
    {
        Worm w = new Worm('@', ConsoleColor.Green);
        //Food f = new Food('$', ConsoleColor.Yellow);
        Wall wall = new Wall('#', ConsoleColor.DarkYellow, @"Levels/Level2.txt");
        Random rnd = new Random();
        public Food(char sign, ConsoleColor color) : base(sign, color)
        {
            Point location = new Point { X = rnd.Next(1, Game.Width), Y = rnd.Next(1, Game.Height) };
            body.Add(location);
            Draw();
        }
        public void Generate()
        {
        //body[0].X = rnd.Next(1, 39);
        //body[0].Y = rnd.Next(1, 39);
        //Draw();
        p:
            body[0].X = rnd.Next(1, 39);
            body[0].Y = rnd.Next(1, 39);
            Point point = new Point { X = body[0].X, Y = body[0].Y };

            bool flag = wall.IsHit(point) && w.IsHit(point);
            if (flag == false)
            {
                Draw();
            }
            else goto p;
        }
    }
}