using Dapper;
using ExamAcademy;
using ExamAcademy.Model;
using ExamAcademy.Repository;
using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Controller
{
    public static   class MyController
    {
        //4.Вывести названия групп, у которых больше одного куратора.

        public static async Task<IEnumerable<string>> Task4Async()
        {
            //EfCore

          //  ContextDb db = new ContextDb();

            //var grp = db.Group.Include(g=>g.CuratorList).Where(g=>g.CuratorList.Count > 1).ToList();
            //foreach (var item in grp)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Dapper

            using (IDbConnection connection = new SqlConnection(@"Server=DESKTOP-O6DMGPJ\SQLEXPRESS;Database=EF_Academy;TrustServerCertificate=true;Trusted_Connection=True;"))
            {
                //var query = "SELECT g.Name FROM [Group] as g JOIN CuratorGroups as cg ON cg.GroupsId=g.Id GROUP BY g.Name  HAVING Count(cg.GroupsId)>1 ";

                //var grp = connection.Query<Groups>(query, null).ToList();
                //foreach (var item in grp)
                //{
                //    Console.WriteLine(item.Name);
                //}


                //Dapper storage
                var query = "EXEC GroupManyCurators";
                var grp = await connection.QueryAsync<Groups>(query);
                    
                    
                 var result= grp.Select(g=>g.Name);
                
                return result;
            }
        }
    }
}
