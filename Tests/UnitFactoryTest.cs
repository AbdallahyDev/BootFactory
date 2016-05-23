using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotFactory.Factories;

namespace Tests
{
    [TestClass] 
    public class UnitFactoryTest
    {
        private UnitFactory uf = new UnitFactory(10,11); 
        //pour tester l'affectation de la capacité de la queue
        [TestMethod]
        public void QueueCapacityTest()  
        {
            Assert.AreEqual(10, uf.QueueCapacity);      
        }
    }
}
