using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace ParallelSQLQueries
{
    class DBConnection
    {
      

        public static SqlConnection  GetConnectionString()
        {
            //set connection string with db
            return new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Алина\Education\МАГИСТРАТУРА\Магистратура\2 term\Parallel Programming\Projects\CourseWork\ParallelSQLQueries\ParallelSQLQueries\DATABASE.mdf;Integrated Security=True");
        }
//--------------------Выборка всех книг--------------------------------------//
        public static SqlDataReader SelectAllBooks()
        {
            Console.WriteLine("Run Querie#1 Time:{0}\n", DateTime.Now.TimeOfDay);   
            SqlConnection DBConn = GetConnectionString();
            DBConn.Open(); //open db
            //sql command
            SqlCommand command = new SqlCommand("exec SelectAllBooks", DBConn);
            SqlDataReader reader = null;
            try
            {
                //execute query
                reader = command.ExecuteReader();
                Console.WriteLine("Querie#1 was succesful. | Time:{0}\n", DateTime.Now.TimeOfDay);
                
            }
            catch
            {
                Console.WriteLine("Error! Query#1!\n");

            }
            return reader;//return extracted data
          
        }
//--------------------Выборка всех студентов--------------------------------------//
        public static SqlDataReader SelectAllStudents()
        {
            Console.WriteLine("Run Querie#2 Time:{0}\n", DateTime.Now.TimeOfDay);
            SqlConnection DBConn = GetConnectionString();
            DBConn.Open();

            SqlCommand command = new SqlCommand("exec SelectAllStudents", DBConn);
            SqlDataReader reader = null;
            try
            {
                reader=command.ExecuteReader();
                Console.WriteLine("Querie#2 was succesful. | Time:{0}\n", DateTime.Now.TimeOfDay);
                
            }
            catch
            {
                Console.WriteLine("Error! Query#2!\n");

            }
            return reader;
        }
    
 //--------------------Выборка всех студентов и книг-------------------------//
        public static SqlDataReader  SelectAllStudentsKeepBook()
        {
            Console.WriteLine("Run Querie#3 Time:{0}\n" , DateTime.Now.TimeOfDay);
            SqlConnection DBConn = GetConnectionString();
            DBConn.Open();
        
            SqlCommand command = new SqlCommand("exec SelectAllStudentsBook", DBConn);
            
            SqlDataReader reader = null;
            try
            {
                reader=command.ExecuteReader();
                Console.WriteLine("Querie#3 was succesful. | Time:{0}\n", DateTime.Now.TimeOfDay);
               
                
            }
            catch
            {
                Console.WriteLine("Error! Query#3!\n");
               
            }
            return reader;
            
           
           
           // return m;
        }
    }
}
