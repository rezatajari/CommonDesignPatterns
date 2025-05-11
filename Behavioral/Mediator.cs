using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDesignPatterns.Behavioral
{
    /// <summary>
    /// Placeholder class for the Mediator design pattern.
    /// The Mediator pattern facilitates communication between objects
    /// by encapsulating the communication logic in a mediator object.
    /// </summary>
    internal class Mediator
    {
    }

    /// <summary>
    /// Interface for Air Traffic Control (Mediator).
    /// Manages communication between airplanes and coordinates their actions.
    /// </summary>
    interface IAirTrafficControl
    {
        /// <summary>
        /// Handles a landing request from an airplane.
        /// </summary>
        /// <param name="airplaneId">The ID of the airplane requesting to land.</param>
        /// <returns>True if landing is approved, otherwise false.</returns>
        bool RequestLanding(int airplaneId);

        /// <summary>
        /// Handles a takeoff request from an airplane.
        /// </summary>
        /// <param name="airplaneId">The ID of the airplane requesting to take off.</param>
        /// <returns>True if takeoff is approved, otherwise false.</returns>
        bool RequestTakeOff(int airplaneId);

        /// <summary>
        /// Notifies the control center of a change in an airplane's status.
        /// </summary>
        /// <param name="airplaneId">The ID of the airplane.</param>
        /// <param name="eventType">The event type representing the airplane's status.</param>
        void NotifyChange(int airplaneId, AirPlaneEvent eventType);

        /// <summary>
        /// Registers an airplane with the control center.
        /// </summary>
        /// <param name="airPlane">The airplane to register.</param>
        void RegisterAirPlane(IAirPlane airPlane);
    }


    /// <summary>
    /// Interface for an Airplane (Colleague).
    /// Represents an airplane that interacts with the control center.
    /// </summary>
    interface IAirPlane
    {
        /// <summary>
        /// Gets the unique ID of the airplane.
        /// </summary>
        int AirPlaneId { get; }

        /// <summary>
        /// Updates the status of the airplane based on the event type.
        /// </summary>
        /// <param name="eventType">The event type representing the airplane's status.</param>
        void UpdateStatus(AirPlaneEvent eventType);
    }

    /// <summary>
    /// Enum representing various events related to an airplane's status.
    /// </summary>
    internal enum AirPlaneEvent
    {
        /// <summary>
        /// The airplane is ready for takeoff.
        /// </summary>
        ReadyForTakeOff,

        /// <summary>
        /// The airplane has taken off.
        /// </summary>
        TookOff,

        /// <summary>
        /// The airplane is ready to land.
        /// </summary>
        ReadyToLand,

        /// <summary>
        /// The airplane has landed.
        /// </summary>
        Landed,

        /// <summary>
        /// The airplane is in a holding pattern.
        /// </summary>
        InHoldingPattern,

        /// <summary>
        /// The airplane is in an emergency situation.
        /// </summary>
        Emergency
    }


    /// <summary>
    /// Represents an airplane that interacts with the control center.
    /// </summary>
    internal class AirPlane : IAirPlane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirPlane"/> class.
        /// </summary>
        /// <param name="id">The unique ID of the airplane.</param>
        public AirPlane(int id)
        {
            AirPlaneId = id;
        }

        /// <summary>
        /// Gets the unique ID of the airplane.
        /// </summary>
        public int AirPlaneId { get; }

        /// <summary>
        /// Updates the status of the airplane based on the event type.
        /// </summary>
        /// <param name="eventType">The event type representing the airplane's status.</param>
        public void UpdateStatus(AirPlaneEvent eventType)
        {
            Console.WriteLine($"Airplane {AirPlaneId} status updated to: {eventType}");
        }
    }


    /// <summary>
    /// Represents the control center (Mediator) that manages communication between airplanes.
    /// </summary>
    internal class ControlCenter : IAirTrafficControl
    {
        private readonly List<IAirPlane> _airPlanes = new();

        /// <summary>
        /// Checks if the runway is free for landing or takeoff.
        /// </summary>
        /// <returns>True if the runway is free, otherwise false.</returns>
        private bool IsRunWayFree()
        {
            // Simulate a condition for checking if the runway is free
            return true;
        }

        public bool RequestLanding(int airplaneId)
        {
            var isRegister = _airPlanes.FirstOrDefault(a => a.AirPlaneId == airplaneId);
            if (isRegister == null)
                throw new Exception($"This id {airplaneId} airplane is not registered");

            if (IsRunWayFree())
            {
                NotifyChange(airplaneId, AirPlaneEvent.ReadyToLand);
                return true;
            }
            else
            {
                NotifyChange(airplaneId, AirPlaneEvent.InHoldingPattern);
                return false;
            }
        }

        public bool RequestTakeOff(int airplaneId)
        {
            var isRegister = _airPlanes.FirstOrDefault(a => a.AirPlaneId == airplaneId);
            if (isRegister == null)
                throw new Exception($"This id {airplaneId} airplane is not registered");

            NotifyChange(airplaneId, AirPlaneEvent.ReadyForTakeOff);
            return true;
        }

        public void NotifyChange(int airplaneId, AirPlaneEvent eventType)
        {
            var airplane = _airPlanes.FirstOrDefault(a => a.AirPlaneId == airplaneId);
            if (airplane != null)
            {
                airplane.UpdateStatus(eventType);
            }
        }

        public void RegisterAirPlane(IAirPlane airPlane)
        {
            if (!_airPlanes.Contains(airPlane))
            {
                _airPlanes.Add(airPlane);
            }
        }
    }
}
