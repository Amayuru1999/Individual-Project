using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UI_Design;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace UI_Design
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Person> users;
        [ObservableProperty]
        public Person selectedUser = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4!", "Error!");
        }

        [RelayCommand]
        public void AddPerson()
        {
            var vm = new AddStudentVM();
            vm.title = "ADD USER";
            AddStudent window = new AddStudent(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} user is Deleted \a ");
            }
            else
            {
                MessageBox.Show("Please Select a User!");
            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddStudentVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddStudent(vm);

                window.ShowDialog();

                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);

            }

            else
            {
                MessageBox.Show("Please Select the User!", "Error!");
            }
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<Person>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new Person(23, "Amayuru", "Amarasinghe", "28/11/1999", 3.5, image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new Person(24, "Tom", "Brown", "2/11/1987", 3.8, image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new Person(24, "William", "Balck", "5/4/1998", 3.0, image3));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new Person(21, "Anne", "Stella", "25/5/1995", 3.6, image4));

        }
    }
}
