namespace ExifLibrary
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.fdOpen = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ssExif = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblByteOrder = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblThumbnail = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lvExif = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tbField = new System.Windows.Forms.TextBox();
            this.cmsInterop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pgExif = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.pbThumb = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbOrigin = new System.Windows.Forms.PictureBox();
            this.tsExif = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEmbed = new System.Windows.Forms.ToolStripButton();
            this.fdSave = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.ssExif.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigin)).BeginInit();
            this.tsExif.SuspendLayout();
            this.SuspendLayout();
            // 
            // fdOpen
            // 
            this.fdOpen.Filter = "Image Files (*.jpg;*.tiff;*.png)|*.jpg;*.tiff;*.png";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.ssExif);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(893, 472);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(893, 525);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsExif);
            // 
            // ssExif
            // 
            this.ssExif.Dock = System.Windows.Forms.DockStyle.None;
            this.ssExif.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblByteOrder,
            this.lblThumbnail});
            this.ssExif.Location = new System.Drawing.Point(0, 0);
            this.ssExif.Name = "ssExif";
            this.ssExif.Size = new System.Drawing.Size(893, 22);
            this.ssExif.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // lblByteOrder
            // 
            this.lblByteOrder.Name = "lblByteOrder";
            this.lblByteOrder.Size = new System.Drawing.Size(74, 17);
            this.lblByteOrder.Text = "#ByteOrder#";
            // 
            // lblThumbnail
            // 
            this.lblThumbnail.Name = "lblThumbnail";
            this.lblThumbnail.Size = new System.Drawing.Size(79, 17);
            this.lblThumbnail.Text = "#Thumbnail#";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.label2);
            this.splitContainer4.Panel2.Controls.Add(this.pbOrigin);
            this.splitContainer4.Size = new System.Drawing.Size(893, 472);
            this.splitContainer4.SplitterDistance = 607;
            this.splitContainer4.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(607, 472);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lvExif);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tbField);
            this.splitContainer3.Size = new System.Drawing.Size(366, 472);
            this.splitContainer3.SplitterDistance = 336;
            this.splitContainer3.TabIndex = 0;
            // 
            // lvExif
            // 
            this.lvExif.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvExif.HideSelection = false;
            this.lvExif.Location = new System.Drawing.Point(0, 0);
            this.lvExif.MultiSelect = false;
            this.lvExif.Name = "lvExif";
            this.lvExif.Size = new System.Drawing.Size(366, 336);
            this.lvExif.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvExif.TabIndex = 2;
            this.lvExif.UseCompatibleStateImageBehavior = false;
            this.lvExif.View = System.Windows.Forms.View.Details;
            this.lvExif.SelectedIndexChanged += new System.EventHandler(this.lvExif_SelectedIndexChanged);
            this.lvExif.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvExif_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Exif Tag";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 128;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IFD";
            // 
            // tbField
            // 
            this.tbField.ContextMenuStrip = this.cmsInterop;
            this.tbField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbField.Location = new System.Drawing.Point(0, 0);
            this.tbField.Multiline = true;
            this.tbField.Name = "tbField";
            this.tbField.ReadOnly = true;
            this.tbField.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbField.Size = new System.Drawing.Size(366, 132);
            this.tbField.TabIndex = 0;
            // 
            // cmsInterop
            // 
            this.cmsInterop.Name = "cmsInterop";
            this.cmsInterop.Size = new System.Drawing.Size(61, 4);
            this.cmsInterop.Opening += new System.ComponentModel.CancelEventHandler(this.cmsInterop_Opening);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pgExif);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.pbThumb);
            this.splitContainer2.Size = new System.Drawing.Size(237, 472);
            this.splitContainer2.SplitterDistance = 314;
            this.splitContainer2.TabIndex = 0;
            // 
            // pgExif
            // 
            this.pgExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgExif.HelpVisible = false;
            this.pgExif.Location = new System.Drawing.Point(0, 0);
            this.pgExif.Name = "pgExif";
            this.pgExif.Size = new System.Drawing.Size(237, 314);
            this.pgExif.TabIndex = 0;
            this.pgExif.ToolbarVisible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thumbnail";
            // 
            // pbThumb
            // 
            this.pbThumb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbThumb.BackColor = System.Drawing.Color.Black;
            this.pbThumb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbThumb.Location = new System.Drawing.Point(0, 22);
            this.pbThumb.Name = "pbThumb";
            this.pbThumb.Size = new System.Drawing.Size(237, 132);
            this.pbThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbThumb.TabIndex = 2;
            this.pbThumb.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Original";
            // 
            // pbOrigin
            // 
            this.pbOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOrigin.BackColor = System.Drawing.Color.Black;
            this.pbOrigin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbOrigin.Location = new System.Drawing.Point(0, 22);
            this.pbOrigin.Name = "pbOrigin";
            this.pbOrigin.Size = new System.Drawing.Size(282, 450);
            this.pbOrigin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOrigin.TabIndex = 3;
            this.pbOrigin.TabStop = false;
            // 
            // tsExif
            // 
            this.tsExif.Dock = System.Windows.Forms.DockStyle.None;
            this.tsExif.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsExif.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnEmbed});
            this.tsExif.Location = new System.Drawing.Point(0, 0);
            this.tsExif.Name = "tsExif";
            this.tsExif.Size = new System.Drawing.Size(893, 31);
            this.tsExif.Stretch = true;
            this.tsExif.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::ExifLibrary.Properties.Resources.open_document_24;
            this.btnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(28, 28);
            this.btnOpen.Text = "&Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(28, 28);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnEmbed
            // 
            this.btnEmbed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEmbed.Enabled = false;
            this.btnEmbed.Image = global::ExifLibrary.Properties.Resources.favorites_24;
            this.btnEmbed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEmbed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmbed.Name = "btnEmbed";
            this.btnEmbed.Size = new System.Drawing.Size(28, 28);
            this.btnEmbed.Text = "&Embed Thumbnail...";
            this.btnEmbed.Click += new System.EventHandler(this.embedThumbnailToolStripButton_Click);
            // 
            // fdSave
            // 
            this.fdSave.Filter = "JPEG Images *.jpg|*.jpg";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 525);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "FormMain";
            this.Text = "Exif Test";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ssExif.ResumeLayout(false);
            this.ssExif.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigin)).EndInit();
            this.tsExif.ResumeLayout(false);
            this.tsExif.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fdOpen;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pbThumb;
        private System.Windows.Forms.ToolStrip tsExif;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.StatusStrip ssExif;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblByteOrder;
        private System.Windows.Forms.ToolStripStatusLabel lblThumbnail;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lvExif;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox tbField;
        private System.Windows.Forms.SaveFileDialog fdSave;
        private System.Windows.Forms.ContextMenuStrip cmsInterop;
        private System.Windows.Forms.PropertyGrid pgExif;
        private System.Windows.Forms.ToolStripButton btnEmbed;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PictureBox pbOrigin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

