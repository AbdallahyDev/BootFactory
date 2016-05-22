using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {  
        public event EventHandler UnitStatusChanged;
       
        public ReportingUnit(double buildTime)
        :base(buildTime)
        {

        }
        public ReportingUnit()
        {

        }
        public void OnStatusChanged(IStatusChangedEventArgs e)
        {
           UnitStatusChanged?.Invoke(this, (StatusChangedEventArgs)e); 
        }
    }
}
