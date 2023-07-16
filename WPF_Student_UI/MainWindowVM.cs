using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_Student_UI;

namespace WPF_Student_UI
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        
        [ObservableProperty]
        public Student selectedStudent = null;


        [RelayCommand]
        public static void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }


        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentWindowVM();
            vm.Title = "Add Student";
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();
                       
            if (vm.NewStudent.FirstName != null) 
            {
                Students.Add(vm.NewStudent);
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                Students.Remove(selectedStudent);                                
            }
            else
            {
                MessageBox.Show("Plese select a student first", "ERROR!");
            }
        }
        [RelayCommand]
        public void EditStudent()
        {
            if (selectedStudent != null)
            {
                var vm = new AddStudentWindowVM(selectedStudent);
                vm.Title = "EDIT USER";
                var window = new AddStudentWindow(vm);

                window.ShowDialog();
                int index = Students.IndexOf(selectedStudent);
                Students.RemoveAt(index);
                Students.Insert(index, vm.NewStudent);
            }
            else
            {
                MessageBox.Show("Please select a student first", "ERROR!");
            }
        }

        //initial student data list
        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            students.Add(new Student("Tom", "Brown", 25, image1, "2000/1/13", 3.44));
            //students.Add(new Student("Tom", "Brown", 25, image1, "2000/1/13"));
            BitmapImage image2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
            students.Add(new Student("Tim", "Cook", 22, image2, "2001/11/4", 3.72));
            //students.Add(new Student("Tim", "Cook", 22, image2, "2001/11/4"));
            BitmapImage image3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            students.Add(new Student("James", "Black", 21, image3, "1998/4/17", 2.93));
            //students.Add(new Student("James", "Black", 21, image3, "1998/4/17"));
            BitmapImage image4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
            students.Add(new Student("Anne", "White", 23, image4, "1999/7/12", 3.61));
            //students.Add(new Student("Anne", "White", 23, image4, "1999/7/12"));
        }

    }
}
