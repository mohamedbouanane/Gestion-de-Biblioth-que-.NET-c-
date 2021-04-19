using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* To fix:
* le déplacement du controle dans le cadre d'un formulaire.
*/

/* To add:
 *déplacer les objets sans s'intertionner entre elle.
 */

namespace IHM.Components.Animation
{
    /// <summary>
    /// Permet d'appliquer un effet de déplacement sur n'import quel object d'un formulaire. 
    /// </summary>
    /// <remarks>
    /// Ce composant ne fonctionne pas parfaitement s'il est mis dirrectement dans un formulaire,
    /// Le mieux setait de l'inclure dans un panel ou un composant similaire.
    /// </remarks>
    public class TacosCode_DragControl : Component
    {

        #region Parameters

        Control _target_control = null;
        /// <summary>Le contrôle qui sera déplacé lors du maintien du clic gauche de la souris sur le ControlMouse (si null, le form parent sera ciblée).</summary>
        [Browsable(true), Category("TacosCode: Control"), DefaultValue(null), Description("Le Control à déplasser.")]
        public Control TargetControl { get { return _target_control == null ? ControlMouse.FindForm() : _target_control; } set { _target_control = value; } }


        Control _control_mouse = null;
        /// <summary>Le control sur qui maintenire le clique pour déplasser le control sible.</summary>
        [Browsable(true), Category("TacosCode: Control"), DefaultValue(null), Description("Le Control sur qui cliquer pour déplasser le control cible.")]
        public Control ControlMouse { get { return _control_mouse; } set { _control_mouse = value; AffectDragParameters(); } }


        bool _drag_horisontal = true;
        /// <summary>Déplassement Horisontal.</summary>
        [Browsable(true), Category("TacosCode: Drag parameters"), DefaultValue("true"), Description("Déplassement Horisontal.")]
        public bool DragHorisontal { get { return _drag_horisontal; } set { _drag_horisontal = value; } }


        bool _drag_vertical = true;
        /// <summary>Déplassement Vertical.</summary>
        [Browsable(true), Category("TacosCode: Drag parameters"), DefaultValue("true"), Description("Déplassement Vertical.")]
        public bool DragVertical { get { return _drag_vertical; } set { _drag_vertical = value; } }


        AnchorStyles _limit_drag_parend_border = AnchorStyles.None;
        /// <summary>Limiter le champs de déplassement du control sible au bordure du controle parent.</summary>
        [Browsable(true), Category("TacosCode: Drag parameters"), DefaultValue("AnchorStyles.None"), Description("Limiter le champs de déplassement du control sible au bordure du colntole parent.")]
        public AnchorStyles LimitDragParendBorder { get { return _limit_drag_parend_border; } set { _limit_drag_parend_border = value; } }


        bool no_intersecting = false;
        /// <summary>Empêche le controle de transpercer les autres controles qu'il croise l'ors de son déplacement.</summary>
        [Browsable(true), Category("TacosCode: Drag parameters"), DefaultValue(false), Description("Empêche le controle de transpercer les autres controles qu'il croise l'ors de son déplacement.")]
        public bool NoIntersecting { get { return no_intersecting; } set { no_intersecting = value; } }

        #endregion Parameters


        #region Events

        void AffectDragParameters()
        {
            try
            {
                if (ControlMouse != null)
                {
                    ControlMouse.MouseDown += new System.Windows.Forms.MouseEventHandler(Control_MouseDown);
                    ControlMouse.MouseMove += new System.Windows.Forms.MouseEventHandler(Control_MouseMove);
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }


        Point lastPoint;
        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        void Control_MouseMove(object sender, MouseEventArgs e)
        {
            // Verrifier que c'est le bouton gauche de la souris qui a était cliqué.
            if (e.Button == MouseButtons.Left && TargetControl != null && ControlMouse != null)
            {
                if (TargetControl is Form)
                    MoveTheForm(e);
                else if (TargetControl.Parent != null)
                    MoveControlInsideParent(e);
            }
        }

        string border;
        bool pass;
        void MoveControlInsideParent(MouseEventArgs e)
        {
            try
            {
                border = LimitDragParendBorder.ToString();
                // le point extraime le plus bas et le plus à droite.
                Point maxPointTargetControl = new Point(new Size(TargetControl.Parent.Width, TargetControl.Parent.Height));
                Point controlePoint = new Point(new Size(TargetControl.Width, TargetControl.Height));

                Point maxPointControlInParent;

                pass = true;
                /*
                if (NoIntersecting)
                    foreach (Control controlParent in this.TargetControl.Parent.Controls)
                    {
                        maxPointControlInParent = new Point(new Size(controlParent.Width, controlParent.Height));

                        //if (TargetControl.Top < controlParent.Top && TargetControl.Top > maxPointControlInParent.Y && TargetControl.Left >= maxPointControlInParent.X /*&&
                        //     maxPointTargetControl.Y > controlParent.Top && maxPointTargetControl.Y < maxPointControlParent.Y && maxPointTargetControl.X > controlParent.Left)

                        if(maxPointTargetControl.Y > controlParent.Top && TargetControl.Top < maxPointControlInParent.Y)
                        {
                            pass = false;
                            break;
                        }
                    }
                    */


                if (pass)
                {
                    if (DragHorisontal)
                    {
                        int newY = e.Y - lastPoint.Y;

                        // S'assurer que l'action du mouvement horizontale ne s'effectue que 
                        // si le controle ne touche ne le hot ni le bas du controle parent.
                        if (border.Contains("None") || border.Contains("Top") && TargetControl.Top != 0 && newY < 0 ||
                            border.Contains("Bottom") && TargetControl.Top + controlePoint.Y != maxPointTargetControl.Y && newY > 0)
                            TargetControl.Top += newY;

                        // S'assurer que sa ne dépasse pas le min top parent.
                        if (border.Contains("Top") && TargetControl.Top < 0)
                            TargetControl.Top = 0;

                        // S'assurer que sa ne dépasse pas le max top parent.
                        if (border.Contains("Bottom") && TargetControl.Top + controlePoint.Y > maxPointTargetControl.Y)
                            TargetControl.Top = maxPointTargetControl.Y - controlePoint.Y;
                    }

                    if (DragVertical)
                    {
                        int newX = e.X - lastPoint.X;

                        // S'assurer que l'action du mouvement horizontale ne s'effectue que 
                        // si le controle ne touche ne la gauche ni la droite du controle parent.
                        if (border.Contains("None") || border.Contains("Left") && TargetControl.Left != 0 && newX < 0 ||
                            border.Contains("Right") && TargetControl.Left + controlePoint.X != maxPointTargetControl.X && newX > 0)
                            TargetControl.Left += newX;

                        // S'assurer que sa ne dépasse pas le min Left
                        if (border.Contains("Left") && TargetControl.Left < 0)
                            TargetControl.Left = 0;

                        // S'assurer que sa ne dépasse pas le max Left
                        if (border.Contains("Right") && TargetControl.Left + controlePoint.X > maxPointTargetControl.X)
                            TargetControl.Left = maxPointTargetControl.X - controlePoint.X;
                    }
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        void MoveTheForm(MouseEventArgs e)
        {
            try
            {
                TargetControl.Top += e.Y - lastPoint.Y;
                TargetControl.Left += e.X - lastPoint.X;
            }
            catch (Exception x) { Msg.Show(x); }
        }

        #endregion Events

    }
}

