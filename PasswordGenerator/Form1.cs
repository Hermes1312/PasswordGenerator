using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        private readonly List<string> _stringList1 = new();
        private readonly List<string> _stringList2 = new();
        private readonly List<string> _digitsList = new();
        private bool _digitsFileGenerated = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_digitsFileGenerated)
            {
                if (_digitsList.Count == 0) AppendDigitsList(4);

                progressBarResult.Value = 0;

                _stringList1.AddRange(passwords1.Text.Split('\n').Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => x.Replace("\t", "")));
                _stringList2.AddRange(passwords2.Text.Split('\n').Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => x.Replace("\t", "")));

                progressBarResult.Maximum = _stringList1.Count;

                await ProcessAsync();
            }
            else
            {
                MessageBox.Show("You need to generate digits file!");
            }
        }

        private async Task ProcessAsync()
        {
            var fileDialog = new SaveFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
                foreach (var string1 in _stringList1)
                {
                    foreach (var string2 in _stringList2)
                    {
                        await using var streamWriter = new StreamWriter(fileDialog.FileName, true, Encoding.UTF8);

                        foreach (var digits in _digitsList)
                        {
                            await streamWriter.WriteLineAsync($"{string1}{string2}@wp.pl:{string1}{string2}{digits}");
                            await streamWriter.WriteLineAsync($"{string2}{string1}@wp.pl:{string2}{string1}{digits}");
                            await streamWriter.WriteLineAsync($"{string1}.{string2}@wp.pl:{string1}{string2}{digits}");
                            await streamWriter.WriteLineAsync($"{string2}.{string1}@wp.pl:{string2}{string1}{digits}");
                        }
                    }

                    progressBarResult.Invoke((MethodInvoker) delegate { progressBarResult.Value++; });
                }
        }

        private void AppendDigitsList(int digit)
        {
            _digitsList.AddRange(File.ReadAllLines(DigitFilePath(digit)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckGeneratedDigitsFileExistence();
        }

        private string DigitFilePath(int digit)
        {
            return $"{digit}-digits-gen.txt";
        }

        private void CheckGeneratedDigitsFileExistence()
        {
            var num = (int) numericUpDown1.Value;
            _digitsFileGenerated = File.Exists(DigitFilePath(num));

            label2.Text = _digitsFileGenerated ? "STATUS: Generated" : "STATUS: Not generated";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CheckGeneratedDigitsFileExistence();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!_digitsFileGenerated)
            {
                /*AppendDigitsList((int)numericUpDown1.Value);

                int digitsCount = (int)numericUpDown1.Value;

                Thread generateThread = new Thread(() => {
                    int max = digitsCount > 1 ? 10 ^ (digitsCount - 1) : 10;

                    for (int i = 0; i < (); i++)
                    {

                    }
                });*/

                progressBarDigit.Maximum = 10000;

                for (var i = 0; i < 10000; i++)
                {
                    switch (i)
                    {
                        case < 10:
                            _digitsList.AddRange(new[]
                            {
                                i.ToString("0000"),
                                i.ToString("000"),
                                i.ToString("00"),
                                i.ToString()
                            });
                            break;

                        case < 100 and >= 10:
                            _digitsList.AddRange(new[]
                            {
                                i.ToString("0000"),
                                i.ToString("000"),
                                i.ToString()
                            });
                            break;

                        case < 1000 and >= 100:
                            _digitsList.AddRange(new[]
                            {
                                i.ToString("0000"),
                                i.ToString()
                            });
                            break;

                        case < 10000 and >= 1000:
                            _digitsList.Add(i.ToString());
                            break;
                    }


                    progressBarDigit.Value += 1;
                }


                File.WriteAllLines(DigitFilePath(4), _digitsList);
                AppendDigitsList(4);
                CheckGeneratedDigitsFileExistence();
            }
            else
            {
                MessageBox.Show("File already generated!");
            }
        }
    }
}