using DeansOffice.DAL;
using DeansOffice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DeansOffice
{
    /// <summary>
    /// Interaction logic for DetailedBox.xaml
    /// </summary>
    /// 

public partial class DetailedBox : Window
    {
        private IManageStudent _link;
        private Student _student;
        private string _mode;

        public DetailedBox(string st, Student s, IManageStudent l)
        {
            InitializeComponent();
            _link = l;
            _student = s;
            _mode = st;
            boxName.Content = st + " student";
            comboBox.ItemsSource = EntityDb.LoadStudies();
            comboBox.DisplayMemberPath = "Name";
            listBox.ItemsSource = EntityDb.LoadSubjects();
            listBox.DisplayMemberPath = "Name";
            if (_student != null)
            {
                fBox.Text = _student.FirstName;
                lBox.Text = _student.LastName;
                iBox.Text = _student.IndexNumber;
                foreach(Study study in EntityDb.LoadStudies())
                {
                    if (study.IdStudies == _student.IdStudies) comboBox.SelectedItem = study;
                }
                foreach (Student_Subject sb in EntityDb.LoadStudents_Subj())
                {
                    if (sb.IdStudent == _student.IdStudent) listBox.SelectedItem = EntityDb.FindSubject(sb.IdSubject);
                }
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            int studId = verifyData();
            if (studId == 0) return;
            List<Subject> list = new List<Subject>();
            foreach (Subject sub in listBox.SelectedItems)
            {
                list.Add(sub);
            }
            if (_mode.Equals("Add"))
            {
                Student st = new Student
                {
                    FirstName = fBox.Text,
                    LastName = lBox.Text,
                    IndexNumber = iBox.Text,
                    IdStudies = studId,
                    Address = fBox.Text + lBox.Text
                };
                _link.AddStudent(st, list);
            }
            else
            {
                _student.FirstName = fBox.Text;
                _student.LastName = lBox.Text;
                _student.IndexNumber = iBox.Text;
                _student.IdStudies = studId;
                _link.ModifyStudent(_student, list);
            }
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public int verifyData()
        {
            if (string.IsNullOrWhiteSpace(lBox.Text) || lBox.Text.Length < 1)
            {
                MessageBox.Show("Wrong input in 1 row!");
                return 0;
            }
            if (string.IsNullOrWhiteSpace(fBox.Text) || fBox.Text.Length < 1)
            {
                MessageBox.Show("Wrong input in 2 row!");
                return 0;
            }
            if (string.IsNullOrWhiteSpace(iBox.Text) || iBox.Text.Length < 2 || !iBox.Text[0].Equals('s') ||
                !int.TryParse(iBox.Text.Substring(1), out int n))
            {
                MessageBox.Show("Wrong index number!(starts with 's' and only numbers after)");
                return 0;
            }
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show("You should select one study type!");
                return 0;
            }
            if (listBox.SelectedItems == null)
            {
                MessageBox.Show("You should select at least 1 subject!");
                return 0;
            }
            foreach(Study study in EntityDb.LoadStudies())
            {
                if (((Study)comboBox.SelectedItem).IdStudies == study.IdStudies) return study.IdStudies;
            }
            MessageBox.Show("Sth wrong...");
            return 0;
        }
    }
}
