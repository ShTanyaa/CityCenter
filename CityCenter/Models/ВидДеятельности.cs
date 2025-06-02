using System;
using System.Collections.Generic;

namespace CityCenter.Models;

public partial class ВидДеятельности
{
    public int IdДеятельности { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Арендаторы> IdАрендатораs { get; } = new List<Арендаторы>();
}
