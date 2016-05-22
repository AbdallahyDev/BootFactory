using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class BuildableUnit : IBuildableUnit
    {
        protected  double buildTime;
        public double BuildTime
        {
            get
            {
                return buildTime;
            }
            set
            {
                if ((value > 0))
                {
                    buildTime = value;
                }
            }
        }
     
        public string Model
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public BuildableUnit(double buildTime)
        {
            this.buildTime = buildTime;
        }

        public BuildableUnit()
        {
            this.buildTime = 5;
        } 
    }
}
