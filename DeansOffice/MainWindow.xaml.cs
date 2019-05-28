using DeansOffice.DAL;
using DeansOffice.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeansOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IManageStudent
    {

        EntityDb db = new EntityDb();
        public MainWindow()
        {
            InitializeComponent();
            GetStudents();
        }

        public void GetStudents()
        {
            StudentsDataGrid.ItemsSource = EntityDb.LoadStudents();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void StudentsDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ChoosedText.Content = "You have choosen " + StudentsDataGrid.SelectedItems.Count + " students";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you realy want to delete?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                foreach (Student s in StudentsDataGrid.SelectedItems)
                {
                    EntityDb.DeleteStudent(s);
                }
                GetStudents();
            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailedBox win = new DetailedBox("Add", null, this);
            win.Show();
        }

        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student student = (Student)StudentsDataGrid.SelectedItem;
            DetailedBox win = new DetailedBox("Modify", student, this);
            win.Show();
        }

        void IManageStudent.AddStudent(Student st, List<Subject> list)
        {
            EntityDb.CreateStud(st, list);
            GetStudents();
        }

        void IManageStudent.ModifyStudent(Student st, List<Subject> list)
        {
            EntityDb.UpdateStud(st, list);
            GetStudents();
        }
    }


}
