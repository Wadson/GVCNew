namespace SisControl.View
{
    partial class FrmInsertBancoSqlCompact
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
            this.btnInserir = new System.Windows.Forms.Button();
            this.listBoxScripts = new System.Windows.Forms.ListBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(636, 415);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Insert";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // listBoxScripts
            // 
            this.listBoxScripts.FormattingEnabled = true;
            this.listBoxScripts.Location = new System.Drawing.Point(84, 33);
            this.listBoxScripts.Name = "listBoxScripts";
            this.listBoxScripts.Size = new System.Drawing.Size(627, 368);
            this.listBoxScripts.TabIndex = 1;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(636, 4);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(75, 23);
            this.btnPaste.TabIndex = 2;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // FrmInsertBancoSqlCompact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.listBoxScripts);
            this.Controls.Add(this.btnInserir);
            this.Name = "FrmInsertBancoSqlCompact";
            this.Text = "FrmInsertBancoSqlCompact";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.ListBox listBoxScripts;
        private System.Windows.Forms.Button btnPaste;
    }
}