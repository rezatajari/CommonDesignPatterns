# Mediator Design Pattern

## Overview

The **Mediator** design pattern is a behavioral pattern that centralizes communication between objects, preventing direct interactions between them. Instead, objects (referred to as **colleagues**) communicate through a mediator. This reduces the dependencies between objects, simplifying the system and making it more maintainable.

In this example, we model the **Air Traffic Control** system, where airplanes (colleagues) communicate with each other through a control center (mediator) to manage takeoff, landing, and other flight statuses.

---

## Key Concepts

### 1. **Mediator**
The mediator is the central component that facilitates communication between colleagues. It encapsulates the interaction logic and prevents objects from interacting directly. In our analogy, this is the **Air Traffic Control (ATC)** system.

### 2. **Colleague**
Colleagues are the objects that need to interact with each other, but instead of communicating directly, they communicate through the mediator. In our case, these are the **Airplanes**.

### 3. **Loose Coupling**
The mediator pattern promotes loose coupling, where objects depend on the mediator for communication instead of each other. This makes the system easier to maintain and extend.

### 4. **Centralized Communication**
The mediator handles all communication between colleagues. This centralized control allows for more flexible changes, such as adding new colleagues or altering communication logic without impacting other parts of the system.

---

## Structure

### 1. **Mediator Interface**
The interface defines the communication contract between the mediator and its colleagues. It allows the mediator to register colleagues, notify changes, and process communication requests.

### 2. **Concrete Mediator**
This is the actual implementation of the mediator interface. It contains the communication logic and handles requests from the colleagues.

### 3. **Colleague Interface**
Defines the contract for the colleagues, allowing them to interact with the mediator by sending requests or receiving updates.

### 4. **Concrete Colleagues**
These are the objects that implement the colleague interface. They communicate through the mediator and don’t interact directly with each other.

---

## Workflow

1. **Registration**  
   Colleagues (airplanes) register with the mediator (air traffic control center).

2. **Requesting Actions**  
   When an airplane needs to take off or land, it sends a request to the mediator. The mediator handles the logic and coordinates the action.

3. **Status Updates**  
   The mediator may notify the airplanes of any status changes (e.g., ready for takeoff, in holding pattern, emergency).

4. **Response Handling**  
   The mediator processes requests, evaluates conditions (e.g., runway availability), and communicates the results back to the colleagues.

---

## Use Cases

- **Air Traffic Control**: In an airport scenario, the control tower (mediator) coordinates the movements of airplanes, ensuring safe takeoffs, landings, and holding patterns. Airplanes communicate only with the control tower, not directly with each other.

- **Smart Home System**: In a smart home, devices like lights, thermostats, and security cameras communicate with a central hub (mediator) that manages their interactions.

- **Chat Application**: In a chat system, users send messages through a central server (mediator), which routes messages to the correct recipient.

---

## Example Usage

### Scenario: Air Traffic Control System

In this example, we model a simple **Air Traffic Control** system, where airplanes communicate with the control center to request takeoffs, landings, and status updates.

#### Interfaces and Classes:
- **IAirTrafficControl**: The interface that defines the communication between airplanes and the control center.
- **IAirPlane**: The interface representing an airplane that interacts with the control center.
- **AirPlane**: A concrete class that represents an airplane.
- **ControlCenter**: The mediator that coordinates communication between airplanes.

#### Example Code Flow:

```csharp
// Create instances of the control center and airplanes
IAirTrafficControl controlTower = new ControlCenter();
IAirPlane airplane1 = new AirPlane(1);
IAirPlane airplane2 = new AirPlane(2);

// Register the airplanes with the control center
controlTower.RegisterAirPlane(airplane1);
controlTower.RegisterAirPlane(airplane2);

// Airplane 1 requests to land
bool landingApproved = controlTower.RequestLanding(airplane1.AirPlaneId);
Console.WriteLine($"Airplane 1 landing approved: {landingApproved}");

// Airplane 2 requests to take off
bool takeOffApproved = controlTower.RequestTakeOff(airplane2.AirPlaneId);
Console.WriteLine($"Airplane 2 takeoff approved: {takeOffApproved}");
