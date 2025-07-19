using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAcademy.Interfaces
{
    public interface IbaseRepositoryManyToMany<T1,T2>
    {
        public int Insert(T1 val1);
        public bool Delete(T1 val1, T2 val2);
        public (T1 val1, T2 val2) Update(T1 val1, T2 val2);
    }
}
