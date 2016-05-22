using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;

namespace BotFactory.Common.Interface
{
    public interface ITestingUnit
    {
        //the members of IBaseUnit 
        string Name { set; }
        Coordinates CurrentPos { get; set; }
        double Speed { get; set; }
        Task<Boolean> MoveAsync(Coordinates currentPos, Coordinates targetPos);
        //The members of IBuildableUnit
        double BuildTime { get; set; }
        //The members of IReportingUnit 
        event EventHandler UnitStatusChanged;
        void OnStatusChanged(IStatusChangedEventArgs e);
        //The members of IWorkingUnit
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
        bool IsWorking { get; set; }
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}
