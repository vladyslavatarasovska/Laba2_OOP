# Лабораторна робота №2. Найпростіші класи. Інкапсуляція і властивості

**Варіант 4.** Клас, який містить відомості про перший член і різницю арифметичної прогресії.
Методи: знаходження члена прогресії за номером n та суми n перших членів.

Windows Forms, C#, .NET Framework 4.7.2.

## Клас `ArithmeticProgression`
- приховані поля: `a1`, `d`, `rnd`; відкриті поля: `Name`, `Count` (static)
- конструктори:
  - `ArithmeticProgression(double a1, double d)` — введення з клавіатури
  - `ArithmeticProgression(int a, int b)` — генерація на інтервалі [a, b]
  - `ArithmeticProgression()` — генерація від 0 до 100
- властивості: `A1`, `D`, `Kind` (тільки читання)
- методи: `Term(n)` — n-й член, `Sum(n)` — сума n перших членів, `FirstTerms(k)` — перші k членів

Формули: aₙ = a₁ + (n − 1)·d;  Sₙ = (2a₁ + (n − 1)·d)·n / 2

## Запуск
- **Visual Studio:** відкрити `LR2_Variant4.sln`, натиснути F5
- **VS Code:** `dotnet run --project LR_2` (потрібні .NET SDK і C# Dev Kit)
