using Calculator.Implementation;
using Calculator.Interface;
using Calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bw;

        public Form1()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.addition_btn.Enabled = true;
                this.substraction_btn.Enabled = true;
                this.multiplication_btn.Enabled = true;
                this.division_btn.Enabled = true;

                lbl_result_int.Text = e.Result.ToString();
                result_txtbx.Text = setResult(long.Parse(e.Result.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
                
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Dictionary<string, string> arguments = e.Argument as Dictionary<string, string>;
                if (arguments.Count > 0)
                    e.Result = Calculate(arguments["btnName"], arguments["p1"], arguments["p2"]).ToString();
                else
                    throw new ApplicationException("err-00");
            }
            catch (Exception)
            {
                throw;
            }
               
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (!this.bw.IsBusy)
            {
                Dictionary<string, string> arguments = new Dictionary<string, string>();

                if (string.IsNullOrEmpty(param_txtbx_1.Text) || string.IsNullOrEmpty(param_txtbx_2.Text))
                    throw new ApplicationException("err-01");
                
                arguments.Add("btnName", (sender as Button).Name);
                arguments.Add("p1", param_txtbx_1.Text);
                arguments.Add("p2", param_txtbx_2.Text);
                this.bw.RunWorkerAsync(arguments);

                this.addition_btn.Enabled = false;
                this.substraction_btn.Enabled = false;
                this.multiplication_btn.Enabled = false;
                this.division_btn.Enabled = false;
            }
        }
        private string Calculate(string btnName, string p1, string p2)
        {
            try
            {
                ICalculator iOperation;

                CalculatorParams parameters = getParameters(p1, p2);

                if (btnName == "addition_btn")
                    iOperation = new Addition();
                else if (btnName == "substraction_btn")
                    iOperation = new Subtraction();
                else if (btnName == "multiplication_btn")
                    iOperation = new Multiplication();
                else if (btnName == "division_btn")
                    iOperation = new Division();
                else
                    iOperation = null;

                return iOperation.Calculate(parameters).ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }
        private CalculatorParams getParameters(string p1, string p2)
        {
            if (Regex.IsMatch(p1, @"[\p{L} ]+$") && Regex.IsMatch(p2, @"[\p{L} ]+$"))
            { 
                IWordsToNumber wtn_EN = new WordsToNumberEN();
                IWordsToNumber wtn_TR = new WordsToNumberTR();
                string lang = Thread.CurrentThread.CurrentUICulture.Name;

                if (lang == "tr")
                    return new CalculatorParams(wtn_TR.ConvertWords(p1), wtn_TR.ConvertWords(p2));
                else if (lang == "en-001")
                    return new CalculatorParams (wtn_EN.ConvertWords(p1), wtn_EN.ConvertWords(p2));
                else
                    throw new ApplicationException("err-04");
            }
            else
            {
                throw new ApplicationException("err-02");
            }
        }

        private string setResult(long number)
        {
            try
            {
                INumberToWord ntw_EN = new NumberToWordEN();
                INumberToWord ntw_TR = new NumberToWordTR();

                string lang = GetLanguage();

                if (lang == "tr")
                    return ntw_TR.NumberToWords(number);
                else if (lang == "en-001")
                    return ntw_EN.NumberToWords(number);
                else
                    throw new ApplicationException("err-04");
            }
            catch (Exception)
            {

                throw;
            }
            
            
            
        }
        private string GetLanguage()
        {
            try
            {
               
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
                if (c.ToString().StartsWith("System.Windows.Forms.GroupBox"))
                {
                    foreach (Control child in c.Controls)
                    {
                        ComponentResourceManager resources_child = new ComponentResourceManager(typeof(Form1));
                        resources_child.ApplyResources(child, child.Name, new CultureInfo(lang));
                    }
                }
            }


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr");
                    ChangeLanguage("tr");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-001");
                    ChangeLanguage("en-001");
                    break;
            }
            
        }
        private void txtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

    }
}
