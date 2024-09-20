namespace TheGame.Core.Physics;

public class FleetPhysics
{
    public double Mass { get; }
    public double EnginePower { get; }
    public double Gravity { get; }
    public double Distance { get; }
    public double TargetSpeed { get; }
    public double GravityConstant { get; }
    

    public FleetPhysics(double mass, double enginePower, double gravity, double distance, double targetSpeed, double gravityConstant)
    {
        Mass = mass;
        EnginePower = enginePower;
        Gravity = gravity;
        Distance = distance;
        TargetSpeed = targetSpeed;
        GravityConstant = gravityConstant;
    }

    // Phase 1: Accelerating under gravity
    private double CalculateAccelerationUnderGravity(double remainingGravity)
    {
        return (EnginePower - remainingGravity) / Mass;
    }

    // Phase 2: Accelerating in void (after escaping gravity)
    private double CalculateAccelerationInVoid()
    {
        return EnginePower / Mass;
    }

    // Phase 3: Minimal fuel consumption while maintaining target speed
    private double CalculateMaintenanceFuel(double speed, double time)
    {
        return speed * time * Mass * 0.01; // Maintenance fuel is minimal
    }

    // Calculate the remaining gravity effect as the spaceship moves away from the planet
    private double CalculateLogarithmicGravityDecrease(double initialGravity, double distanceTravelled)
    {
        return initialGravity * Math.Log10(1 + (distanceTravelled / GravityConstant));
    }

    // Calculate total fuel required for each phase
    public double CalculateTotalFuelConsumption()
    {
        double fuelUnderGravity = 0;
        double distanceUnderGravity = CalculateDistanceUnderGravity();

        // Phase 1: Accelerating under gravity
        double speedUnderGravity = 0;
        for (double distance = 0; distance <= distanceUnderGravity; distance += 0.1)
        {
            double gravityEffect = CalculateLogarithmicGravityDecrease(Gravity, distance);
            double acceleration = CalculateAccelerationUnderGravity(gravityEffect);

            double timeUnderGravity = 0.1 / acceleration;  // Time to cover small distance
            speedUnderGravity += acceleration * timeUnderGravity;

            fuelUnderGravity += CalculateFuelForAcceleration(acceleration, timeUnderGravity);
        }

        // Phase 2: Accelerating to target speed in void
        double fuelInVoid = 0;
        double remainingDistance = Distance - distanceUnderGravity;
        double speedInVoid = speedUnderGravity;

        while (speedInVoid < TargetSpeed)
        {
            double acceleration = CalculateAccelerationInVoid();
            double timeInVoid = 0.1 / acceleration;
            speedInVoid += acceleration * timeInVoid;

            fuelInVoid += CalculateFuelForAcceleration(acceleration, timeInVoid);
        }

        // Phase 3: Maintaining target speed
        double timeAtTargetSpeed = remainingDistance / TargetSpeed;
        double maintenanceFuel = CalculateMaintenanceFuel(TargetSpeed, timeAtTargetSpeed);

        return fuelUnderGravity + fuelInVoid + maintenanceFuel;
    }

    // Fuel consumed during acceleration
    private double CalculateFuelForAcceleration(double acceleration, double time)
    {
        double thrustForce = Mass * acceleration;
        return thrustForce * time * 0.1;  // Adjust fuel coefficient
    }

    // Calculate the distance under gravity influence
    private double CalculateDistanceUnderGravity()
    {
        return GravityConstant * Math.Sqrt(Gravity);
    }

    // Calculate the total travel time, accounting for acceleration and coasting at target speed
    public double CalculateTotalTravelTime()
    {
        double distanceUnderGravity = CalculateDistanceUnderGravity();

        // Time under gravity to accelerate
        double timeUnderGravity = TargetSpeed / CalculateAccelerationUnderGravity(Gravity);

        // Time in the void to reach target speed
        double remainingDistance = Distance - distanceUnderGravity;
        double timeInVoid = remainingDistance / TargetSpeed;

        return timeUnderGravity + timeInVoid;
    }
}