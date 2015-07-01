using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ParallelSQLQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            
//------------------------Serial Queries-----------------------------//

           Stopwatch watch = new Stopwatch();
          
            /*
           watch.Reset();
           watch.Start();

           DBConnection.SelectAllBooks();
           DBConnection.SelectAllStudents();
           DBConnection.SelectAllStudentsKeepBook();

           watch.Stop();


           Console.WriteLine("\nSerial queries finished with time:{0} seconds\n\n", watch.Elapsed.TotalSeconds);
            
            */
            


//-------------------------Parallel Queries------------------------------//            
            //TaskFactory tasks=new TaskFactory();
            
            List<Task> tasks = new List<Task>();//create lisyof tasks
            watch.Reset();
            watch.Start();//start timer

            //execute first task
            tasks.Add(Task.Factory.StartNew(() =>
            {
                
             DBConnection.SelectAllBooks();
                
            }));
            

            
            tasks.Add(Task.Factory.StartNew(() =>
            {

             DBConnection.SelectAllStudents();
               
            }));
            

           
            tasks.Add(Task.Factory.StartNew(() =>
            {

                DBConnection.SelectAllStudentsKeepBook();
                
                
            }));

            //waiting untill all task was executed
            Task.WaitAll(tasks.ToArray());
            watch.Stop();
               
            Console.WriteLine("\nParallel queries finished with time:{0} seconds\n", watch.Elapsed.TotalSeconds);
            
            Console.ReadKey();

          

        }
    }
}
