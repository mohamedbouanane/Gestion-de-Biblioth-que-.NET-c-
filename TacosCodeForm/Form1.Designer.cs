namespace TacosCodeForm
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_Head1 = new TacosCodeForm.Tools.UC_Head();
            this.tacosCode_DragControl1 = new IHM.Components.Animation.TacosCode_DragControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.scrollBarEnhanced1 = new ScrollBarEnhanced();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 34);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(58, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 150);
            this.panel2.TabIndex = 4;
            // 
            // uC_Head1
            // 
            this.uC_Head1.Location = new System.Drawing.Point(36, 51);
            this.uC_Head1.MinimumSize = new System.Drawing.Size(20, 20);
            this.uC_Head1.Name = "uC_Head1";
            this.uC_Head1.Size = new System.Drawing.Size(293, 100);
            this.uC_Head1.TabIndex = 1;
            // 
            // tacosCode_DragControl1
            // 
            this.tacosCode_DragControl1.ControlMouse = this.button2;
            this.tacosCode_DragControl1.DragHorisontal = true;
            this.tacosCode_DragControl1.DragVertical = true;
            this.tacosCode_DragControl1.LimitDragParendBorder = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tacosCode_DragControl1.NoIntersecting = true;
            this.tacosCode_DragControl1.TargetControl = this.button2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.scrollBarEnhanced1);
            this.panel3.Location = new System.Drawing.Point(604, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 187);
            this.panel3.TabIndex = 5;
            // 
            // scrollBarEnhanced1
            // 
            this.scrollBarEnhanced1.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrollBarEnhanced1.LargeChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scrollBarEnhanced1.Location = new System.Drawing.Point(147, 0);
            this.scrollBarEnhanced1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scrollBarEnhanced1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.scrollBarEnhanced1.MinimumSize = new System.Drawing.Size(0, 51);
            this.scrollBarEnhanced1.Name = "scrollBarEnhanced1";
            this.scrollBarEnhanced1.Size = new System.Drawing.Size(17, 187);
            this.scrollBarEnhanced1.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scrollBarEnhanced1.TabIndex = 0;
            this.scrollBarEnhanced1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(788, 305);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.uC_Head1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Tools.UC_Head uC_Head1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private IHM.Components.Animation.TacosCode_DragControl tacosCode_DragControl1;
        private System.Windows.Forms.Panel panel3;
        private ScrollBarEnhanced scrollBarEnhanced1;
    }
}

