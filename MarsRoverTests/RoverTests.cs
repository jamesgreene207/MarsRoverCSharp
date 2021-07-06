using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newRover = new Rover();
            Assert.AreEqual(newRover.Position, 0);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover();
            Assert.AreEqual(newRover.Mode, "Normal");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover();
            Assert.AreEqual(newRover.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover newRover = new Rover();
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER")};
            Message newMessage = new Message("Test message with one command", commands);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Mode, "LOW_POWER");
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Rover newRover = new Rover(0, "LOW_POWER");
            Command[] commands = { new Command("MOVE", 5000) };
            Message newMessage = new Message("Test message with one command", commands);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Position, 0);
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover newRover = new Rover();
            Command[] commands = { new Command("MOVE", 5000) };
            Message newMessage = new Message("Test message with one command", commands);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Position, 5000);
        }

    }
}
