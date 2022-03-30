using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models.Сущности
{
    public class ДанныеИзФормы_УдаленияФИО_модель : ДанныеИзФормы
    {
        [Required,
         Range(
             Standard.Range.Min1_MaxValue.Min,
             Standard.Range.Min1_MaxValue.Max)]
        public override int? id { get; set; }

        public override RequestParams? request_params { get; set; }
    }
}