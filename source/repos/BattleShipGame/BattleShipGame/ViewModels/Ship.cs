﻿using BattleShipGame.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace BattleShipGame.ViewModels
{
    public class Ship : BaseViewModel
    {
        public Direction Direction { get; set; } = Direction.Horizontal;
        public ObservableCollection<Point> Coordinates { get; set; } = new ObservableCollection<Point>();
        public int Size { get; protected set; }
        public int Hits { get; set; } = 0;

        public void SetCoordinates(Point startPoint)
        {
            Point point;
            switch (Direction)
            {
                case Direction.Horizontal:
                    for (int i = 0; i < Size; i++)
                    {
                        int x = startPoint.X + i;
                        int y = startPoint.Y;
                        point = new Point(x, y);
                        Coordinates.Add(point);
                    }
                    break;
                case Direction.Vertical:
                    for (int i = 0; i < Size; i++)
                    {
                        int x = startPoint.X;
                        int y = startPoint.Y + i;
                        point = new Point(x, y);
                        Coordinates.Add(point);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
