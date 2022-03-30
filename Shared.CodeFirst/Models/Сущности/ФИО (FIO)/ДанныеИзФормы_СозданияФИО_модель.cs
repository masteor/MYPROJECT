using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models.Сущности
{
    public class ДанныеИзФормы_СозданияФИО_модель : ДанныеИзФормы  
    {
        [Required,
            Range(
            Standard.Range.Min1_MaxValue.Min,
            Standard.Range.Min1_MaxValue.Max)]
        public int? id_user { get; set; }

        [Required,
         MinLength(Annotation.family.MinLength),
         MaxLength(Annotation.family.MaxLength)]
        public string? family { get; set; }
        
        
        [Required,
         MinLength(Annotation.name.MinLength),
         MaxLength(Annotation.name.MaxLength)]
        public string? name { get; set; }
        
        
        [Required,
         MinLength(Annotation.patronymic.MinLength),
         MaxLength(Annotation.patronymic.MaxLength)]
        public string? patronymic { get; set; }

        [Required]
        public sealed override RequestParams? request_params { get; set; }


        public ДанныеИзФормы_СозданияФИО_модель()
        {
            
        }

        // конструктор используется для копирования свойств из одного объекта в другой 
        public ДанныеИзФормы_СозданияФИО_модель(ДанныеИзФормы_СозданияФИО_модель модель)
        {
            id_user = модель.id_user;
            family = модель.family;
            name = модель.name;
            patronymic = модель.patronymic;
            request_params = new RequestParams(модель.request_params);
        }

        public ДанныеИзФормы_СозданияФИО_модель(ДанныеИзФормы_СозданияПользователя_модель модель, EMPLOYEE employee)
        {
            id_user = employee.id;   
            family = модель.family;
            name = модель.name;
            patronymic = модель.patronymic;
            request_params = new RequestParams(модель.request_params);
        }
        
        public string ПолучитьПолноеФИО
        {
            get
            {
                var r = string.Empty;
                if (!(string.IsNullOrWhiteSpace(family) || family?.Length < 1)) {r += family;}

                if (!(string.IsNullOrWhiteSpace(name) || name?.Length < 1))
                {
                    if (!string.IsNullOrEmpty(r)) r += " ";
                    r += name;
                }

                if (!(string.IsNullOrWhiteSpace(patronymic) || patronymic?.Length < 1))
                {
                    if (!string.IsNullOrEmpty(r)) r += " ";
                    r += patronymic;
                }
                
                return r;
            }
        }

        public string ПолучитьКороткоеФИО
        {
            get
            {
                var r = string.Empty;
                if (!(string.IsNullOrWhiteSpace(family) || family?.Length < 1)) r += family;
                if (!(string.IsNullOrWhiteSpace(name) || name?.Length < 1)) r += name?[0];
                if (!(string.IsNullOrWhiteSpace(patronymic) || patronymic?.Length < 1)) r += patronymic?[0];
                return r;
            }
        }
    }
}