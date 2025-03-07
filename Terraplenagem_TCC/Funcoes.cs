using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terraplenagem_TCC
{
    public static class Funcoes
    {
        private static bool segurando;
        private static Point ondesegura;

        public static void AbrirTela<T>(ref T tela, Form mdiParent) where T : Form, new()
        {
         
            if (tela == null)
            {
                tela = new T();
                tela.MdiParent = mdiParent;
                tela.Dock = DockStyle.Fill;
                tela.Show();
            }
            else
            {
                tela.Activate();
            }
        }

        public static void Mexeratela(Control control)
        {
            control.MouseDown += Control_MouseDown;
            control.MouseMove += Control_MouseMove;
            control.MouseUp += Control_MouseUp;
            control.DoubleClick += Control_DoubleClick;
        }



        private static void Control_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private static void Control_MouseDown(object sender, MouseEventArgs e)
        {
            segurando = true;
            ondesegura = new Point(e.X, e.Y);
        }

        private static void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (segurando)
            {
                Control control = sender as Control;
                Point p = control.PointToScreen(e.Location);
                control.Parent.Location = new Point(p.X - ondesegura.X, p.Y - ondesegura.Y);
            }
        }

        private static void Control_MouseUp(object sender, MouseEventArgs e)
        {
            segurando = false;
        }

  

    }
    }
