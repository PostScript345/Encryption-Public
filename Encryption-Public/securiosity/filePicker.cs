using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace securiosity
{
    class filePicker
    {
        [STAThread]
        public static string picker()
        {
                OpenFileDialog file = new OpenFileDialog();
                file.ShowDialog();
                return (file.FileName);
        }
    }
}
