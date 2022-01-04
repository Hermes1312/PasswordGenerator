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
        private List<string> mResult = new List<string>();

        private List<string> mStringList1 = new List<string>();
        private List<string> mStringList2 = new List<string>();
        private List<string> mDigitsList = new List<string>();

        private List<int> mPassDigits = new List<int>();

        private bool mDigitsFileGenerated = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (mDigitsFileGenerated)
            {
                if(mDigitsList.Count == 0)
                {
                    AppendDigitsList(4);
                }

                progressBarResult.Value = 0;

                mStringList1.AddRange(passwords1.Text.Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Replace("\t", "")));
                mStringList2.AddRange(passwords2.Text.Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Replace("\t", "")));

                progressBarResult.Maximum = mStringList1.Count;

                await ProcessAsync();
            }
            else
                MessageBox.Show("You need to generate digits file!");
        }

        private async Task ProcessAsync()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                    for (int i = 0; i < mStringList1.Count; i++)
                    {
                        for (int j = 0; j < mStringList2.Count; j++)
                        {
                            using (StreamWriter streamWriter = new StreamWriter(fileDialog.FileName, true, Encoding.UTF8))
                            {
                                for (int k = 0; k < mDigitsList.Count; k++)
                                {

                                    await streamWriter.WriteLineAsync($"{mStringList1[i]}{mStringList2[j]}@wp.pl:{mStringList1[i]}{mStringList2[j]}{mDigitsList[k]}");
                                    await streamWriter.WriteLineAsync($"{mStringList2[j]}{mStringList1[i]}@wp.pl:{mStringList2[j]}{mStringList1[i]}{mDigitsList[k]}");
                                    await streamWriter.WriteLineAsync($"{mStringList1[i]}.{mStringList2[j]}@wp.pl:{mStringList1[i]}{mStringList2[j]}{mDigitsList[k]}");
                                    await streamWriter.WriteLineAsync($"{mStringList2[j]}.{mStringList1[i]}@wp.pl:{mStringList2[j]}{mStringList1[i]}{mDigitsList[k]}");

                                }
                            }
                        }

                        progressBarResult.Invoke((MethodInvoker)delegate
                        {
                            progressBarResult.Value++;
                        });
                    }
                
            }

        }

        private void AppendDigitsList(int digit)
            => mDigitsList.AddRange(File.ReadAllLines(DigitFilePath(digit)));

        private void Form1_Load(object sender, EventArgs e)
            => CheckGeneratedDigitsFileExistence();

        private string DigitFilePath(int digit)
            => $"{digit}-digits-gen.txt";

        private void CheckGeneratedDigitsFileExistence()
        {
            int b = (int)numericUpDown1.Value;

            mDigitsFileGenerated = File.Exists(DigitFilePath(b));

            if (mDigitsFileGenerated)
                label2.Text = "STATUS: Generated";
            else
                label2.Text = "STATUS: Not generated";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            => CheckGeneratedDigitsFileExistence();

        private void button2_Click(object sender, EventArgs e)
        {
            if (!mDigitsFileGenerated)
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

                for (int i = 0; i < 10000; i++)
                {

                    if(i < 10)
                    {
                        mDigitsList.AddRange(new[]
                        {
                            i.ToString("0000"),
                            i.ToString("000"),
                            i.ToString("00"),
                            i.ToString()
                        });
                    }

                    else if(i < 100 && i >= 10)
                    {
                        mDigitsList.AddRange(new[]
                        {
                            i.ToString("0000"),
                            i.ToString("000"),
                            i.ToString()
                        });
                    }
                    
                    else if(i < 1000 && i >= 100)
                    {
                        mDigitsList.AddRange(new[]
                        {
                            i.ToString("0000"),
                            i.ToString()
                        });
                    }                    
                    
                    else if(i < 10000 && i >= 1000)
                    {
                        mDigitsList.Add(i.ToString());
                    }


                    progressBarDigit.Value += 1;
                      
                }


                File.WriteAllLines(DigitFilePath(4), mDigitsList);
                AppendDigitsList(4);
                CheckGeneratedDigitsFileExistence();
            }
            else
                MessageBox.Show("File already generated!");
        }
    }
}