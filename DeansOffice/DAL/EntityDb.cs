using DeansOffice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeansOffice.DAL
{
    class EntityDb
    {
        static Model1 dataBase = new Model1();

        static public ObservableCollection<Student> LoadStudents()
        {
            try
            {
                return new ObservableCollection<Student>(dataBase.Students.Include(s => s.Study).ToList());
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to download data from the database, please restart your aplication or try later");
                return null;
            }
            
        }

        static public ObservableCollection<Study> LoadStudies()
        {
            try
            {
                return new ObservableCollection<Study>(dataBase.Studies.ToList());
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to download data from the database, please restart your aplication or try later");
                return null;
            }
            
        }

        static public ObservableCollection<Subject> LoadSubjects()
        {
            try
            {
                return new ObservableCollection<Subject>(dataBase.Subjects.ToList());
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to download data from the database, please restart your aplication or try later");
                return null;
            }
            
        }

        static public ObservableCollection<Student_Subject> LoadStudents_Subj()
        {
            try
            {
                return new ObservableCollection<Student_Subject>(dataBase.Student_Subject.ToList());
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to download data from the database, please restart your aplication or try later");
                return null;
            }
            
        }

        static public Subject FindSubject(int id)
        {
            try
            {
                return dataBase.Subjects.Where(s => s.IdSubject == id).First();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to find subject in the database, please restart your aplication or try later");
                return null;
            }
            
        }

        static public void DeleteStudent(Student stRm)
        {
            try
            {
                DeleteSubjects(stRm.IdStudent);
                dataBase.Entry<Student>(stRm).State = EntityState.Deleted;
                dataBase.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to delete student from the database, please restart your aplication or try later");
            }
        }

        static public void DeleteSubjects(int id)
        {
            while (true)
            {
                var st_sbRm = dataBase.Student_Subject.FirstOrDefault(s => s.IdStudent == id);
                if (st_sbRm != null)
                {
                    dataBase.Student_Subject.Remove(st_sbRm);
                    dataBase.SaveChanges();
                }
                else break;
            }
        }

        static public void CreateStud(Student st, List<Subject> list)
        {
            try
            {
                dataBase.Students.Add(st);
                dataBase.SaveChanges();
                AddSubjectsToStudent(st, list);
                dataBase.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to create student in the database, please restart your aplication or try later");
            }
        }

        static public void UpdateStud(Student st, List<Subject> list)
        {
            try
            {
                dataBase.Entry<Student>(st).State = EntityState.Modified;
                DeleteSubjects(st.IdStudent);
                AddSubjectsToStudent(st, list);
                dataBase.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to update student in the database, please restart your aplication or try later");
            }
        }

        static public void AddSubjectsToStudent(Student st, List<Subject> list)
        {
            int id = dataBase.Students.Where(s => s.IndexNumber.Equals(st.IndexNumber)).First().IdStudent;
            foreach (Subject sb in list)
            {
                dataBase.Student_Subject.Add(new Student_Subject
                {
                    IdStudent = id,
                    IdSubject = sb.IdSubject,
                    CreatedAt = "18-04-2019"
                });
            }
        }
    }
}
