using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Models;
namespace BotFactory.Factories
{
    public class FactoryQueueElement : IFactoryQueueElement
    {
        private string name;
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
        private Type model;
        public Type Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
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
    }
}
