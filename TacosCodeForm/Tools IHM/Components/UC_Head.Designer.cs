namespace TacosCodeForm.Tools
{
    partial class UC_Head
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_head = new System.Windows.Forms.Panel();
            this.tacosPicturButton1 = new IHM.Components.TacosCode_PicturButton();
            this.tacosPictBtnMinimize = new IHM.Components.TacosCode_PicturButton();
            this.tacosPictBtnMaximize = new IHM.Components.TacosCode_PicturButton();
            this.tacosPictBtnExit = new IHM.Components.TacosCode_PicturButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel_head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tacosPicturButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tacosPictBtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tacosPictBtnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tacosPictBtnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_head);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 417);
            this.panel1.TabIndex = 0;
            // 
            // panel_head
            // 
            this.panel_head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(64)))), ((int)(((byte)(71)))));
            this.panel_head.Controls.Add(this.tacosPicturButton1);
            this.panel_head.Controls.Add(this.tacosPictBtnMinimize);
            this.panel_head.Controls.Add(this.tacosPictBtnMaximize);
            this.panel_head.Controls.Add(this.tacosPictBtnExit);
            this.panel_head.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_head.Location = new System.Drawing.Point(0, 0);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(740, 20);
            this.panel_head.TabIndex = 0;
            this.panel_head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_head_MouseDown);
            this.panel_head.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_head_MouseMove);
            // 
            // tacosPicturButton1
            // 
            this.tacosPicturButton1.ActiveButton = false;
            this.tacosPicturButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPicturButton1.ColorMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPicturButton1.ColorMouseEnter = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPicturButton1.ColorMouseLeave = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPicturButton1.CornerRadius = 0;
            this.tacosPicturButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tacosPicturButton1.Location = new System.Drawing.Point(0, 0);
            this.tacosPicturButton1.MarkActiveButton = true;
            this.tacosPicturButton1.Name = "tacosPicturButton1";
            this.tacosPicturButton1.NameGroupeButton = "";
            this.tacosPicturButton1.Size = new System.Drawing.Size(34, 20);
            this.tacosPicturButton1.TabIndex = 4;
            this.tacosPicturButton1.TabStop = false;
            // 
            // tacosPictBtnMinimize
            // 
            this.tacosPictBtnMinimize.ActiveButton = false;
            this.tacosPictBtnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPictBtnMinimize.ColorMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPictBtnMinimize.ColorMouseEnter = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPictBtnMinimize.ColorMouseLeave = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPictBtnMinimize.CornerRadius = 0;
            this.tacosPictBtnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.tacosPictBtnMinimize.Location = new System.Drawing.Point(668, 0);
            this.tacosPictBtnMinimize.MarkActiveButton = true;
            this.tacosPictBtnMinimize.Name = "tacosPictBtnMinimize";
            this.tacosPictBtnMinimize.NameGroupeButton = "";
            this.tacosPictBtnMinimize.Size = new System.Drawing.Size(24, 20);
            this.tacosPictBtnMinimize.TabIndex = 3;
            this.tacosPictBtnMinimize.TabStop = false;
            this.tacosPictBtnMinimize.Click += new System.EventHandler(this.tacosPictBtnMinimize_Click);
            // 
            // tacosPictBtnMaximize
            // 
            this.tacosPictBtnMaximize.ActiveButton = false;
            this.tacosPictBtnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPictBtnMaximize.ColorMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPictBtnMaximize.ColorMouseEnter = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPictBtnMaximize.ColorMouseLeave = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPictBtnMaximize.CornerRadius = 0;
            this.tacosPictBtnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.tacosPictBtnMaximize.Location = new System.Drawing.Point(692, 0);
            this.tacosPictBtnMaximize.MarkActiveButton = true;
            this.tacosPictBtnMaximize.Name = "tacosPictBtnMaximize";
            this.tacosPictBtnMaximize.NameGroupeButton = "";
            this.tacosPictBtnMaximize.Size = new System.Drawing.Size(24, 20);
            this.tacosPictBtnMaximize.TabIndex = 2;
            this.tacosPictBtnMaximize.TabStop = false;
            this.tacosPictBtnMaximize.Click += new System.EventHandler(this.tacosPictBtnMaximize_Click);
            // 
            // tacosPictBtnExit
            // 
            this.tacosPictBtnExit.ActiveButton = false;
            this.tacosPictBtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPictBtnExit.ColorMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPictBtnExit.ColorMouseEnter = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(41)))));
            this.tacosPictBtnExit.ColorMouseLeave = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.tacosPictBtnExit.CornerRadius = 0;
            this.tacosPictBtnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.tacosPictBtnExit.Location = new System.Drawing.Point(716, 0);
            this.tacosPictBtnExit.MarkActiveButton = true;
            this.tacosPictBtnExit.Name = "tacosPictBtnExit";
            this.tacosPictBtnExit.NameGroupeButton = "";
            this.tacosPictBtnExit.Size = new System.Drawing.Size(24, 20);
            this.tacosPictBtnExit.TabIndex = 1;
            this.tacosPictBtnExit.TabStop = false;
            this.tacosPictBtnExit.Click += new System.EventHandler(this.tacosPictBtnExit_Click);
            // 
            // UC_Head
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "UC_Head";
            this.Size = new System.Drawing.Size(740, 417);
            this.Load += new System.EventHandler(this.UC_Head_Load);
            this.panel1.ResumeLayout(false);
            this.panel_head.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tacosPicturButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tacosPictBtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tacosPictBtnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tacosPictBtnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_head;
        private System.Windows.Forms.ToolTip toolTip1;
        private IHM.Components.TacosCode_PicturButton tacosPictBtnMinimize;
        private IHM.Components.TacosCode_PicturButton tacosPictBtnMaximize;
        private IHM.Components.TacosCode_PicturButton tacosPictBtnExit;
        private IHM.Components.TacosCode_PicturButton tacosPicturButton1;
    }
}
