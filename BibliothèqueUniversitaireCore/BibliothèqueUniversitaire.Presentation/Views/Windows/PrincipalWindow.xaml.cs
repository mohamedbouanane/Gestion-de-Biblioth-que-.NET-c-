using BibliothèqueUniversitaire.ApplicationWpfCore.Services.Impl;
using BibliothèqueUniversitaire.ApplicationWpfCore.Context;
using BibliothèqueUniversitaire.ApplicationWpfCore.Repositories.Impl;
using BibliothèqueUniversitaire.ApplicationWpfCore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BibliothèqueUniversitaire.WpfCore.Views.UserControls;

namespace BibliothèqueUniversitaire.ApplicationWpfCore.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PrincipalWindow : Window
    {
        public PrincipalWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //Task.Run(async () => await new ServicesTests().RunTestsAsync());

        }

        #region Events

        private void accueil_lbl_MouseDown(object sender, MouseButtonEventArgs e) => show_accueil_uc();


        private void bibliothèque_lbl_MouseDown(object sender, MouseButtonEventArgs e) => show_bibliothèque_uc();
        

        private void emprunts_lbl_MouseDown(object sender, MouseButtonEventArgs e) => show_emprunts_uc();

        #endregion Events

        #region Methods helpers

        void show_accueil_uc()
        {
            
        }

        void show_bibliothèque_uc()
        {

        }

        void show_emprunts_uc()
        {

        }

        #endregion Methods helpers

    }
}
