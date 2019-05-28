using DeansOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice
{
    public interface IManageStudent
    {
        void AddStudent(Student st, List<Subject> list);
        void ModifyStudent(Student st, List<Subject> list);
}
}
