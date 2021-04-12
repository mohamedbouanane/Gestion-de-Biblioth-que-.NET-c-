using BibliothèqueUniversitaire.Context;
using BibliothèqueUniversitaire.Models;
using BibliothèqueUniversitaire.Services;
using BibliothèqueUniversitaire.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliothèqueUniversitaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ILivreService livreService = new LivreService(new AppDbContext());

            livreService.Save(new LivreEntity(
               "Lite Code", 365, 343.45D, new List<AuteurEntity>() {
new AuteurEntity(new PersoneEntity("BOUANANE","Mohamed","Fès")) },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane")
               ));

        }
    }
}
