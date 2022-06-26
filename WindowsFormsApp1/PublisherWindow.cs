using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PublisherWindow : Form
    {
        public PublisherWindow()
        {
            InitializeComponent();
        }

        private void publishersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.publishersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDbDataSet);

        }

        private void PublisherWindow_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDbDataSet.Publishers". При необходимости она может быть перемещена или удалена.
            this.publishersTableAdapter.Fill(this.libraryDbDataSet.Publishers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDbDataSet.Publishers". При необходимости она может быть перемещена или удалена.
            this.publishersTableAdapter.Fill(this.libraryDbDataSet.Publishers);

        }

        private void publishersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.publishersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDbDataSet);

        }
    }
}
