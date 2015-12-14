namespace GFolder
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pbExpand = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSequence = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cboSequenceType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.gbFolderTree = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCreateTree = new System.Windows.Forms.Button();
            this.tvFolderTree = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpand)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.gbFolderTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Location = new System.Drawing.Point(12, 9);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(70, 13);
            this.lblFolderName.TabIndex = 0;
            this.lblFolderName.Text = "&Folder Name:";
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(88, 6);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(232, 20);
            this.txtFolderName.TabIndex = 1;
            this.txtFolderName.Text = "New Folder";
            this.txtFolderName.TextChanged += new System.EventHandler(this.txtFolderName_TextChanged);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 35);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(50, 32);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(270, 20);
            this.txtPath.TabIndex = 3;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 58);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(98, 27);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(215, 58);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(105, 28);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "&Create Folder";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pbExpand
            // 
            this.pbExpand.Location = new System.Drawing.Point(154, 69);
            this.pbExpand.Name = "pbExpand";
            this.pbExpand.Size = new System.Drawing.Size(16, 16);
            this.pbExpand.TabIndex = 6;
            this.pbExpand.TabStop = false;
            this.toolTip.SetToolTip(this.pbExpand, "Click to Expand");
            this.pbExpand.Click += new System.EventHandler(this.pbExpand_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSequence);
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.txtFrom);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Controls.Add(this.cboSequenceType);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Location = new System.Drawing.Point(10, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 121);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sequence";
            // 
            // btnAddSequence
            // 
            this.btnAddSequence.Location = new System.Drawing.Point(214, 78);
            this.btnAddSequence.Name = "btnAddSequence";
            this.btnAddSequence.Size = new System.Drawing.Size(90, 33);
            this.btnAddSequence.TabIndex = 6;
            this.btnAddSequence.Text = "&Add Sequence";
            this.btnAddSequence.UseVisualStyleBackColor = true;
            this.btnAddSequence.Click += new System.EventHandler(this.btnAddSequence_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(195, 52);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(109, 20);
            this.txtTo.TabIndex = 5;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(166, 58);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "&To:";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(45, 52);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(105, 20);
            this.txtFrom.TabIndex = 3;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 58);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "&From:";
            // 
            // cboSequenceType
            // 
            this.cboSequenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSequenceType.FormattingEnabled = true;
            this.cboSequenceType.Location = new System.Drawing.Point(46, 25);
            this.cboSequenceType.Name = "cboSequenceType";
            this.cboSequenceType.Size = new System.Drawing.Size(258, 21);
            this.cboSequenceType.TabIndex = 1;
            this.cboSequenceType.SelectedIndexChanged += new System.EventHandler(this.cboSequenceType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 28);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "T&ype:";
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.lstLog);
            this.gbLog.Location = new System.Drawing.Point(10, 229);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(310, 159);
            this.gbLog.TabIndex = 8;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log";
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(9, 19);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(295, 134);
            this.lstLog.TabIndex = 0;
            // 
            // gbFolderTree
            // 
            this.gbFolderTree.Controls.Add(this.btnRemove);
            this.gbFolderTree.Controls.Add(this.btnCreateTree);
            this.gbFolderTree.Controls.Add(this.tvFolderTree);
            this.gbFolderTree.Location = new System.Drawing.Point(337, 6);
            this.gbFolderTree.Name = "gbFolderTree";
            this.gbFolderTree.Size = new System.Drawing.Size(283, 382);
            this.gbFolderTree.TabIndex = 9;
            this.gbFolderTree.TabStop = false;
            this.gbFolderTree.Text = "Folder Tree";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(6, 342);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 33);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove Folder";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCreateTree
            // 
            this.btnCreateTree.Location = new System.Drawing.Point(191, 342);
            this.btnCreateTree.Name = "btnCreateTree";
            this.btnCreateTree.Size = new System.Drawing.Size(86, 33);
            this.btnCreateTree.TabIndex = 1;
            this.btnCreateTree.Text = "Create Folders";
            this.btnCreateTree.UseVisualStyleBackColor = true;
            this.btnCreateTree.Click += new System.EventHandler(this.btnCreateTree_Click);
            // 
            // tvFolderTree
            // 
            this.tvFolderTree.HideSelection = false;
            this.tvFolderTree.Location = new System.Drawing.Point(6, 19);
            this.tvFolderTree.Name = "tvFolderTree";
            this.tvFolderTree.Size = new System.Drawing.Size(271, 317);
            this.tvFolderTree.TabIndex = 0;
            this.tvFolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolderTree_AfterSelect);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 398);
            this.Controls.Add(this.gbFolderTree);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbExpand);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.lblFolderName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "G-Folder";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmMain_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbExpand)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.gbFolderTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pbExpand;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSequenceType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnAddSequence;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.GroupBox gbFolderTree;
        private System.Windows.Forms.Button btnCreateTree;
        private System.Windows.Forms.TreeView tvFolderTree;
        private System.Windows.Forms.Button btnRemove;
    }
}

