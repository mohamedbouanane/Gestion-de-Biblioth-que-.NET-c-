using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.ComponentModel.Design;
using System.Runtime.Versioning;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace IHM.Components.Effect
{

    class FlexElipseControls : Component//,ISupportInitialize
    {

        public FlexElipseControls()
        {/*
            Parent.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);*/
        }
            
        /*
        int _RoundCornerRadius = 30;
        [Browsable(true), Category("C")]
        [DefaultValue(30)]
        public int RoundCornerRadius { get { return _RoundCornerRadius; } set { _RoundCornerRadius = Math.Abs(value); Invalidate(); } }

        
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            int tmpSoundCornerRadius = Math.Min(Math.Min(_RoundCornerRadius, Parent.Width - 2), Parent.Height - 2);

            if (Parent.Width > 1 && Parent.Height > 1)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Rectangle Rect = new Rectangle(0, 0, Parent.Width - 1, Parent.Height - 1);
                GraphicsPath GraphPath = FlexGraphics.GetRoundPath(Rect, tmpSoundCornerRadius);
                /*
                if (tmpSoundCornerRadius > 0)
                {
                    using (PathGradientBrush PGBrush = new PathGradientBrush(GraphPathShadow))
                    {
                        PGBrush.WrapMode = WrapMode.Clamp;
                        ColorBlend colorBlend = new ColorBlend(3);
                        colorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(180, Color.DimGray), Color.FromArgb(180, Color.DimGray) };

                        colorBlend.Positions = new float[] { 0f, .1f, 1f };

                        PGBrush.InterpolationColors = colorBlend;
                        e.Graphics.FillPath(PGBrush, GraphPathShadow);
                    }
                }
                
                // Draw backgroup

                LinearGradientBrush brush = new LinearGradientBrush(Rect, Parent.BackColor, Parent.BackColor, LinearGradientMode.BackwardDiagonal);
                e.Graphics.FillPath(brush, GraphPath);
                // e.Graphics.DrawPath(new Pen(Color.FromArgb(180, this._borderColor), _borderWidth), GraphPath);

            }            
        }
        */

        public static GraphicsPath GetRoundPath(Rectangle r, int depth)
        {
            GraphicsPath GraphPath = new GraphicsPath();

            GraphPath.AddArc(r.X, r.Y, depth, depth, 180, 90);
            GraphPath.AddArc(r.X + r.Width - depth, r.Y, depth, depth, 270, 90);
            GraphPath.AddArc(r.X + r.Width - depth, r.Y + r.Height - depth, depth, depth, 0, 90);
            GraphPath.AddArc(r.X, r.Y + r.Height - depth, depth, depth, 90, 90);
            GraphPath.AddLine(r.X, r.Y + r.Height - depth, r.X, r.Y + depth / 2);

            return GraphPath;
        }
    }
}
