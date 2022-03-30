namespace QWERTY.Shared.Enums
{
    public class Standard
    {
        public abstract class Range
        {
            public abstract class Min1_MaxValue
            {
                public const int Min = 1;
                public const int Max = int.MaxValue;    
            }
        }

        public abstract class Length
        {
            public abstract class Min2_Max1024
            {
                public const int MinLength = 2;
                public const int MaxLength = 1024;    
            }
            
            public abstract class Min2_Max255
            {
                public const int MinLength = 2;
                public const int MaxLength = 255;    
            }
            
            public abstract class Min2_Max100
            {
                public const int MinLength = 2;
                public const int MaxLength = 100;    
            }
            
            public abstract class Min2_Max20
            {
                public const int MinLength = 2;
                public const int MaxLength = 20;    
            }
            
            public abstract class Min2_Max40
            {
                public const int MinLength = 2;
                public const int MaxLength = 40;    
            }
        }
    }

    public abstract class Annotation
    {
        public class id : Standard.Range.Min1_MaxValue
        {
        }

        public class tnum : Standard.Range.Min1_MaxValue
        {
            public new const int Max = 999999;
        }

        public abstract class family : Standard.Length.Min2_Max100 {}

        public abstract class name : Standard.Length.Min2_Max100 {}

        public abstract class patronymic : Standard.Length.Min2_Max100 {}

        public abstract class login_name : Standard.Length.Min2_Max20 {}
        
        public abstract class email : Standard.Length.Min2_Max40 {}
        
        public abstract class ObjectName : Standard.Length.Min2_Max255 {}
        
        public abstract class path : Standard.Length.Min2_Max1024 {}
        
        public abstract class description : Standard.Length.Min2_Max255 {}
        
        public abstract class ProfileName : Standard.Length.Min2_Max100 {}
    }
}