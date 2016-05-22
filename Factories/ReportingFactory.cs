using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public abstract class ReportingFactory : IReportingUnit 
    {
        public virtual event EventHandler FactoryStatus;
        public event EventHandler UnitStatusChanged;
        public void OnStatusChanged(IStatusChangedEventArgs e)
        {
            FactoryStatus?.Invoke(this, (StatusChangedEventArgs)e);
        }
    }
}
