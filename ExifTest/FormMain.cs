using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ExifLibrary
{
    public partial class FormMain : Form
    {
        private ImageFile data;

        public FormMain()
        {
            InitializeComponent();

            lblByteOrder.Text = "";
            lblThumbnail.Text = "";

            lvExif.ListViewItemSorter = new ListViewColumnSorter();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (fdOpen.ShowDialog() == DialogResult.OK)
            {
                ReadFile(fdOpen.FileName);
            }
        }

        private void ReadFile(string filename)
        {
            data = ImageFile.FromFile(filename);

            UpdateView();

            this.Text = Path.GetFileName(filename) + " - Exif Test";
            lblStatus.Text = Path.GetFileName(filename);
        }

        private void UpdateView()
        {
            btnEmbed.Enabled = (data != null) && (data.Format != ImageFileFormat.Unknown);
            btnSave.Enabled = (data != null) && (data.Format != ImageFileFormat.Unknown);
            lvExif.Items.Clear();
            foreach (ExifProperty item in data.Properties)
            {
                ListViewItem lvitem = new ListViewItem(item.Name);
                lvitem.SubItems.Add(item.ToString());
                lvitem.SubItems.Add(Enum.GetName(typeof(IFD), ExifTagFactory.GetTagIFD(item.Tag)));
                lvitem.Tag = item;
                lvExif.Items.Add(lvitem);
            }
            if (data.Thumbnail == null)
                pbThumb.Image = null;
            else
                pbThumb.Image = data.Thumbnail.ToImage();
            pbOrigin.Image = data.ToImage();

            lblThumbnail.Text = "Thumbnail: " + (data.Thumbnail == null ? "None" : data.Thumbnail.ToImage().Width.ToString() + "x" + data.Thumbnail.ToImage().Height.ToString());
            pgExif.SelectedObject = data;

            lvExif.Sort();
        }

        private void lvExif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvExif.SelectedItems.Count == 0)
                tbField.Text = "";
            else
            {
                ExifProperty item = (ExifProperty)lvExif.SelectedItems[0].Tag;

                StringBuilder s = new StringBuilder();
                s.AppendFormat("Tag: {0}{1}", item.Tag, Environment.NewLine);
                string val = item.ToString();
                if (val.Length > 50) val = val.Substring(0, 50) + " ...";
                s.AppendFormat("Value: {0}{1}", val, Environment.NewLine);
                s.AppendFormat("IFD: {0}{1}", item.IFD, Environment.NewLine);
                s.AppendFormat("Interop. TagID: {0} (0x{0:X2}){1}", item.Interoperability.TagID, Environment.NewLine);
                s.AppendFormat("Interop. Type: {0} (0x{0:X2}){1}", item.Interoperability.TypeID, Environment.NewLine);
                s.AppendFormat("Interop. Count: {0} (0x{0:X4}){1}", item.Interoperability.Count, Environment.NewLine);
                s.AppendFormat("Interop. Data Length: {0}{1}", item.Interoperability.Data.Length, Environment.NewLine);
                s.AppendFormat("Interop. Data: {0}", ByteArrayToString(item.Interoperability.Data), Environment.NewLine);
                tbField.Text = s.ToString();
            }
        }

        private string ByteArrayToString(byte[] data)
        {
            StringBuilder s = new StringBuilder();
            foreach (byte b in data)
                s.AppendFormat("0x{0:X2} ", b);
            return s.ToString();
        }

        private void lvExif_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewColumnSorter sorter = (ListViewColumnSorter)lvExif.ListViewItemSorter;

            if (e.Column == sorter.SortColumn)
                sorter.ReverseSortOrder();
            else
            {
                sorter.SortColumn = e.Column;
                sorter.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            }

            lvExif.Sort();
        }

        private void cmsInterop_Opening(object sender, CancelEventArgs e)
        {
            cmsInterop.Items.Clear();
            if (lvExif.SelectedItems.Count == 0)
            {
                ToolStripMenuItem menu = new ToolStripMenuItem("Select a tag to view.");
                menu.Enabled = false;
                cmsInterop.Items.Add(menu);
            }
            else
            {
                ToolStripItem menu = null;
                ExifProperty item = (ExifProperty)lvExif.SelectedItems[0].Tag;
                ExifBitConverter conv = new ExifBitConverter(BitConverterEx.SystemByteOrder, BitConverterEx.SystemByteOrder);

                byte[] bytes = item.Interoperability.Data;
                if (bytes.Length >= 2)
                {
                    menu = new ToolStripMenuItem("ushort: " + conv.ToUInt16(bytes, 0));
                    cmsInterop.Items.Add(menu);
                    menu = new ToolStripMenuItem("short: " + conv.ToInt16(bytes, 0));
                    cmsInterop.Items.Add(menu);
                    menu = new ToolStripSeparator();
                    cmsInterop.Items.Add(menu);
                }
                if (bytes.Length >= 4)
                {
                    menu = new ToolStripMenuItem("uint: " + conv.ToUInt32(bytes, 0));
                    cmsInterop.Items.Add(menu);
                    menu = new ToolStripMenuItem("int: " + conv.ToInt32(bytes, 0));
                    cmsInterop.Items.Add(menu);
                    menu = new ToolStripSeparator();
                    cmsInterop.Items.Add(menu);
                }
                {
                    menu = new ToolStripMenuItem("ascii: " + Encoding.ASCII.GetString(bytes));
                    cmsInterop.Items.Add(menu);
                    menu = new ToolStripMenuItem("utf-8: " + Encoding.UTF8.GetString(bytes));
                    cmsInterop.Items.Add(menu);
                    menu = new ToolStripMenuItem("utf-16: " + Encoding.Unicode.GetString(bytes));
                    cmsInterop.Items.Add(menu);
                }
            }
        }

        private void embedThumbnailToolStripButton_Click(object sender, EventArgs e)
        {
            if (fdOpen.ShowDialog() == DialogResult.OK)
            {
                data.Thumbnail = ImageFile.FromFile(fdOpen.FileName);
                UpdateView();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (data.Format == ImageFileFormat.JPEG)
            {
                fdSave.Filter = "JPEG Images *.jpg|*.jpg";
            }
            else if (data.Format == ImageFileFormat.TIFF)
            {
                fdSave.Filter = "TIFF Images *.tiff|*.tiff";
            }
            else if (data.Format == ImageFileFormat.PNG)
            {
                fdSave.Filter = "PNG Images *.png|*.png";
            }
            else
            {
                MessageBox.Show("Unknown image format", "Exif Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (fdSave.ShowDialog() == DialogResult.OK)
            {
                data.Save(fdSave.FileName);
                ReadFile(fdSave.FileName);
            }
        }
    }
}

