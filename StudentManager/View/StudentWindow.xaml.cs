﻿using StudentManager.DataBase.Data;
using StudentManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentManager.View
{
    /// <summary>
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void TeachersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is StudentWindowViewModel vm)
            {
                vm.SelectedTeachers = new ObservableCollection<Teacher>(TeachersListBox.SelectedItems.Cast<Teacher>().ToList());
            }
        }
    }
}
