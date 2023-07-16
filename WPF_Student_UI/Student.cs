using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WPF_Student_UI
{
    public class Student
    {
        
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public int? Age { get; set; }
        public BitmapImage Image { get; set; }
        public string DateOfBirth { get; set; }
        public double? GPA { get; set; }
                
        public string ImageURL
        {
            get { return $"/Images/{Image}";}
        }

        public Student(string firstName, string lastName, int? age, BitmapImage image, string dateOfBirth, double? gPA)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Image = image;
            DateOfBirth = dateOfBirth;
            GPA = gPA;
            
        }

        public Student()
        { 
        }

    }
}
