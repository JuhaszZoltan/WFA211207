using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA211207
{
    public partial class FrmMain : Form
    {
        public MyButton[,] Palya { get; set; }
        public int Meret { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            Palya = new MyButton[7, 7];
            Meret = 70;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            for (int oszlop = 0; oszlop < Palya.GetLength(0); oszlop++)
            {
                for (int sor = 0; sor < Palya.GetLength(1); sor++)
                {
                    Palya[oszlop, sor] = new MyButton()
                    {
                        Bounds = new Rectangle()
                        {
                            X = oszlop * Meret,
                            Y = sor * Meret,
                            Height = Meret,
                            Width = Meret,
                        },
                        Text = $"s: {sor}; o:{oszlop}",
                        Hely = new Point(sor, oszlop),
                    };
                    Palya[oszlop, sor].MouseDown += FrmMain_MouseDown;

                    this.Controls.Add(Palya[oszlop, sor]);
                }
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor =
                e.Button == MouseButtons.Left ?
                Color.Green : Color.Red;

            MessageBox.Show((sender as MyButton).Hely.X + "");
        }
    }
}
