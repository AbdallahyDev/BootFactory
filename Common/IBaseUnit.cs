using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IBaseUnit
    {
        string Name { get; set; }
        Coordinates CurrentPos { get; set; }
        double Speed { get; set; }
        Task<Boolean> MoveAsync(Coordinates currentPos, Coordinates targetPos);
    }
}
