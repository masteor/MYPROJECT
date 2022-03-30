using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models.Сущности
{
    public class ДанныеИзФормы_ОбновленияФИО_модель : ДанныеИзФормы_СозданияФИО_модель
    {
        [Range
        (Standard.Range.Min1_MaxValue.Min,
            Standard.Range.Min1_MaxValue.Max)]
        public int? id_fio { get; set; }

        public ДанныеИзФормы_ОбновленияФИО_модель()
        {
            
        }
    }
}