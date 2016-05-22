using System;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit, ITestingUnit
    {
        public WorkingUnit(double speed, double buildTime)
        : base(speed, buildTime)
        {

        }
        private Coordinates parkingPos;
        public Coordinates ParkingPos
        {
            get
            {
                return parkingPos;
            }
            set
            {
                parkingPos = value;
            }
        }
        private Coordinates workingPos;
        public Coordinates WorkingPos
        {
            get
            {
                return workingPos;
            }
            set
            {
                workingPos = value;
            }
        }
        private bool isWorking;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
            set
            {
                isWorking = value;
                OnStatusChanged(new StatusChangedEventArgs() { NewStatus = (isWorking ? $"Began Working at: {DateTime.UtcNow.ToLongTimeString()}" : $"Stopped Working at: {DateTime.UtcNow.ToLongTimeString()}") });
            }
        }

       public virtual async Task<bool> WorkBegins()
       {
            bool b = await this.MoveAsync(CurrentPos, WorkingPos);
            if (CurrentPos.Equals(WorkingPos))
            {
               this.IsWorking = true;  
            }
            return b;
       }

       public virtual async Task<bool> WorkEnds()
       {
            IsWorking = false;
            bool b = await this.MoveAsync(CurrentPos, ParkingPos);  
            return b;
        }
    }
}
