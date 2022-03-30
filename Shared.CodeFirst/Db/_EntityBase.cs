using System.Runtime.Serialization;
using QWERTY.Shared.Db.Validation;

namespace QWERTY.Shared.Db
{
    public interface IId
    {
        public int id { get; set; }
    }
    
    /// <summary>
    /// Назначение абстрактного класса заключается в предоставлении общего определения для базового класса,
    /// которое могут совместно использовать несколько производных классов. Например, в библиотеке классов может быть определен абстрактный класс,
    /// используемый в качестве параметра для многих из ее функций, поэтому программисты, использующие эту библиотеку,
    /// должны задать свою реализацию этого класса, создав производный класс.
    /// </summary>
    public abstract class _EntityBase : Validator
    {
        public const string SchemaName = "1";
        /*public const string SchemaName = "SYSTEM";*/
        /*public const string SchemaName = "dbo";*/
        private const bool DebugMode = DebugModeOn;

        // public virtual int ид_заявки_на_создание { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
