using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
namespace BotFactory.Factories
{
    public interface IUnitFactory
    {
        int QueueCapacity { get;  }
        int StorageCapacity { get; }
        List<IFactoryQueueElement> Queue { get; set;}
        List<ITestingUnit> Storage { get; set;}
        int QueueFreeSlots { get;}
        int StorageFreeSlots { get;}
        TimeSpan QueueTime { get; set;}
        event EventHandler FactoryStatus;
        bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos);
    }
}
