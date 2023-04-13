using System;
using System.Collections.Generic;
using System.Text;

namespace Niezbędnik_ucznia.Model
{
    public class Lista
    {
        public static readonly List<Lekcja> listaLekcji = new List<Lekcja>
        {
            new Lekcja { nrLekcji = "1", poczatekLekcji = TimeSpan.Parse("08:00"), koniecLekcji = TimeSpan.Parse("08:45") },
            new Lekcja { nrLekcji = "2", poczatekLekcji = TimeSpan.Parse("08:55"), koniecLekcji = TimeSpan.Parse("09:40") },
            new Lekcja { nrLekcji = "3", poczatekLekcji = TimeSpan.Parse("09:45"), koniecLekcji = TimeSpan.Parse("10:30") },
            new Lekcja { nrLekcji = "4", poczatekLekcji = TimeSpan.Parse("10:35"), koniecLekcji = TimeSpan.Parse("11:20") },
            new Lekcja { nrLekcji = "5", poczatekLekcji = TimeSpan.Parse("11:35"), koniecLekcji = TimeSpan.Parse("12:20") },
            new Lekcja { nrLekcji = "6", poczatekLekcji = TimeSpan.Parse("12:25"), koniecLekcji = TimeSpan.Parse("13:10") },
            new Lekcja { nrLekcji = "7", poczatekLekcji = TimeSpan.Parse("13:15"), koniecLekcji = TimeSpan.Parse("14:00") },
            new Lekcja { nrLekcji = "8", poczatekLekcji = TimeSpan.Parse("14:05"), koniecLekcji = TimeSpan.Parse("14:50") },
            new Lekcja { nrLekcji = "9", poczatekLekcji = TimeSpan.Parse("14:55"), koniecLekcji = TimeSpan.Parse("15:40") },
            new Lekcja { nrLekcji = "10", poczatekLekcji = TimeSpan.Parse("15:45"), koniecLekcji = TimeSpan.Parse("16:30") },
            new Lekcja { nrLekcji = "11", poczatekLekcji = TimeSpan.Parse("16:35"), koniecLekcji = TimeSpan.Parse("17:20") },
            new Lekcja { nrLekcji = "12", poczatekLekcji = TimeSpan.Parse("17:25"), koniecLekcji = TimeSpan.Parse("18:10") }
        };
    }
}
