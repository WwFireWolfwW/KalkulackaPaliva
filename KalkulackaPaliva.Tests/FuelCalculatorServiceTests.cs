using System;
using KalkulackaPaliva;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KalkulackaPaliva.Tests;

[TestClass]
public class TestyPaliva
{
    private FuelCalculatorService _vypocty = null!;

    [TestInitialize]
    public void Priprav()
    {
        _vypocty = new FuelCalculatorService();
    }

    [TestMethod]
    public void Dojezd_50A5_Je1000()
    {
        Assert.AreEqual(1000.0, _vypocty.CalculateRange(50, 5), 0.000001);
    }

    [TestMethod]
    public void Palivo_400A6_Je24()
    {
        Assert.AreEqual(24.0, _vypocty.CalculateFuelNeeded(400, 6), 0.000001);
    }

    [TestMethod]
    public void Cena_24A40_Je960()
    {
        Assert.AreEqual(960.0, _vypocty.CalculateTripCost(24, 40), 0.000001);
    }

    [DataTestMethod]
    [DataRow(50.0, 0.0)]
    [DataRow(50.0, -5.0)]
    [DataRow(-50.0, 5.0)]
    public void Dojezd_ChybnyVstup(double nadrz, double spotreba)
    {
        Assert.ThrowsException<ArgumentException>(() => _vypocty.CalculateRange(nadrz, spotreba));
    }

    [DataTestMethod]
    [DataRow(-1.0, 6.0)]
    [DataRow(100.0, -6.0)]
    [DataRow(100.0, 0.0)]
    public void Palivo_ChybnyVstup(double trasa, double spotreba)
    {
        Assert.ThrowsException<ArgumentException>(() => _vypocty.CalculateFuelNeeded(trasa, spotreba));
    }

    [DataTestMethod]
    [DataRow(-2.0, 40.0)]
    [DataRow(24.0, -40.0)]
    public void Cena_ChybnyVstup(double litry, double cena)
    {
        Assert.ThrowsException<ArgumentException>(() => _vypocty.CalculateTripCost(litry, cena));
    }

    [TestMethod]
    public void Dojezd_PrazdnaNadrz()
    {
        Assert.AreEqual(0.0, _vypocty.CalculateRange(0, 5), 0.000001);
    }

    [TestMethod]
    public void Palivo_NulovaTrasa()
    {
        Assert.AreEqual(0.0, _vypocty.CalculateFuelNeeded(0, 6), 0.000001);
    }

    [TestMethod]
    public void Cena_NulovaCena()
    {
        Assert.AreEqual(0.0, _vypocty.CalculateTripCost(24, 0), 0.000001);
    }

    [TestMethod]
    public void Dojezd_NeplatneCislo()
    {
        Assert.ThrowsException<ArgumentException>(() => _vypocty.CalculateRange(double.NaN, 5));
    }

    [TestMethod]
    public void Cena_Preteceni()
    {
        Assert.ThrowsException<ArgumentException>(() => _vypocty.CalculateTripCost(double.MaxValue, 2));
    }

    [TestMethod]
    public void Cesta_VychoziHodnoty()
    {
        Assert.AreEqual(769.230769, _vypocty.CalculateRange(50, 6.5), 0.000001);
        double palivo = _vypocty.CalculateFuelNeeded(350, 6.5);
        Assert.AreEqual(22.75, palivo, 0.000001);
        Assert.AreEqual(875.875, _vypocty.CalculateTripCost(palivo, 38.5), 0.000001);
    }
}
