using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Models.Валидатор.Пользовательская_валидация;

namespace QWERTY.Shared.Models
{
    public interface IПереченьСубъектовДоступа
    {
        public abstract int?[]? LoginIds { get; set; }
        public abstract int?[]? OrgIds { get; set; }
    }
    
    public abstract class ПереченьСубъектовДоступа : ДанныеИзФормы
    {
    }
}