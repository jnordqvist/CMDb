using BattleShipGame.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BattleShipGame.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        private static readonly Random random = new Random();
        private readonly int battleFieldSize = 10;
        public ObservableCollection<Ship> Ships { get; set; }

        private void FillFleet()
        {
            Ships = new ObservableCollection<Ship>()
            {
                new BattleShip(),
                new Submarine(),
                new Cruiser()
            };
        }

        public PlayerViewModel()
        {
            FillFleet();
            PlaceShipsRandomly();
        }

        /// <summary>
        /// place ships randomly in battlefield ocean
        /// </summary>
        public void PlaceShipsRandomly()
        {
            foreach (var ship in Ships)
            {
                bool shipIsAdded;
                ship.Direction = GetRandomDirection();
                do
                {
                    var point = GetRandomOceanPoint();
                    shipIsAdded = PlaceShipInOcean(ship, point);
                } while (!shipIsAdded);
            }
        }

        /// <summary>
        /// Get random direction
        /// </summary>
        /// <returns>horizontal or vertical</returns>
        private Direction GetRandomDirection()
        {
            int magicNumber = random.Next(2);
            return (Direction)magicNumber;
        }

        /// <summary>
        /// Find a random point in ocean
        /// </summary>
        /// <returns></returns>
        private Point GetRandomOceanPoint()
        {
            return new Point(random.Next(battleFieldSize) + 1, random.Next(battleFieldSize + 1));
        }

        /// <summary>
        /// Place one ship at given point at sea
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool PlaceShipInOcean(Ship ship, Point point)
        {
            var coordinates = CalculateShipMargin(ship, point);
            if (HasSufficientSpace(coordinates))
            {
                ship.SetCoordinates(point);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calculate the ship margins
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="startPoint"></param>
        /// <returns></returns>
        private List<Point> CalculateShipMargin(Ship ship, Point startPoint)
        {
            var coordinates = new List<Point>();
            var xCoordinates = new List<int>();
            var yCoordinates = new List<int>();

            switch (ship.Direction)
            {
                case Direction.Horizontal:
                    xCoordinates = Enumerable.Range(startPoint.X - 1, ship.Size + 2).ToList();
                    yCoordinates = Enumerable.Range(startPoint.Y - 1, 3).ToList();

                    break;
                case Direction.Vertical:
                    xCoordinates = Enumerable.Range(startPoint.X - 1, 3).ToList();
                    yCoordinates = Enumerable.Range(startPoint.Y - 1, ship.Size + 2).ToList();
                    break;
                default:
                    break;
            }

            Point point;
            foreach (var x in xCoordinates)
            {
                foreach (var y in yCoordinates)
                {
                    point = new Point(x, y);
                    coordinates.Add(point);
                }
            }
            //testing
            return coordinates;
        }

        private bool HasSufficientSpace(List<Point> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                foreach (var ship in Ships)
                {
                    if (PointOccupied(coordinate, ship))
                        return false;
                }
            }
            return true;
        }

        private bool PointOccupied(Point coordinate, Ship ship)
        {
            return ship.Coordinates.Where(s => s.X == coordinate.X && s.Y == coordinate.Y).Any();
        }
    }
}
