using System;
using System.Collections.Generic;

namespace CityCenter.Models;

public partial class Аренда
{
    public int IdАренды { get; set; }

    public int IdПомещения { get; set; }

    public int IdАрендатора { get; set; }

    public string Цель { get; set; } = null!;

    public DateTime ДатаНачала { get; set; }

    public DateTime ДатаОкончания { get; set; }

    public DateTime? ДатаПоследнегоИзменения { get; set; }

    public virtual Арендаторы IdАрендатораNavigation { get; set; } = null!;

    public virtual Помещения IdПомещенияNavigation { get; set; } = null!;
}
