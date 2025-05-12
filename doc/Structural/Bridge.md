# Bridge Design Pattern

## What Is This?

This project demonstrates the **Bridge Design Pattern** using the analogy of a **remote control** (like a TV remote) and different types of **electronic devices** (like TVs and radios). The Bridge pattern allows us to **separate the abstraction (remote control)** from the **implementation (specific device)**, so they can evolve independently.

---

## Real-World Analogy

In your house, you may have:

- A TV with buttons for channels and volume.
- A Radio with a dial for stations.
- A universal remote that works with both devices.

The **universal remote** doesn’t need to know the details of how each device works — it just knows the high-level commands like `TurnOn`, `TurnOff`, and delegates the rest to the correct device.

That’s what the **Bridge Pattern** does.

---

## Key Components

### 🔹 Abstraction Layer (Remote Controls)
- `IRemoteControl`: Defines general operations like turning a device on or off.
- `BasicRemoteControl`: Implements common functionality for all remotes.
- `AdvancedRemoteControl`: Adds features like changing volume, station, or channel.

### 🔹 Implementation Layer (Devices)
- `IDevice`: Represents the base functionality all devices must have (like `PowerOn`, `PowerOff`).
- `ITv`: Extends `IDevice` with `SetVolume`, `ChangeChannel`.
- `IRadio`: Extends `IDevice` with `ChangeStation`.
- `TvDevice`, `RadioDevice`: Concrete implementations of devices.

---

## How It Works

- A `BasicRemoteControl` accepts any object that implements `IDevice` — it doesn't care if it's a TV or a radio.
- When you call `TurnOn()` on the remote, it delegates to the actual device’s `PowerOn()` method.
- An `AdvancedRemoteControl` can do extra things *if* the device supports them. For example:
  - If it's a TV, it can change the channel.
  - If it's a Radio, it can change the station.

---

##  What If We Didn't Use Bridge?

Imagine a scenario **without the Bridge pattern**:
- You’d have to create separate classes for every combination:
  - `TvWithBasicRemote`, `TvWithAdvancedRemote`
  - `RadioWithBasicRemote`, `RadioWithAdvancedRemote`
- That leads to a **combinatorial explosion** of classes.
- Every time you add a new device or remote, you'd have to refactor or duplicate code.

**Without Bridge = tight coupling and duplication.**

---

## Benefits of Using Bridge Pattern

| Benefit                          | Explanation                                                                 |
|----------------------------------|-----------------------------------------------------------------------------|
| Decouples abstraction & implementation | Remote controls and devices evolve independently                           |
| Easy extensibility             | Add new remotes or devices without changing existing code                   |
| Clean separation of concerns  | Remote controls focus on control logic; devices focus on hardware behavior |
| Reduces duplication           | No need to create multiple variants of similar remotes/devices              |

---

## Example Use Case

You want to add a `SmartTvDevice` and a `TouchRemoteControl`. With the Bridge pattern:
- You just implement the `SmartTvDevice` using the `ITv` interface.
- Then create `TouchRemoteControl` that inherits from `BasicRemoteControl`.
- You don’t need to touch any other part of the system.

---

## Summary

The **Bridge Pattern** is ideal when:
- You have **multiple dimensions of variation** (e.g., device type and remote type).
- You want to avoid a **tight connection** between control logic and device logic.
- You value **modularity, scalability, and clean architecture**.

---
