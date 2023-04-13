using System;
using System.Collections.Generic;
using System.Text;

namespace Niezbędnik_ucznia.Model
{
    public class Lekcja
    {
        public string nrLekcji { get; set; }
        public TimeSpan poczatekLekcji { get; set; }
        public TimeSpan koniecLekcji { get; set; }
    }

}
