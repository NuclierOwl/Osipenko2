using System;
using System.Collections.Generic;

namespace OsipenkoN.Date;

public partial class Zakaz
{
    public int? Id { get; set; }

    public string? Produkt { get; set; }

    public string? KolVo { get; set; }

    public string? Izmerenie { get; set; }

    public string? Cena { get; set; }

    public string? Summa { get; set; }
}
