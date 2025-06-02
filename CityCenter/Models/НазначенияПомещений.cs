using System;
using System.Collections.Generic;

namespace CityCenter.Models;

public partial class НазначенияПомещений
{
    public int IdНазначения { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Помещения> Помещенияs { get; } = new List<Помещения>();
}
