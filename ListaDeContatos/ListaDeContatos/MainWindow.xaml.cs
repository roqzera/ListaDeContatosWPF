using ListaDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ListaDeContatos
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private Contato contato;
        private ContatoDaoMySql contatoDao = new ContatoDaoMySql();
        List<Contato> contatos;
        public MainWindow()
        {
            InitializeComponent();
            GridContatos.ItemsSource = contatoDao.BuscarTodos();

        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            contato = new Contato()
            {
                nome = tbxNomeCompleto.Text,
                idade = Convert.ToInt16(tbxIdade.Text),
                cidade = tbxCidade.Text
            };
            contatoDao.Adicionar(contato);
            contatoDao.BuscarTodos();


        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            GridContatos.ItemsSource = contatoDao.BuscarTodos();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < GridContatos.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = GridContatos.Columns[j].Header;
            }
            for (int i = 0; i < GridContatos.Columns.Count; i++)
            {
                for (int j = 0; j < GridContatos.Items.Count; j++)
                {
                    TextBlock b = GridContatos.Columns[i].GetCellContent(GridContatos.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        private void BtnImportar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
