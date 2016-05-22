using BotFactory.Common.Interface;
using System;

namespace BotFactory.Factories
{
    public class StatusChangedEventArgs : EventArgs, IStatusChangedEventArgs
    {
        private String newStatus;
        public String NewStatus
        {
            get
            {
                return newStatus;
            }
            set
            {
                newStatus = value; 
            }
        }
        private IFactoryQueueElement queueElement;
        public IFactoryQueueElement QueueElement
        {
            get
            {
                return queueElement;
            }
            set
            {
                queueElement = value;   
            }
        }
        private ITestingUnit testingUnit;
        public ITestingUnit TestingUnit
        {
            get
            {
                return testingUnit;
            }
            set
            {
                testingUnit = value;
            }
        }
    }
}