using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forests
{
    //1234
    public partial class BackgroundSelect : Form
    {
        private string ImagePath;
        public Bitmap BackgroundMap { get; set; }
        public BackgroundSelect()
        {
            InitializeComponent();

            // Adding color options
            ColumnHeader colorsHeader = new ColumnHeader();
            colorsHeader.Text = "Color Options:";
            this.ColorSelect.Columns.Add(colorsHeader);
            this.ColorSelect.View = View.Details;
            this.ColorSelect.Items.Add("Green");
            this.ColorSelect.Items.Add("Blue");
            this.ColorSelect.Items.Add("Black");
            this.ColorSelect.Items.Add("White");
            this.ColorSelect.Items.Add("Yellow");
            this.ColorSelect.Items.Add("Brown");
            this.ColorSelect.Items.Add("Orange");
            this.ColorSelect.Items.Add("Purple");
        }

        private void ImageSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog getImagePath = new OpenFileDialog())
            {
                //getImagePath.Filter = "*.";
                getImagePath.RestoreDirectory = true;

                if (getImagePath.ShowDialog() == DialogResult.OK)
                {
                    ImagePath = getImagePath.FileName;
                    this.imagePath.Text = ImagePath;
                }
            }
        }


        //1234 this is a strategy pattern kind of
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.imagePath.Text != "" && this.ColorSelect.SelectedItems.Count > 0) return;
            if (this.imagePath.Text != "")
            {
                BackgroundMap = new Bitmap(this.imagePath.Text);

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            
            if (this.ColorSelect.SelectedIndices.Count > 0)
            {
                Color color = Color.FromName(this.ColorSelect.SelectedItems[0].ToString());
                Bitmap tempBMP = new Bitmap(1, 1);
                tempBMP.SetPixel(0, 0, color);
                BackgroundMap = new Bitmap(tempBMP, 1000, 1000);

                this.DialogResult = DialogResult.OK;

                this.Close();
            }

            
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.imagePath.Text = "";
            this.ColorSelect.SelectedItems.Clear();
        }
    }
}
