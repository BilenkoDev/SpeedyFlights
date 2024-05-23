# SpeedyFlights
This project is a flight scheduling system for SpeedyAir.ly, which allocates orders to planes based on their destinations.

This project follows the **SOLID** design principles.

**S**ingle Responsibility Principle (SRP): Each class has a single responsibility: Order, Plane, and Flight classes manage their respective entities. JsonOrderRepository handles loading orders from a JSON file. Scheduler manages flight schedules and order distribution.

**O**pen/Closed Principle (OCP): Classes are open for extension but closed for modification. New repository types can be added by implementing IOrderRepository without modifying existing code.

**L**iskov Substitution Principle (LSP): By using interfaces (IOrderRepository, IFlightScheduler), we ensure any class implementing these interfaces can be used interchangeably.

**I**nterface Segregation Principle (ISP): Interfaces are small and specific. IOrderRepository and IFlightScheduler ensure classes only implement the methods they need.

**D**ependency Inversion Principle (DIP): High-level module (Scheduler) doesn't depend on low-level module (JsonOrderRepository); it depends on abstractions (IOrderRepository).

Example Output 1

![Screenshot 2024-05-23 010148](https://github.com/BilenkoDev/SpeedyFlights/assets/170587413/f32b4a72-def3-4b9b-bcc3-3c5f143f75dc)

Example Output 2. Unscheduled Orders

![Screenshot 2024-05-23 012332](https://github.com/BilenkoDev/SpeedyFlights/assets/170587413/092215f9-2055-4b5c-ae66-63e5925429e3)
