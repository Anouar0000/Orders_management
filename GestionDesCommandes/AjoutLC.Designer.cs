
namespace GestionDesCommandes
{
    partial class AjoutLC
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.txtQte = new System.Windows.Forms.TextBox();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtProduit = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAnnuler = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Désignation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantité";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Prix";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "D.T.";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPrix);
            this.panel1.Controls.Add(this.txtQte);
            this.panel1.Controls.Add(this.txtDesignation);
            this.panel1.Controls.Add(this.txtType);
            this.panel1.Controls.Add(this.txtProduit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 127);
            this.panel1.TabIndex = 6;
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(383, 84);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(176, 22);
            this.txtPrix.TabIndex = 10;
            // 
            // txtQte
            // 
            this.txtQte.Location = new System.Drawing.Point(97, 84);
            this.txtQte.Name = "txtQte";
            this.txtQte.Size = new System.Drawing.Size(239, 22);
            this.txtQte.TabIndex = 9;
            // 
            // txtDesignation
            // 
            this.txtDesignation.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDesignation.Location = new System.Drawing.Point(97, 49);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.ReadOnly = true;
            this.txtDesignation.Size = new System.Drawing.Size(507, 22);
            this.txtDesignation.TabIndex = 8;
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtType.Location = new System.Drawing.Point(383, 15);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(221, 22);
            this.txtType.TabIndex = 7;
            // 
            // txtProduit
            // 
            this.txtProduit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtProduit.Location = new System.Drawing.Point(97, 15);
            this.txtProduit.Name = "txtProduit";
            this.txtProduit.ReadOnly = true;
            this.txtProduit.Size = new System.Drawing.Size(226, 22);
            this.txtProduit.TabIndex = 6;
            this.txtProduit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtAnnuler);
            this.panel2.Controls.Add(this.btnValider);
            this.panel2.Location = new System.Drawing.Point(12, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 59);
            this.panel2.TabIndex = 7;
            // 
            // txtAnnuler
            // 
            this.txtAnnuler.Location = new System.Drawing.Point(514, 4);
            this.txtAnnuler.Name = "txtAnnuler";
            this.txtAnnuler.Size = new System.Drawing.Size(113, 52);
            this.txtAnnuler.TabIndex = 1;
            this.txtAnnuler.Text = "Annuler";
            this.txtAnnuler.UseVisualStyleBackColor = true;
            this.txtAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(390, 4);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(113, 52);
            this.btnValider.TabIndex = 0;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(13, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(628, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Pour choisir un produit il faut mettre le curseur sur le champ produit. ensuite a" +
    "ppuyer sur ENTRER";
            // 
            // AjoutLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 257);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AjoutLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter une nouvelle ligne commande";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.TextBox txtQte;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button txtAnnuler;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtDesignation;
        public System.Windows.Forms.TextBox txtType;
        public System.Windows.Forms.TextBox txtProduit;
    }
}