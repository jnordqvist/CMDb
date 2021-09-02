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
            ship.SetCoordinates(point);
            return true;
        }

        private List<Point> CalculateShipMargin(Ship ship, Point startPoint)
        {
            var xCoordinates = new List<int>();
            var yCoordinates = new List<int>();
            startPoint = new Point(3, 4);
            
                    xCoordinates = Enumerable.Range(startPoint.X - 1, ship.Size + 2).ToList();
                    yCoordinates = Enumerable.Range(startPoint.Y - 1, ship.Size + 2).ToList();


            return new List<Point>();
        }
    }
}
