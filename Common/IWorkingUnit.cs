using BotFactory.Common.Tools;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IWorkingUnit
    {
         Coordinates ParkingPos { get; set; }
         Coordinates WorkingPos { get; set; }
         bool IsWorking { get; set; }
        Task<bool> WorkBegins();
    }
}
