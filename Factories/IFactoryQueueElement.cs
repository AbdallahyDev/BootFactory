using BotFactory.Common.Tools;
using System;

namespace BotFactory.Factories
{
    public interface IFactoryQueueElement
    {
        Coordinates WorkingPos { get; set; }
        Coordinates ParkingPos { get; set; }
        Type Model { get; set; }
        string Name { get; set; }
    }
}
