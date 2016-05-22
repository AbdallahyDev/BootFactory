using System;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using System.Threading;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {
        private TimeSpan simulationTime = TimeSpan.FromSeconds(1);
        private TimeSpan routeTime;
        private Thread thMove;
        protected String name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                    name = value;
            }
        }
        protected Coordinates currentPos;
        public Coordinates CurrentPos
        {
            get
            {
                return currentPos;
            }
            set
            {
                currentPos = value;
                OnStatusChanged(new StatusChangedEventArgs() { NewStatus = $"{DateTime.UtcNow.ToLongTimeString()} Moved to {currentPos}." });
            }
        }

        protected double speed;
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        public BaseUnit(String name, double speed)
        {
            currentPos = new Coordinates();
            this.name = name;
            this.speed = speed;
        }

        public BaseUnit(double speed, double buildTime)
        :base(buildTime)
        {
            currentPos = new Coordinates();
            this.speed = speed;
        }

        public BaseUnit()
        {
            speed = 1;
        }
        public async Task<Boolean> MoveAsync( Coordinates currentPos, Coordinates targetPos)
        { 
            if (currentPos.Equals(targetPos))
            {
                return true;
            }
            else 
            {
                Vector vect = Vector.FromCoordinates(currentPos, targetPos);
                routeTime = TimeSpan.FromSeconds((Vector.Length(vect)) / this.speed);
                OnStatusChanged(new StatusChangedEventArgs() { NewStatus = $"{DateTime.UtcNow.ToLongTimeString()}In movement to {targetPos}, route time: {routeTime.Seconds} secondes " });
                Console.WriteLine($"Time of route {routeTime.Seconds}");
                bool b2 = await MoveSimulation(); 
                CurrentPos = targetPos; 
                return b2; 
            } 
        }

        private async Task<bool> MoveSimulation()
        {
            Thread.Sleep(routeTime);
            return true;
        } 
    }
}


