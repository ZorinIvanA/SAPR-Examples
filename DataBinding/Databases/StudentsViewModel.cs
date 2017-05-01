using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases
{
    public class StudentsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(String propertyName)
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<StudentViewModel> Students { get; set; }

        public StudentsViewModel()
        {
            Students = new ObservableCollection<StudentViewModel>();

            var students = Student.GetStudentsFromDatabase();
            foreach(var s in students)
            {
                Students.Add(new StudentViewModel()
                {
                    Birthday = s.Birthday,
                    CityId = s.CityId,
                    CityName= s.CityName,
                    Name = s.Name,
                    Id = s.Id
                });
            }
        }
    }
}
