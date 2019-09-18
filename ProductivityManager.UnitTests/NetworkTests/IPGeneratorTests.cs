using System;
using System.Reflection;
using System.Text.RegularExpressions;
using BlokerStron.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ProductivityBlocker.UnitTests.NetworkTests
{
    [TestFixture]
    public class IPGeneratorTests
    {
        //Patern
        //Method_Scenario_Result
        [Test]
        public void RollIPv4_UsingMethodWithAddressFamilyAsParameter_ReturnsInstanceOfString()
        {
            //Arragne
            PrivateType IPGenerator_PrivateType = new PrivateType(typeof(IPGenerator));
            object[] parameterValues = { 127 };

            //Act
            var result = IPGenerator_PrivateType.InvokeStatic("RollIPv4",parameterValues);

            //Assert
            Assert.That(result, Is.InstanceOf(typeof(String)));
        }
        [Test]
        public void RollIPv4_UsingMethodWithAddressFamilyAsParameter_ReturnsValidIPv4()
        {
            //Arrange
            Regex regexForIPv4 = new Regex(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$");

            PrivateType IPGenerator_PrivateType = new PrivateType(typeof(IPGenerator));
            object[] parameterValues = { 127 };

            //Act
            var result = Convert.ToString(IPGenerator_PrivateType.InvokeStatic("RollIPv4", parameterValues));

            //Assert
            Assert.IsTrue(regexForIPv4.IsMatch(result));
        }
    }
}
