using System.Linq;
using System.Reflection;
using System.Windows;

namespace VoorbeeldWindowsWPF
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
        }

      
        // using System.Reflection!!!
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlockProductname.Text = Assembly.GetEntryAssembly()
                             .GetCustomAttributes(typeof(AssemblyProductAttribute))
                             .OfType<AssemblyProductAttribute>()
                            .FirstOrDefault().Product;
          

            var versie = Assembly.GetExecutingAssembly().GetName().Version;
            TextBlockVersion.Text = $"Version {versie.Major}.{versie.Minor}.{versie.Build}.{versie.Revision}";

            TextBlockCopyright.Text = Assembly.GetEntryAssembly()
                              .GetCustomAttributes(typeof(AssemblyCopyrightAttribute))
                              .OfType<AssemblyCopyrightAttribute>()
                             .FirstOrDefault().Copyright;

           

            TextBlockCompanyname.Text = Assembly.GetEntryAssembly()
                              .GetCustomAttributes(typeof(AssemblyCompanyAttribute))
                              .OfType<AssemblyCompanyAttribute>()
                             .FirstOrDefault().Company;

            


            TextBlockDescription.Text = Assembly.GetEntryAssembly()
                              .GetCustomAttributes(typeof(AssemblyDescriptionAttribute))
                              .OfType<AssemblyDescriptionAttribute>()
                             .FirstOrDefault().Description;

           


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
