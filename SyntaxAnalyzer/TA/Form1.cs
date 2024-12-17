using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SyntaxAnalyzer
{
    public struct ServiceWord
    {
        public int number;
        public string word;

        public ServiceWord(int _number, string _word)
        {
            number = _number;
            word = _word;
        }
    }

    public struct Separators
    {
        public int number;
        public string separator;

        public Separators(int _number, string _separator)
        {
            number = _number;
            separator = _separator;
        }
    }

    public struct Konstanta
    {
        public int number;
        public string konstanta;

        public Konstanta(int _number, string _konstanta)
        {
            number = _number;
            konstanta = _konstanta;
        }
    }

    public struct Identificator
    {
        public int number;
        public string identificator;

        public Identificator(int _number, string _identificator)
        {
            number = _number;
            identificator = _identificator;
        }
    }

    public partial class Form1 : Form
    {
        private string _programmText;

        List<ServiceWord> serviceWords = new List<ServiceWord>();
        List<Separators> separators = new List<Separators>();
        List<Konstanta> konstanta = new List<Konstanta>();
        List<Identificator> identificators = new List<Identificator>();

        // Объявления элементов управления
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem запускToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лексическийАнализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem синтаксическийАнализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem семантическийАнализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестовыеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem результатыАнализаToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Data.DataTable table_w = new System.Data.DataTable();
            table_w.Columns.Add("№", typeof(int));
            table_w.Columns.Add("Служебные слова", typeof(string));

            System.Data.DataTable table_s = new System.Data.DataTable();
            table_s.Columns.Add("№", typeof(int));
            table_s.Columns.Add("Разделители", typeof(string));

            var serviceWordList = Data.GetServiceWords();
            var separatorsList = Data.GetSeparators();

            for (int i = 0; i < serviceWordList.Count; i++)
            {
                serviceWords.Add(new ServiceWord(i, serviceWordList[i]));
                table_w.Rows.Add(serviceWords[i].number, serviceWords[i].word);
            }

            for (int j = 0; j < separatorsList.Count; j++)
            {
                separators.Add(new Separators(j, separatorsList[j]));
                table_s.Rows.Add(separators[j].number, separators[j].separator);
            }

            dataGridView1.DataSource = table_w;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 100;

            dataGridView2.DataSource = table_s;
            dataGridView2.Columns[0].Width = 30;
            dataGridView2.Columns[1].Width = 100;

        }

        public void SetTableKonstants(List<Konstanta> konstanta)
        {
            System.Data.DataTable table_k = new System.Data.DataTable();
            table_k.Columns.Add("№", typeof(int));
            table_k.Columns.Add("Константы", typeof(string));

            for (int i = 0; i < konstanta.Count; i++)
            {
                table_k.Rows.Add(konstanta[i].number, konstanta[i].konstanta);
            }
            dataGridView4.DataSource = table_k;
            dataGridView4.Columns[0].Width = 30;
            dataGridView4.Columns[1].Width = 100;
        }

        public void SetTableIdentificators(List<Identificator> identificator)
        {
            System.Data.DataTable table_id = new System.Data.DataTable();
            table_id.Columns.Add("№", typeof(int));
            table_id.Columns.Add("Идентификаторы", typeof(string));

            for (int i = 0; i < identificator.Count; i++)
            {
                table_id.Rows.Add(identificator[i].number, identificator[i].identificator);
            }
            dataGridView3.DataSource = table_id;
            dataGridView3.Columns[0].Width = 30;
            dataGridView3.Columns[1].Width = 100;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFile.OpenFile()) != null)
                {
                    string strFileName = openFile.FileName;
                    string fileText = File.ReadAllText(strFileName);
                    richTextBox1.Text = fileText;
                    _programmText = fileText;
                    richTextBox3.Text = "Файл " + strFileName + " открыт!\n";
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFile.FileName;
            File.WriteAllText(filename, richTextBox1.Text);
            richTextBox3.Text = "Файл " + filename + " сохранён!\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void исходныйТекстПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void результатыАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void окноУведомленийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
        }

        private void лексическийToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void CatchError(string errorStr)
        {
            richTextBox3.Text += $"{errorStr}\n";
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void полнаяОчисткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
        }

        public List<string> number = new List<string>();
        public List<string> identificators1 = new List<string>();

        private void анализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* if (richTextBox1.Text != "")
           {
               string _programText1 = Parser.StartParser(_programmText);

               LexicalAnalyz lexicalAnalyzer = new LexicalAnalyz(serviceWords, separators, this);
               richTextBox2.Text = lexicalAnalyzer.StartLexicalAnalyzer(_programText1);

               richTextBox3.Text += "Лексический анализ завершён!\n";

               SyntacticAnalyz syntacticAnalyzer = new SyntacticAnalyz(this, identificators1, number);
               syntacticAnalyzer.CheckProgram(_programText1);

               richTextBox3.Text += "Синтаксический анализ завершен! \n";

               SemanticAnalyz semanticAnalyzer = new SemanticAnalyz(lexicalAnalyzer.numberWithType,
   syntacticAnalyzer._initializedVariables,
   syntacticAnalyzer.operationsAssignments,
   syntacticAnalyzer.expression,
   this);
               semanticAnalyzer.StartSemanticAnalyzer();
               richTextBox3.Text += "Семантический анализ завершен! \n"; 
        } */
        }

        private void лексическийАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox3.Text += "Запущен лексический анализатор! \n";
                string _programText1 = Parser.StartParser(_programmText);

                LexicalAnalyz lexicalAnalyzer = new LexicalAnalyz(serviceWords, separators, this);
                richTextBox2.Text = lexicalAnalyzer.StartLexicalAnalyzer(_programText1);
                _numberWithType = lexicalAnalyzer.numberWithType;
                richTextBox3.Text += "Лексический анализ завершён!\n";
            }
        }

        private void синтаксическийАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox3.Text += "Запущен синтаксический анализатор! \n";
                string _programText1 = Parser.StartParser(_programmText);

                SyntacticAnalyz syntacticAnalyzer = new SyntacticAnalyz(this, identificators1, number);
                syntacticAnalyzer.CheckProgram(_programText1);
                _initializedVariables = syntacticAnalyzer._initializedVariables;
                operationsAssignments = syntacticAnalyzer.operationsAssignments;
                expression = syntacticAnalyzer.expression;
                richTextBox3.Text += "Синтаксический анализ завершен! \n";

            }
        }

        private Dictionary<string, string> _initializedVariables = new Dictionary<string, string>();
        private Dictionary<string, string> _numberWithType = new Dictionary<string, string>();
        private List<string> operationsAssignments = new List<string>();
        private List<string> expression = new List<string>();

        private void семантическийАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox3.Text += "Запущен семантический анализатор! \n";
                string _programmText1 = Parser.StartParser(_programmText);

                SemanticAnalyz semanticAnalyzer = new SemanticAnalyz(_numberWithType,
                    _initializedVariables,
                    operationsAssignments,
                    expression,
                    this);
                semanticAnalyzer.StartSemanticAnalyzer();
                richTextBox3.Text += "Семантический анализ завершен! \n";
            }
        }

        private void выходToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void тестовыеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void результатыАнализаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                try
                {
                    CreateObjectFiles(richTextBox1.Text);
                    richTextBox3.Text += "Объектные файлы успешно созданы.\n";
                }
                catch (Exception ex)
                {
                    richTextBox3.Text += $"Ошибка при создании объектных файлов: {ex.Message}\n";
                }
            }
            else
            {
                richTextBox3.Text += "Текст программы не задан.\n";
            }
        }

        private void CreateObjectFiles(string sourceCode)
        {
            string tempCFile = Path.GetTempFileName();
            File.WriteAllText(tempCFile, sourceCode);

            // Создание объектного файла на машинном коде (GCC)
            string machineObjFile = Path.ChangeExtension(tempCFile, ".o");
            string gccCommand = $"gcc -c -o {machineObjFile} {tempCFile}";
            RunProcess(gccCommand);

            // Переименование машинного объектного файла
            File.Move(machineObjFile, "machine_code.obj");

            // Создание ассемблерного кода из C кода
            string asmFile = Path.ChangeExtension(tempCFile, ".s");
            string gccToAsmCommand = $"gcc -S -o {asmFile} {tempCFile}";
            RunProcess(gccToAsmCommand);

            // Создание объектного файла из ассемблерного кода (NASM)
            string assemblyObjFile = Path.ChangeExtension(asmFile, ".o");
            string nasmCommand = $"nasm -f win64 -o {assemblyObjFile} {asmFile}";
            RunProcess(nasmCommand);

            // Переименование ассемблерного объектного файла
            File.Move(assemblyObjFile, "assembly_code.obj");
        }

        private void RunProcess(string command)
        {
            var processStartInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processStartInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    throw new Exception($"Команда '{command}' завершилась с ошибкой: {output}");
                }
            }
        }
    }
}