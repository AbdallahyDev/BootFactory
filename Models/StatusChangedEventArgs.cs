using BotFactory.Common.Interface;
using System;

namespace BotFactory.Models
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
    }
}
