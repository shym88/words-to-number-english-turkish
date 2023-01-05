
namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.addition_btn = new System.Windows.Forms.Button();
            this.substraction_btn = new System.Windows.Forms.Button();
            this.multiplication_btn = new System.Windows.Forms.Button();
            this.division_btn = new System.Windows.Forms.Button();
            this.param_lbl_1 = new System.Windows.Forms.Label();
            this.param_txtbx_1 = new System.Windows.Forms.TextBox();
            this.param_lbl_2 = new System.Windows.Forms.Label();
            this.param_txtbx_2 = new System.Windows.Forms.TextBox();
            this.result_txtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_result_int = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // addition_btn
            // 
            resources.ApplyResources(this.addition_btn, "addition_btn");
            this.addition_btn.Name = "addition_btn";
            this.addition_btn.Tag = "1";
            this.addition_btn.UseVisualStyleBackColor = true;
            this.addition_btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // substraction_btn
            // 
            resources.ApplyResources(this.substraction_btn, "substraction_btn");
            this.substraction_btn.Name = "substraction_btn";
            this.substraction_btn.Tag = "2";
            this.substraction_btn.UseVisualStyleBackColor = true;
            this.substraction_btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // multiplication_btn
            // 
            resources.ApplyResources(this.multiplication_btn, "multiplication_btn");
            this.multiplication_btn.Name = "multiplication_btn";
            this.multiplication_btn.Tag = "3";
            this.multiplication_btn.UseVisualStyleBackColor = true;
            this.multiplication_btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // division_btn
            // 
            resources.ApplyResources(this.division_btn, "division_btn");
            this.division_btn.Name = "division_btn";
            this.division_btn.Tag = "4";
            this.division_btn.UseVisualStyleBackColor = true;
            this.division_btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // param_lbl_1
            // 
            resources.ApplyResources(this.param_lbl_1, "param_lbl_1");
            this.param_lbl_1.Name = "param_lbl_1";
            // 
            // param_txtbx_1
            // 
            resources.ApplyResources(this.param_txtbx_1, "param_txtbx_1");
            this.param_txtbx_1.Name = "param_txtbx_1";
            this.param_txtbx_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_KeyPress);
            // 
            // param_lbl_2
            // 
            resources.ApplyResources(this.param_lbl_2, "param_lbl_2");
            this.param_lbl_2.Name = "param_lbl_2";
            // 
            // param_txtbx_2
            // 
            resources.ApplyResources(this.param_txtbx_2, "param_txtbx_2");
            this.param_txtbx_2.Name = "param_txtbx_2";
            this.param_txtbx_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_KeyPress);
            // 
            // result_txtbx
            // 
            resources.ApplyResources(this.result_txtbx, "result_txtbx");
            this.result_txtbx.Name = "result_txtbx";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.param_txtbx_2);
            this.groupBox2.Controls.Add(this.addition_btn);
            this.groupBox2.Controls.Add(this.substraction_btn);
            this.groupBox2.Controls.Add(this.multiplication_btn);
            this.groupBox2.Controls.Add(this.division_btn);
            this.groupBox2.Controls.Add(this.param_lbl_2);
            this.groupBox2.Controls.Add(this.param_lbl_1);
            this.groupBox2.Controls.Add(this.param_txtbx_1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_result_int);
            this.groupBox3.Controls.Add(this.result_txtbx);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // lbl_result_int
            // 
            resources.ApplyResources(this.lbl_result_int, "lbl_result_int");
            this.lbl_result_int.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_result_int.Name = "lbl_result_int";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addition_btn;
        private System.Windows.Forms.Button substraction_btn;
        private System.Windows.Forms.Button multiplication_btn;
        private System.Windows.Forms.Button division_btn;
        private System.Windows.Forms.Label param_lbl_1;
        private System.Windows.Forms.TextBox param_txtbx_1;
        private System.Windows.Forms.Label param_lbl_2;
        private System.Windows.Forms.TextBox param_txtbx_2;
        private System.Windows.Forms.TextBox result_txtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_result_int;
    }
}

