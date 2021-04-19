using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IHM.Components
{
    public class TacosCode_PicturButton : PictureBox
    {

        public TacosCode_PicturButton()
        {
            try
            {
                SetToDefaultParrameters();

                this.MouseEnter += new System.EventHandler(Apply_Style_MouseEnter);
                this.MouseLeave += new System.EventHandler(Apply_Style_MouseLeave);
                this.MouseDown += new System.Windows.Forms.MouseEventHandler(Apply_Style_MouseDown);
                this.MouseUp += new System.Windows.Forms.MouseEventHandler(Change_BackColor_MouseUp);
                this.MouseClick += new System.Windows.Forms.MouseEventHandler(Change_BackColor_MouseClick);
                this.BackColorChanged += new System.EventHandler(Change_BackColor_BackColorChanged);

                ListeGroupeButton.Add(this);
            }
            catch (Exception x) { MessageBox.Show(x.Message); }
        }


        #region Default parrameters

        void SetToDefaultParrameters()
        {
            try
            {

                if(this.Parent != null)
                    SetDefaultColors(
                        this.Parent.BackColor,
                        this.Parent.BackColor,
                        this.Parent.BackColor
                    );

                /*
                SetDefaultColors(
                    System.Drawing.ColorTranslator.FromHtml("#ffcd29"),
                    System.Drawing.ColorTranslator.FromHtml("#ffc509"),
                    System.Drawing.ColorTranslator.FromHtml("#FFB700")
                );*/

                SetDefaultIcones(
                    null,
                    null,
                    null
                    );

                CornerRadius = 6;

                this.Width = this.Height = 50;

                Invalidate();

            }
            catch (Exception x) { MessageBox.Show(x.Message); }
        }

        public void SetDefaultColors(Color ColorMouseEnter, Color ColorMouseDown, Color ColorMouseLeave)
        {
            try
            {
                this.ColorMouseEnter = ColorMouseEnter;
                this.ColorMouseDown  = ColorMouseDown;
                this.ColorMouseLeave = ColorMouseLeave;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void SetDefaultIcones(Image ImageMouseEnter, Image ImageMouseDown, Image ImageMouseLeave)
        {
            try
            {
                this.ImageMouseEnter = ImageMouseEnter;
                this.ImageMouseDown  = ImageMouseDown;
                this.ImageMouseLeave = ImageMouseLeave;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        #endregion Default parrameters


        #region Description

        //private static readonly string DESCRIPTION;

        #endregion Description


        #region Grouping parameters

        internal class Flex_Properties_Categories
        {
            public const string FLEX_CUSTOM_SETTINGS = "Flex: Custom Settings";
            public const string FLEX_IMG_SETTINGS = "Flex: Image Settings";
            public const string FLEX_COLOR_SETTINGS = "Flex: Color Settings";
        }

        #endregion Grouping parameters


        #region Rounding borders

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);


        int _corner_radius;
        /// <summary>Rounding borders.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_CUSTOM_SETTINGS), DefaultValue(5), Description("Rounding borders")]
        public int CornerRadius
        {
            get { return _corner_radius; }
            set { _corner_radius = value; }
            /*
            set {
                _corner_radius = value; this.SizeChanged += (sender, eventArgs) => this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, _corner_radius, _corner_radius));
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, _corner_radius, _corner_radius)); Invalidate();
            }*/
        }

        #endregion Rounding borders


        #region Image

        Image _img_mouse_enter;
        /// <summary>.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_IMG_SETTINGS), DefaultValue(null), Description("")]
        public Image ImageMouseEnter { get { return _img_mouse_enter; } set { _img_mouse_enter = value; } }

        Image _Image_MouseDown;
        /// <summary>.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_IMG_SETTINGS), DefaultValue(null), Description("")]
        public Image ImageMouseDown { get { return _Image_MouseDown; } set { _Image_MouseDown = value; } }

        Image _Image_MouseLeave;
        /// <summary>.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_IMG_SETTINGS), DefaultValue(null), Description("")]
        public Image ImageMouseLeave { get { return _Image_MouseLeave; } set { this.Image = _Image_MouseLeave = value; Invalidate(); } }

        #endregion Image


        #region Color management

        Color _color_mouse_enter;
        /// <summary>.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_COLOR_SETTINGS), DefaultValue("Color.Transparent"), Description("")]
        public Color ColorMouseEnter { get { return _color_mouse_enter; } set { _color_mouse_enter = value; } }

        Color _color_mouse_down;
        /// <summary>.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_COLOR_SETTINGS), DefaultValue("Color.Transparent"), Description("")]
        public Color ColorMouseDown { get { return _color_mouse_down; } set { _color_mouse_down = value; } }

        Color _color_mouse_leave;
        /// <summary>.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_COLOR_SETTINGS), DefaultValue("Color.Transparent"), Description("")]
        public Color ColorMouseLeave { get { return _color_mouse_leave; } set { this.BackColor = _color_mouse_leave = value; } }


        // Figer la couleur
        private void Change_BackColor_BackColorChanged(object sender, EventArgs e)
        { if (ActiveButton && MarkActiveButton) ChangeStyle(_color_mouse_down, ImageMouseDown); }

        private void Change_BackColor_MouseClick(object sender, MouseEventArgs e)
        { Change_BackColorActivedButon(this); }

        #endregion Color management


        #region Groupe button

        private static List<TacosCode_PicturButton> ListeGroupeButton = new List<TacosCode_PicturButton>();

        string _groupe_button = "";
        /// <summary>.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_CUSTOM_SETTINGS), DefaultValue("Color.Transparent"), Description("")]
        public string NameGroupeButton { get { return _groupe_button; } set { _groupe_button = value; } }

        bool _active_button = false;
        /// <summary>Si la valeur du ActiveButton est true le bouton passe en mode Active.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_CUSTOM_SETTINGS), DefaultValue("false"), Description("Si la valeur du ActiveButton est true le bouton passe en mode Active")]
        public bool ActiveButton { get { return _active_button; } set { _active_button = value; if (_active_button) SetStyleMouseDown(); else SetStyleMouseLeave(); Invalidate(); } }

        bool _mark_active_button = true;
        /// <summary>Si la valeur est true le bouton Lesse la trace du dernier bouton cliquée.</summary>
        [Browsable(true), Category(Flex_Properties_Categories.FLEX_CUSTOM_SETTINGS), DefaultValue("true"), Description("Si la valeur est true le bouton Lesse la trace du dernier bouton cliquée")]
        public bool MarkActiveButton { get { return _mark_active_button; } set { _mark_active_button = value; } }


        /// <summary>Marquer tout les bouton du même groupe (La Marque sert a Garder la trace du dernier click).</summary>
        public static void MarkActiveButtonGroupe(string NameGroupe, bool Value)
        {
            foreach (TacosCode_PicturButton F in ListeGroupeButton)
                if (F.NameGroupeButton == NameGroupe)
                    F.MarkActiveButton = Value;
        }

        #endregion Groupe button


        #region Events Style

        // Affecter une couleur lors du survole du curseur au dessu du bouton
        private void Apply_Style_MouseEnter(object sender, EventArgs e) { SetStyleMouseEnter(); }
        void SetStyleMouseEnter() { ChangeStyle(_color_mouse_enter, ImageMouseEnter); }

        // Redéfinire la couleur initiale
        private void Apply_Style_MouseLeave(object sender, EventArgs e) { SetStyleMouseLeave(); }
        void SetStyleMouseLeave() { ChangeStyle(_color_mouse_leave, ImageMouseLeave); }

        // Redéfinire la couleur de pression
        private void Apply_Style_MouseDown(object sender, MouseEventArgs e) { SetStyleMouseDown(); }
        void SetStyleMouseDown() { ChangeStyle(_color_mouse_down, ImageMouseDown); }

        // Redéfinire la même couleur de Mouse entre lors du fin clic
        private void Change_BackColor_MouseUp(object sender, MouseEventArgs e) { SetStyleMouseUp(); }
        void SetStyleMouseUp() { if (MouseIsOverControl(this)) ChangeStyle(_color_mouse_enter, ImageMouseEnter); }


        private static void Change_BackColorActivedButon(TacosCode_PicturButton FPressed)
        {
            foreach (TacosCode_PicturButton f in ListeGroupeButton)
                if (f.NameGroupeButton == FPressed.NameGroupeButton && f.NameGroupeButton != null && f.NameGroupeButton != "")
                    if (f == FPressed) f.ActiveButton = true; else f.ActiveButton = false;

        }


        void ChangeStyle(Color backColor, Image image)
        {
            this.BackColor = backColor != null ? backColor : Color.Transparent;
            this.Image = image != null ? image : ImageMouseLeave;
            Invalidate();
        }

        #endregion Events Style


        // Verrifier si le curseur survole l'objet
        private static bool MouseIsOverControl(Control btn) =>
            btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position));

    }
}