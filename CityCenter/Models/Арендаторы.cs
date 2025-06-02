using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityCenter.Models;

public partial class Арендаторы
{
    public int IdАрендатора { get; set; }

    public string Имя { get; set; } = null!;

    public string? КонтактнаяИнформация { get; set; }

    public string? НомерДоговора { get; set; }

    public DateTime? ДатаНачалаДоговора { get; set; }

    public DateTime? ДатаОкончанияДоговора { get; set; }

    public string? Статус { get; set; }

    public int? IdПользователя { get; set; }

    public virtual Пользователи? IdПользователяNavigation { get; set; }

    public virtual ICollection<Аренда> Арендаs { get; } = new List<Аренда>();

    public virtual ICollection<ВидДеятельности> IdДеятельностиs { get; } = new List<ВидДеятельности>();
}
