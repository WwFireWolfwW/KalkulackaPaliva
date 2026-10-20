# Kalkulačka paliva – Skupina A

WPF aplikace v C# (.NET 8, Windows) podle učitelova zadání `ZADANI_UTERY_20_10`.
Obsahuje pouze **Skupinu A**.

## Struktura
- `KalkulackaPaliva/IFuelCalculatorService.cs` – rozhraní ze zadání
- `KalkulackaPaliva/FuelCalculatorService.cs` – výpočty a kontroly vstupů
- `KalkulackaPaliva/MainWindow.xaml` – uživatelské rozhraní WPF
- `KalkulackaPaliva/MainWindow.xaml.cs` – code-behind
- `KalkulackaPaliva.Tests/FuelCalculatorServiceTests.cs` – MSTest testy

## Spuštění
1. Ve Windows otevři `KalkulackaPaliva.sln` ve Visual Studiu 2022 s podporou **.NET desktop development**.
2. Nastav projekt `KalkulackaPaliva` jako spouštěcí (Set as Startup Project).
3. Spusť aplikaci přes `F5`.
4. Otevři **Test → Test Explorer → Run All Tests**.

## Ruční kontrola
Nádrž 50, spotřeba 5, vzdálenost 400, cena 40:
- Dojezd: 1000 km
- Palivo: 20 l
- Cena: 800 Kč

Příklady z testů zadání používají různé vstupy nezávisle:
- 50 / 5 * 100 = 1000 km
- 400 / 100 * 6 = 24 l
- 24 * 40 = 960 Kč

## Nahrání na GitHub
1. Na github.com klikni **New repository**, zadej název např. `KalkulackaPaliva-SkupinaA`.
2. V terminálu ve složce řešení:
   ```
   git init
   git add .
   git commit -m "WPF kalkulacka paliva a MSTest testy"
   git branch -M main
   git remote add origin https://github.com/TVUJ-LOGIN/KalkulackaPaliva-SkupinaA.git
   git push -u origin main
   ```
3. Ve svém repozitáři vyber **Settings → Collaborators → Add people**.
4. Zadej uživatelské jméno spolužáka, odešli pozvánku a zopakuj pro druhého.
   Spolužáci musí pozvánku potvrdit.

## Poznámky
- Rozhraní IFuelCalculatorService vychází z přiloženého ZIPu.
- Spotřeba musí být větší než nula v obou metodách, které ji přijímají; ostatní vstupy nesmí být záporné. Nulová nádrž, vzdálenost nebo cena jsou platné.
- Metody odmítají NaN, nekonečno a přetečení výsledku.
- `CollectionAssert` není potřeba, protože žádná metoda nevrací kolekci.
- V tomto prostředí není k dispozici `dotnet`, takže testy nebylo možné spustit.

## Modernizované rozhraní
- Tmavý dvousloupcový panel s mentolovými akcenty, jednotkami ve vstupních polích a výraznou cenou cesty.
- Stavy při najetí myší a zaměření klávesnicí; tlačítko funguje také přes Enter.
- Minimální okno 860 × 620; při nedostatku výšky se obsah posouvá.
- Při změně vstupu se staré výsledky odstraní, aby neukazovaly hodnoty z předchozího výpočtu.
- Čísla ve výsledcích používají český formát, vstup přijímá čárku i tečku.

## Kontrola této úpravy
Provedena statická kontrola vzorců, vstupních validací, rozhraní, vazeb názvů prvků a obsluh událostí. XAML i projektové soubory prošly kontrolou XML. To nenahrazuje kompilaci XAML ani běh WPF.
.NET SDK ani Windows v prostředí úpravy nejsou dostupné; MSTest testy, sestavení a skutečný vzhled ve WPF nebyly spuštěny ani vizuálně ověřeny. Před odevzdáním otevři řešení ve Visual Studiu, spusť všechny testy a aplikaci.

### Rychlé ověření ve Windows
1. Výchozí hodnoty 50 / 6,5 / 350 / 38,50: dojezd 769,23 km, palivo 22,75 l, cena 875,88 Kč.
2. Hodnoty 50 / 5 / 400 / 40: dojezd 1 000,00 km, palivo 20,00 l, cena 800,00 Kč.
3. Prázdný vstup, text, záporné číslo a nulová spotřeba: chybová hláška a žádný výsledek.
4. Změň libovolný vstup po výpočtu: předchozí výsledky se vymažou. Enter přepočítá.
5. Vyzkoušej Tab, zmenšení okna, posouvání a škálování Windows 125–150 %.

Zadání má nejednoznačné vyjádření nulové spotřeby: část 4 ji výslovně řeší u dojezdu, část 5 uvádí spotřebu ≤ 0 obecně. Tato verze volí přísnější kontrolu v obou výpočtech.

## České názvy v kódu
Vlastní proměnné, pomocné metody, prvky XAML a testovací metody mají krátké české názvy bez diakritiky (např. nadrz, spotreba, trasa, palivo, NactiCislo).
IFuelCalculatorService, CalculateRange, CalculateFuelNeeded, CalculateTripCost a všechny jejich parametry v rozhraní i implementaci zůstaly přesně podle základního projektu. FuelCalculatorService zůstává podle zadání; MainWindow, App a standardní názvy WPF/.NET jsou zachovány.
Změna upravuje pouze názvy; vzhled a výpočty zůstávají stejné. Kontrola zachování signatur a propojení XAML prošla. Kompilace a testy nebyly spuštěny (chybí .NET a Windows).
