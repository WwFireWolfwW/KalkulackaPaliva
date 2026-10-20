using System;
using System.Globalization;
using System.Windows;

namespace KalkulackaPaliva;

public partial class MainWindow : Window
{
    private readonly IFuelCalculatorService _vypocty = new FuelCalculatorService();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Spocitat_Click(object odesilatel, RoutedEventArgs e)
    {
        ChybaText.Text = string.Empty;
        DojezdText.Text = "— km";
        PalivoText.Text = "— l";
        CenaText.Text = "— Kč";

        if (!NactiCislo(NadrzBox.Text, out double nadrz) ||
            !NactiCislo(SpotrebaBox.Text, out double spotreba) ||
            !NactiCislo(TrasaBox.Text, out double trasa) ||
            !NactiCislo(CenaBox.Text, out double cenaLitr))
        {
            ChybaText.Text = "Vyplň prosím všechna pole platnými čísly.";
            return;
        }

        try
        {
            double dojezd = _vypocty.CalculateRange(nadrz, spotreba);
            double palivo = _vypocty.CalculateFuelNeeded(trasa, spotreba);
            double cenaCesty = _vypocty.CalculateTripCost(palivo, cenaLitr);

            DojezdText.Text = $"{dojezd.ToString("N2", CultureInfo.GetCultureInfo("cs-CZ"))} km";
            PalivoText.Text = $"{palivo.ToString("N2", CultureInfo.GetCultureInfo("cs-CZ"))} l";
            CenaText.Text = $"{cenaCesty.ToString("N2", CultureInfo.GetCultureInfo("cs-CZ"))} Kč";
        }
        catch (ArgumentException chyba)
        {
            ChybaText.Text = chyba.Message;
        }
    }

    private void Vstup_Zmenen(object odesilatel, System.Windows.Controls.TextChangedEventArgs e)
    {
        if (DojezdText is null || PalivoText is null || CenaText is null || ChybaText is null)
            return;
        DojezdText.Text = "— km";
        PalivoText.Text = "— l";
        CenaText.Text = "— Kč";
        ChybaText.Text = string.Empty;
    }

    private static bool NactiCislo(string text, out double vysledek)
    {
        string upraveny = text.Trim().Replace(',', '.');
        return double.TryParse(upraveny, NumberStyles.Float,
                   CultureInfo.InvariantCulture, out vysledek) && double.IsFinite(vysledek);
    }
}
