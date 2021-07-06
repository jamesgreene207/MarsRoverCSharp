using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };
        Message TestMessage = new Message("Test message with two commands");

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message required.", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            new Message("Test message with two commands");
            Assert.AreEqual(TestMessage.Name, "Test message with two commands");
        }

        [TestMethod]
        public void ConstructorSetsCommandsFields()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") };
            Message TestMessage = new Message("Test message with two commands", commands);
            Assert.AreEqual(TestMessage.Commands, commands);
        }
    }
}

