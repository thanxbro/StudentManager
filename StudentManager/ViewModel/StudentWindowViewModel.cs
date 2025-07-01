using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using StudentManager.DataBase.Data;
using StudentManager.Enums;
using StudentManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManager.ViewModel
{
    public class StudentWindowViewModel : ObservableObject
    {
        public string Title { get; set; } 

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _middlename;
        public string Middlename 
        { 
            get => _middlename; 
            set => SetProperty(ref _middlename, value);
        }

        private Gender _selectedGender;
        public Gender SelectedGender 
        { 
            get => _selectedGender;
            set => SetProperty(ref _selectedGender, value);
        }

        private Departament _selectedDepartament;
        public Departament SelectedDepartament 
        { 
            get => _selectedDepartament;
            set => SetProperty(ref _selectedDepartament, value);
        }

        private ObservableCollection<Teacher> _selectedTeachers = new();
        public ObservableCollection<Teacher> SelectedTeachers 
        { 
            get => _selectedTeachers; 
            set => SetProperty(ref _selectedTeachers, value);
        }


        public ObservableCollection<Departament> Departaments { get; }
        public ObservableCollection<Teacher> Teachers { get; }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }

        private IRepository<Student> _studentRepository;
        private IRepository<Departament> _departamentRepository;
        private IRepository<Teacher> _teacherRepository;

        private Student _updateStudent;

        private Window _window;

        public StudentWindowViewModel(Window window, IServiceProvider serviceProvider, Student? student = null)
        {
            _window = window;
            _studentRepository = serviceProvider.GetRequiredService<IRepository<Student>>();
            _departamentRepository = serviceProvider.GetRequiredService<IRepository<Departament>>();
            _teacherRepository = serviceProvider.GetRequiredService<IRepository<Teacher>>();

            if (student is not null)
            {

                _updateStudent = student;
                Name = student.Name;
                LastName = student.LastName;
                Middlename = student.Middlename;
                SelectedGender = student.Gender;
                SelectedDepartament = student.Departament;
                SelectedTeachers = new ObservableCollection<Teacher>(student.Teachers);
            }

            Departaments = new ObservableCollection<Departament>(_departamentRepository.GetAll());
            SelectedDepartament = Departaments.First();
            Teachers = new ObservableCollection<Teacher>(_teacherRepository.GetAll());

            AddCommand = new RelayCommand(AddStudent);
            UpdateCommand = new RelayCommand(UpdateStudent);
        }

        private void AddStudent()
        {
            if (!Validation()) return;
            var newStudent = new Student
            {
                Name = Name,
                LastName = LastName,
                Middlename = Middlename,
                Gender = SelectedGender,
                Departament = SelectedDepartament,
                Teachers = SelectedTeachers.ToList()
            };

            if (_studentRepository.Add(newStudent))
            {
                _window.Close();
            }
            

            
        }

        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Поле Имя не может быть пустым!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                MessageBox.Show("Поле Фамилия не может быть пустым!");
                return false;
            }

            return true;
        }

        private void UpdateStudent()
        {
            if (!Validation()) return;

            _updateStudent.Name = Name;
            _updateStudent.LastName = LastName;
            _updateStudent.Middlename = Middlename;
            _updateStudent.Gender = SelectedGender;
            _updateStudent.Departament = SelectedDepartament;
            _updateStudent.Teachers = SelectedTeachers.ToList();

            if (_studentRepository.Update(_updateStudent))
            {
                _window.Close();
            }

            
        }
    }
}
