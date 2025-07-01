using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManager.DataBase.Data;
using StudentManager.Services;
using StudentManager.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManager.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private IRepository<Student> _studentRepository;
        private IServiceProvider _serviceProvider;
        public MainWindowViewModel(IRepository<Student> studentRepositoryService, IServiceProvider serviceProvider)
        {
            _studentRepository = studentRepositoryService;
            _serviceProvider = serviceProvider;
            Students = new ObservableCollection<Student>(_studentRepository.GetAll());

            AddCommand = new RelayCommand(AddStudent);
            EditCommand = new RelayCommand(EditStudent);
            DeleteCommand = new RelayCommand(DeleteStudent);
        }
        public string Title { get; set; } = "Student Manager";


        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students 
        {
            get => _students;
            set => SetProperty(ref _students, value);

        }

        private Student _selectStudent;
        public Student SelectStudent
        {
            get => _selectStudent;
            set => SetProperty(ref _selectStudent, value);

        }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }

        private void AddStudent()
        {
            var window = new StudentWindow();
            var vm = new StudentWindowViewModel(window, _serviceProvider);
            window.DataContext = vm;

            if (window.ShowDialog() != true)
            {
                Students = new ObservableCollection<Student>(_studentRepository.GetAll());

            }
        }

        private void EditStudent()
        {
            if (SelectStudent == null)
            {
                MessageBox.Show("Для начала выберете студента");
                return;
            }

            var window = new StudentWindow();
            var vm = new StudentWindowViewModel(window,_serviceProvider, SelectStudent);
            window.DataContext = vm;

            if (window.ShowDialog() != true)
            {
                Students = new ObservableCollection<Student>(_studentRepository.GetAll());
            }
        }

        private void DeleteStudent()
        {
            if (SelectStudent == null) 
            {
                MessageBox.Show("Для начала выберете студента");
                return;
            }

            _studentRepository.Remove(SelectStudent);
            Students.Remove(SelectStudent);
            SelectStudent = null;
        }

    }
}
