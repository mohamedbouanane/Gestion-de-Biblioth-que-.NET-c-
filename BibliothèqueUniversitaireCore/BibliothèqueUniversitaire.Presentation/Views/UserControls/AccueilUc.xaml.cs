using BibliothèqueUniversitaire.ApplicationWpfCore.Context;
using BibliothèqueUniversitaire.ApplicationWpfCore.Repositories.Impl;
using BibliothèqueUniversitaire.ApplicationWpfCore.Services;
using BibliothèqueUniversitaire.ApplicationWpfCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliothèqueUniversitaire.WpfCore.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AccueilUc.xaml
    /// </summary>
    public partial class AccueilUc : UserControl
    {
        // To do later : Injection des dépendences & gestion des resources des services

        ILivreService livreService;
        IAdherentService adherentService;

        public AccueilUc()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //afficher_livres_non_rendue();
        }

        #region Events

        private void afficher_livres_non_rendue_lbl_MouseDown(object sender, MouseButtonEventArgs e) 
            => afficher_livres_non_rendue();
        
        private void afficher_livres_acheté_indIrectement_de_editeur_lbl_MouseDown(object sender, MouseButtonEventArgs e) 
            => afficher_livres_acheté_indIrectement_de_editeur();
        
        private void afficher_emprunteurs_lbl_MouseDown(object sender, MouseButtonEventArgs e) 
            => afficher_emprunteurs();      

        #endregion Events

        #region Methodes helper

        void afficher_livres_non_rendue()
        {         
            using (var ctx = new ModelContext())
                try
                {
                    livreService = new LivreService(new LivreRepository(ctx));
                    dg_livres.ItemsSource = livreService.GetAllLivresNonRendue().ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        void afficher_livres_acheté_indIrectement_de_editeur()
        {
            using (var ctx = new ModelContext())
                try
                {
                    livreService = new LivreService(new LivreRepository(ctx));
                    dg_livres.DataContext = livreService.GetAllLivresAchetéIndirectementDeLEditeur();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }          
        }
        
        void afficher_emprunteurs()
        {
            using (var ctx = new ModelContext())
                try
                {
                    livreService = new LivreService(new LivreRepository(ctx));
                    dg_livres.DataContext = adherentService.GetAllAdherentEmprunts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        #endregion Methodes helper

    }
}
