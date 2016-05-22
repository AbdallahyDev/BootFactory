using System;
using BotFactory.Models;
using BotFactory.Common.Tools;
using BotFactory.Factories;
using BotFactory.Common.Interface;

namespace BotFactory
{
    class BotFactory
    {
        static void Main(string[] args)
        {
            Coordinates parkingPos = new Coordinates() {X = 0, Y = 0 };
            Coordinates workingPos = new Coordinates() { X = 5, Y = 5 };
            IUnitFactory unitFactory = new UnitFactory(5, 10);
            unitFactory.FactoryStatus += UnitFactory_FactoryStatus;
            unitFactory.AddWorkableUnitToQueue(typeof(T_800),"R1",parkingPos,workingPos);
        }
        private static void UnitFactory_FactoryStatus(object sender, EventArgs e)
        {
            Console.WriteLine(((Factories.StatusChangedEventArgs)e).NewStatus);
            if (((Factories.StatusChangedEventArgs)e).NewStatus == "End") 
            {
                if (((Factories.StatusChangedEventArgs)e).TestingUnit != null) 
                {
                    ((Factories.StatusChangedEventArgs)e).TestingUnit.UnitStatusChanged += TestingUnit_UnitStatusChanged;
                    ((Factories.StatusChangedEventArgs)e).TestingUnit.WorkBegins(); 
                }
            }
        }
        private static void TestingUnit_UnitStatusChanged(object sender, EventArgs e)
        {
            IStatusChangedEventArgs a = e as IStatusChangedEventArgs;
            ITestingUnit t;
            if (a.NewStatus == "BeganWorking")
            {
                Console.WriteLine($"{ DateTime.UtcNow.ToLongTimeString()} Testing unit status changed to {a.NewStatus}");
                t = sender as WorkingUnit;
                t.WorkEnds();
            }
            else
            {
                Console.WriteLine($"{ DateTime.UtcNow.ToLongTimeString()} Testing unit status changed to {a.NewStatus}");
            }
        }
    }
}