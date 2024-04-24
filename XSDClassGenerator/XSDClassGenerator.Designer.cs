namespace XSDClassGenerator
{
    partial class XSDClassGenerator
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tab3 = new System.Windows.Forms.TabControl();
            this.tabDescompacta = new System.Windows.Forms.TabPage();
            this.rdb_vbnet = new System.Windows.Forms.RadioButton();
            this.rdb_csharp = new System.Windows.Forms.RadioButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.obtemDiretorios = new System.Windows.Forms.Button();
            this.listagemDiretorios = new System.Windows.Forms.ListBox();
            this.processa = new System.Windows.Forms.Button();
            this.tab3.SuspendLayout();
            this.tabDescompacta.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Diretório Atual";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "C:\\\\";
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.tabDescompacta);
            this.tab3.Location = new System.Drawing.Point(2, 3);
            this.tab3.Margin = new System.Windows.Forms.Padding(4);
            this.tab3.Name = "tab3";
            this.tab3.SelectedIndex = 0;
            this.tab3.Size = new System.Drawing.Size(398, 269);
            this.tab3.TabIndex = 4;
            // 
            // tabDescompacta
            // 
            this.tabDescompacta.Controls.Add(this.rdb_vbnet);
            this.tabDescompacta.Controls.Add(this.rdb_csharp);
            this.tabDescompacta.Controls.Add(this.progressBar);
            this.tabDescompacta.Controls.Add(this.obtemDiretorios);
            this.tabDescompacta.Controls.Add(this.listagemDiretorios);
            this.tabDescompacta.Controls.Add(this.processa);
            this.tabDescompacta.Location = new System.Drawing.Point(4, 24);
            this.tabDescompacta.Margin = new System.Windows.Forms.Padding(4);
            this.tabDescompacta.Name = "tabDescompacta";
            this.tabDescompacta.Padding = new System.Windows.Forms.Padding(4);
            this.tabDescompacta.Size = new System.Drawing.Size(390, 241);
            this.tabDescompacta.TabIndex = 1;
            this.tabDescompacta.Text = "Caminhos dos XSD";
            this.tabDescompacta.UseVisualStyleBackColor = true;
            // 
            // rdb_vbnet
            // 
            this.rdb_vbnet.AutoSize = true;
            this.rdb_vbnet.Location = new System.Drawing.Point(12, 185);
            this.rdb_vbnet.Name = "rdb_vbnet";
            this.rdb_vbnet.Size = new System.Drawing.Size(126, 19);
            this.rdb_vbnet.TabIndex = 19;
            this.rdb_vbnet.TabStop = true;
            this.rdb_vbnet.Text = "Gerar classe Vb.Net";
            this.rdb_vbnet.UseVisualStyleBackColor = true;
            // 
            // rdb_csharp
            // 
            this.rdb_csharp.AutoSize = true;
            this.rdb_csharp.Location = new System.Drawing.Point(12, 160);
            this.rdb_csharp.Name = "rdb_csharp";
            this.rdb_csharp.Size = new System.Drawing.Size(105, 19);
            this.rdb_csharp.TabIndex = 18;
            this.rdb_csharp.TabStop = true;
            this.rdb_csharp.Text = "Gerar classe C#";
            this.rdb_csharp.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.progressBar.Location = new System.Drawing.Point(12, 214);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(275, 11);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 17;
            // 
            // obtemDiretorios
            // 
            this.obtemDiretorios.Location = new System.Drawing.Point(295, 8);
            this.obtemDiretorios.Margin = new System.Windows.Forms.Padding(4);
            this.obtemDiretorios.Name = "obtemDiretorios";
            this.obtemDiretorios.Size = new System.Drawing.Size(88, 26);
            this.obtemDiretorios.TabIndex = 7;
            this.obtemDiretorios.Text = "Procurar";
            this.obtemDiretorios.UseVisualStyleBackColor = true;
            this.obtemDiretorios.Click += new System.EventHandler(this.GetDirectory_Click);
            // 
            // listagemDiretorios
            // 
            this.listagemDiretorios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listagemDiretorios.FormattingEnabled = true;
            this.listagemDiretorios.ItemHeight = 15;
            this.listagemDiretorios.Location = new System.Drawing.Point(12, 11);
            this.listagemDiretorios.Margin = new System.Windows.Forms.Padding(4);
            this.listagemDiretorios.MultiColumn = true;
            this.listagemDiretorios.Name = "listagemDiretorios";
            this.listagemDiretorios.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listagemDiretorios.Size = new System.Drawing.Size(275, 139);
            this.listagemDiretorios.TabIndex = 6;
            this.listagemDiretorios.SelectedIndexChanged += new System.EventHandler(this.DirectoryList_SelectedIndexChanged);
            // 
            // processa
            // 
            this.processa.Location = new System.Drawing.Point(299, 207);
            this.processa.Margin = new System.Windows.Forms.Padding(4);
            this.processa.Name = "processa";
            this.processa.Size = new System.Drawing.Size(84, 26);
            this.processa.TabIndex = 5;
            this.processa.Text = "Processar";
            this.processa.UseVisualStyleBackColor = true;
            this.processa.Click += new System.EventHandler(this.Process_Click);
            // 
            // XSDClassGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 277);
            this.Controls.Add(this.tab3);
            this.Name = "XSDClassGenerator";
            this.Text = "XSDClassGenerator";
            this.tab3.ResumeLayout(false);
            this.tabDescompacta.ResumeLayout(false);
            this.tabDescompacta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private TabControl tab3;
        private TabPage tabDescompacta;
        private Button obtemDiretorios;
        private ListBox listagemDiretorios;
        private Button processa;
        private ProgressBar progressBar;
        private RadioButton rdb_vbnet;
        private RadioButton rdb_csharp;
    }
}