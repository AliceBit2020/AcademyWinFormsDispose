using Dapper;
using ExamAcademy.Interfaces;

using ExamAcademy.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExamAcademy.Repository
{
    public class CuratorGroup : IbaseRepositoryManyToMany<Curator, Groups>
    {
        IDbConnection connection = new SqlConnection(@"Server=DESKTOP-O6DMGPJ\SQLEXPRESS;Database=EF_Academy;TrustServerCertificate=true;Trusted_Connection=True;");
        public bool Delete(Curator val1, Groups val2)
        {
            throw new NotImplementedException();
        }

        public int Insert(Curator curator)
        {
            try
            {
                string query = "INSERT INTO CuratorGroups (CuratorId,GroupsId) VALUES (@CuratorId,@GroupId)";
                int CuratorId = new CuratorRepository().GetIdByName(curator.Name + "," + curator.Surname);

                foreach (var gr in curator.GroupsList)
                    connection.Query(query, new
                    {
                        @CuratorId = CuratorId,
                        @GroupId = new GroupRepository().GetIdByName(gr.Name)
                    });
            }
            catch (SqlException ex)
            {
                Console.Write("CuratorGroup: can't  insert the same vulue in the table");
            }
            return 0;
        }

        public (Curator val1, Groups val2) Update(Curator curator, Groups val2)
        {
            
            throw new NotImplementedException();
           
        }
    }
}
