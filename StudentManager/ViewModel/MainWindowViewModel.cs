using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public string Title { get; set; } = "Student Manager";

    }
}
