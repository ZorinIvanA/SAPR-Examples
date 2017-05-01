using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases
{
    public class Student
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int CityId { get; set; }
        public String CityName { get; set; }
        public Int32 Id { get; set; }

        public static List<Student> GetStudentsFromDatabase()
        {
            List<Student> result = new List<Student>();
            using (SqlConnection cn = new SqlConnection("Server=DESKTOP-0P1KQ65\\SQLEXPRESS;Database=myDataBase;Trusted_Connection=True;"))
            {
                cn.Open();
                //SqlCommand cmd = new SqlCommand("SELECT s.*, c.Name as CityName FROM Students s INNER JOIN Cities c ON s.CityId = c.ID", cn);
                SqlCommand cmd = new SqlCommand("spGetStudents", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@CityId", 1);                
                p.IsNullable = true;
                cmd.Parameters.Add(p);

                var studentsReader = cmd.ExecuteReader();
                while (studentsReader.Read())
                {
                    Student s = new Student();                    
                    s.Id = (int)studentsReader["ID"];
                    s.Name = (string)studentsReader["Name"];
                    s.Birthday = (DateTime)studentsReader["Birthday"];
                    s.CityId = (int)studentsReader["CityId"];
                    s.CityName = (string)studentsReader["CityName"];

                    result.Add(s);
                }
            }

            return result;
        }
    }
}
