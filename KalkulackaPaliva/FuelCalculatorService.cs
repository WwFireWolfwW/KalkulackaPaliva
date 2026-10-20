using System;

namespace KalkulackaPaliva;

public class FuelCalculatorService : IFuelCalculatorService
{
    public double CalculateRange(double tankCapacity, double consumptionPer100Km)
    {
        OverNezaporne(tankCapacity, nameof(tankCapacity));
        OverKladne(consumptionPer100Km, nameof(consumptionPer100Km));
        return OverVysledek(tankCapacity / consumptionPer100Km * 100);
    }

    public double CalculateFuelNeeded(double distance, double consumptionPer100Km)
    {
        OverNezaporne(distance, nameof(distance));
        OverKladne(consumptionPer100Km, nameof(consumptionPer100Km));
        return OverVysledek(distance / 100 * consumptionPer100Km);
    }

    public double CalculateTripCost(double fuelNeeded, double pricePerLiter)
    {
        OverNezaporne(fuelNeeded, nameof(fuelNeeded));
        OverNezaporne(pricePerLiter, nameof(pricePerLiter));
        return OverVysledek(fuelNeeded * pricePerLiter);
    }

    private static double OverVysledek(double hodnota)
    {
        if (!double.IsFinite(hodnota))
            throw new ArgumentException("Výsledek je příliš velký. Zadej menší hodnoty.");
        return hodnota;
    }

    private static void OverNezaporne(double hodnota, string parametr)
    {
        if (!double.IsFinite(hodnota) || hodnota < 0)
            throw new ArgumentException("Hodnota nesmí být záporná ani neplatná.", parametr);
    }

    private static void OverKladne(double hodnota, string parametr)
    {
        if (!double.IsFinite(hodnota) || hodnota <= 0)
            throw new ArgumentException("Hodnota musí být větší než 0.", parametr);
    }
}
