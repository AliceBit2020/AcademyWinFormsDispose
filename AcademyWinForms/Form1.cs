using Dapper;
using ExamAcademy;
using ExamAcademy.Controller;
using ExamAcademy.Model;
using ExamAcademy.Repository;

namespace AcademyWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
          
            InitializeComponent();
            comboBox1.Items.Add("4.Вывести названия групп, у которых больше одного куратора.");
        }

        private async void  comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i  = comboBox1.SelectedIndex;


            IEnumerable<string> grpName=await MyController.Task4Async();///+async
            listBox1.Items.Clear();
            listBox1.Items.AddRange(grpName.ToArray());

        }
    }
}
