
namespace GestionDesCommandes
{
    partial class AjoutProduit2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAnnuler = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TPBox = new System.Windows.Forms.ComboBox();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtCodeProduit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtAnnuler);
            this.panel2.Controls.Add(this.btnValider);
            this.panel2.Location = new System.Drawing.Point(12, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 48);
            this.panel2.TabIndex = 9;
            // 
            // txtAnnuler
            // 
            this.txtAnnuler.Location = new System.Drawing.Point(323, 4);
            this.txtAnnuler.Name = "txtAnnuler";
            this.txtAnnuler.Size = new System.Drawing.Size(113, 39);
            this.txtAnnuler.TabIndex = 1;
            this.txtAnnuler.Text = "Annuler";
            this.txtAnnuler.UseVisualStyleBackColor = true;
            this.txtAnnuler.Click += new System.EventHandler(this.txtAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(204, 4);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(113, 39);
            this.btnValider.TabIndex = 0;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TPBox);
            this.panel1.Controls.Add(this.txtDesignation);
            this.panel1.Controls.Add(this.txtCodeProduit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 121);
            this.panel1.TabIndex = 8;
            // 
            // TPBox
            // 
            this.TPBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TPBox.FormattingEnabled = true;
            this.TPBox.Items.AddRange(new object[] {
            "Imprimante",
            "PC",
            "Scanner",
            "Ecran",
            "Camera",
            "Microphone",
            "Accessoires"});
            this.TPBox.Location = new System.Drawing.Point(119, 79);
            this.TPBox.Name = "TPBox";
            this.TPBox.Size = new System.Drawing.Size(314, 24);
            this.TPBox.TabIndex = 34;
            // 
            // txtDesignation
            // 
            this.txtDesignation.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDesignation.Location = new System.Drawing.Point(118, 47);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(315, 22);
            this.txtDesignation.TabIndex = 8;
            // 
            // txtCodeProduit
            // 
            this.txtCodeProduit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCodeProduit.Location = new System.Drawing.Point(118, 15);
            this.txtCodeProduit.Name = "txtCodeProduit";
            this.txtCodeProduit.Size = new System.Drawing.Size(68, 22);
            this.txtCodeProduit.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code Produit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type de produit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Désignation";
            // 
            // AjoutProduit2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 202);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AjoutProduit2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AjoutProduit2";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button txtAnnuler;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtDesignation;
        public System.Windows.Forms.TextBox txtCodeProduit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TPBox;
    }
}