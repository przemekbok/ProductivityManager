using System;
using System.Collections.Generic;
using BlokerStron.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ProductivityBlocker.UnitTests.NetworkTests
{
    [TestFixture]
    public class NetworkScanningTests
    {
        [Test]
        public void NetstatParser_ParsingNetstatLine_ReturnsListOfStrings()
        {
            //Arragne
            string netstatLine = "TCP    127.0.0.1:49755        127.0.0.1:49756        ESTABLISHE";
            PrivateType NetworkScanning_PrivateType = new PrivateType(typeof(NetworkScanning));
            object[] parameterValues = { netstatLine };
            var testList = new List<string>() { "127.0.0.1" };
            //Act
            var result = (List<string>)NetworkScanning_PrivateType.InvokeStatic("NetstatParser", parameterValues);
            //Assert   
            NUnit.Framework.Assert.That(result, Is.EqualTo(testList));
        }
    }
}
