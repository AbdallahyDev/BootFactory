using System;

namespace BotFactory.Common.Interface
{
    public interface IStatusChangedEventArgs
    {
         String NewStatus { get; set; }
    }
}
