namespace DBPSA.Web.Models.Report
{
    public class НаименованиеОбъектовСтруктурыОрганизации
    {
        public int id { get; }
        public string fname { get; }

        public НаименованиеОбъектовСтруктурыОрганизации(int id, string fname)
        {
            this.id = id;
            this.fname = fname;
        }

        public override string ToString()
        {
            return $"{{ ID = {id}, FNAME = {fname} }}";
        }
    }
}