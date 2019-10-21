using System;
using System.Windows.Forms;
using System.Drawing;

namespace SalesReportPredictionSystem
{
    public class EditSale : Form, IHasSubmit
    {
        public bool CanSubmit { set { } }

        public EditSale(int orderNo)
        {
        }
    }
}
