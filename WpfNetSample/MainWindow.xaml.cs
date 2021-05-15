using System.Windows;

namespace WpfNetSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person Person { get; set; }
        public MainWindow(IPersonService personService)
        {
            Person = personService.GetPerson();
            InitializeComponent();
            DataContext = Person;
        }
    }



    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
