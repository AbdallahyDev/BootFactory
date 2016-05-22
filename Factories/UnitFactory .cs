using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Threading;
using BotFactory.Common.Interface;
using System.Linq;

namespace BotFactory.Factories
{
    public class UnitFactory : ReportingFactory, IUnitFactory
    {
        private int queueCapacity = 0; 
        private int storeCapacity = 0;  
        //ces varibles sont utilisées en local pour gérer certain traitement dans les méthodes
        private Object _mutex = new Object();
        private bool _isAdded= false;
        private double _buildTime;
        private IFactoryQueueElement _iFacQueueElem;
        private Thread _thBuild;
        private object _instance;
        private List<IFactoryQueueElement> _queue;
        private List<ITestingUnit> _storage;

        public UnitFactory(int queueCapacity, int storeCapacity)
        {
            this.queueCapacity = queueCapacity;
            this.storeCapacity = storeCapacity;
            _queue = new List<IFactoryQueueElement>();
            _storage = new List<ITestingUnit>();
        }
        public int QueueCapacity
        {
            get
            {
                return queueCapacity;
            }
        }
        public int StorageCapacity
        {
            get
            {
                return storeCapacity;
            }
        }
        public List<IFactoryQueueElement> Queue
        {
            get
            {
                return _queue.ToList();
            }
            set
            {
                _queue = value;
            }
        }
        public List<ITestingUnit> Storage
        {
            get
            {
                return _storage.ToList(); 
            }
            set
            {
                _storage = value; 
            }
        }
        public int QueueFreeSlots
        {
            get
            {
                return QueueCapacity - _queue.Count; 
            }
        }
        public int StorageFreeSlots
        {
            get
            {
                return StorageCapacity - _storage.Count;
            }
        }
        private TimeSpan queueTime;

        public TimeSpan QueueTime
        {
            get
            {
                return queueTime;
            }
            set
            {
                queueTime = value;
            } 
        }
        public void Build()
        {
            _thBuild = new Thread(Go);
            _thBuild.Start();
        }
        private Object mutex = new object();
        private void Go()
        {
            lock (this)
            {
                if (_storage.Count < StorageCapacity)
                {
                    IFactoryQueueElement element = _queue[0]; 
                    //construction d'un element testable 
                    _instance = Activator.CreateInstance(element.Model);
                    ITestingUnit testingUnit = (ITestingUnit)_instance;
                    testingUnit.Name = element.Name;
                    testingUnit.WorkingPos = element.WorkingPos;
                    testingUnit.ParkingPos = element.ParkingPos;
                    _buildTime = testingUnit.BuildTime; 
                    Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString()}: Le temps de construction = {_buildTime}");
                    OnStatusChanged(new StatusChangedEventArgs() { NewStatus = "Start", QueueElement = _queue[0] });
                    Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString()}: Construction en cours...");
                    Thread.Sleep(TimeSpan.FromSeconds(_buildTime));
                    Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString()}: La construction est terminée après {_buildTime} secondes");
                    queueTime = TimeSpan.FromSeconds(_buildTime); 
                    _queue.Remove(element);  
                    _storage.Add(testingUnit);  
                    OnStatusChanged(new StatusChangedEventArgs() { NewStatus = "End", TestingUnit = testingUnit });
                }
            }
        } 

        public Boolean AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos)
        {
            if (_queue.Count < QueueCapacity)
            { 
                lock (_mutex)
                {
                    _iFacQueueElem = new FactoryQueueElement() { ParkingPos = parkingPos, WorkingPos = workingPos, Name = name, Model = model };
                    _queue.Add(_iFacQueueElem);
                    _isAdded = true;
                    OnStatusChanged(new StatusChangedEventArgs() { NewStatus = "Element Added", QueueElement = _iFacQueueElem });
                    Build();  
                }
            }
            return _isAdded;
        }
    }
}
