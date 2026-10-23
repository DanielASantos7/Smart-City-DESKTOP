using MundialDESKTOP.V1.Models;
using System.Windows.Forms;

namespace MundialDESKTOP.V1.Views
{
    public partial class DetalhesForm : Form
    {
        private Incident _inc;
        public DetalhesForm(Incident inc)
        {
            InitializeComponent();
            _inc = inc;
        }
    }
}
