using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectModel;
using Designer;

namespace DesignerUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BPDesign bpdesign = new BPDesign(); //create this object on your own
            DesignResults desresults = Designer.Designer.Designerstuff(bpdesign);

            Assert.AreEqual(desresults.AnchorRodTension, 10);
        }
    }
}
