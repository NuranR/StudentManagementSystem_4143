using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using WPF_Student_UI;
using System.Windows.Controls;


namespace WPF_Student_UI
{
    public partial class AddStudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int? age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double? gpa;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;


        public AddStudentWindowVM(Student s)
        {
            NewStudent = s;

            firstname = NewStudent.FirstName;
            lastname = NewStudent.LastName;
            age = NewStudent.Age;
            gpa = NewStudent.GPA;
            dateofbirth = NewStudent.DateOfBirth;
            selectedImage = NewStudent.Image;

        }

        public AddStudentWindowVM()
        {

        }

        //Upload photo 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image has been uploaded successfully!","ALERT!");
            }
        }


        public Student NewStudent { get; private set; }
        public Action CloseAction { get; internal set; }

        //Save details
        [RelayCommand]
        public void Save()
        {
            if (gpa < 0.0 || gpa > 4.0) //check for valid GPA value
            {
                MessageBox.Show("Please enter valid GPA value", "ERROR!");
                return;
            }
            if (NewStudent == null)
            {
                NewStudent = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,
                    GPA = gpa
                };            
            }
            else
            {
                NewStudent.FirstName = firstname;
                NewStudent.LastName = lastname;
                NewStudent.Age = age;
                NewStudent.GPA = gpa;
                NewStudent.Image = selectedImage;
                NewStudent.DateOfBirth = dateofbirth;
            }

            if (NewStudent.FirstName != null)
            {
                CloseAction();
            }
            Application.Current.MainWindow.Show();
        }
    }
}
