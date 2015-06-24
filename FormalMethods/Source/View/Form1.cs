﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Models;

namespace FormalMethods
{

public partial class Form1 : Form
{
	private TabControl tabControl1;
	private TabPage tabPage1;
	private Button button1;
	private Button button2;
	private TextBox textBox1;
	private Label label1;
	private Label label2;
	private TextBox textBox2;
    private TabPage tabPage3;
    private TextBox textBox3;
    private Label label3;
    private TextBox textBox4;
    private Label label4;
    private ComboBox comboBox1;
    private Label label6;
    private TextBox textBox5;
    private Label label5;
    private Button button3;
    private DataGridView dataGridView1;
	private TabPage tabPage2;
	
	public Form1()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(862, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RegEx Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(360, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alphabet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "RegEx";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create NDFA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(862, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Regular Grammar Input";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(10, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(360, 20);
            this.textBox4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Alphabet";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 58);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(360, 161);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Regular Grammar";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(505, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 60);
            this.button2.TabIndex = 0;
            this.button2.Text = "Create Output";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.textBox5);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(862, 335);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "NDFA input";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(505, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 60);
            this.button3.TabIndex = 11;
            this.button3.Text = "Create Output";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            1,
            2,
            3});
            this.comboBox1.Location = new System.Drawing.Point(392, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number of states";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(9, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(360, 20);
            this.textBox5.TabIndex = 8;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Alphabet";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(360, 290);
            this.dataGridView1.TabIndex = 12;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(894, 385);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

	}

	private void button1_Click(object sender, EventArgs e)
	{
        string alphabetInput = textBox3.Text;
        if (checkAlphabet(alphabetInput))
        {
            Alphabet alpha = new Alphabet(alphabetInput);
            string input = textBox1.Text;
            if (checkString(input))
            {
                RegExp reg = new RegExp(input,alpha);
                string test = reg.CreateGraphizString(input);
                popup pu = new popup();
                pu.Graphiz(test);
                pu.Show();
            }
            else
            {
                MessageBox.Show("RegEx not accepted, please try again");
            }
        }
        else
        {
            MessageBox.Show("Alphabet not accepted, please try again");
        }
	}

    private void button2_Click(object sender, EventArgs e)
    {
        string alphabetInput = textBox3.Text;
        if (checkAlphabet(alphabetInput))
        {
            Alphabet alpha = new Alphabet(alphabetInput);
            RegGram reg = new RegGram(alpha);
            string test = reg.CreateGraphizString(textBox2.Text);
            popup pu = new popup();
            pu.Graphiz(test);
            pu.Show();
        }
        else
        {
            MessageBox.Show("Alphabet not accepted, please try again");
        }
    }

	private bool checkString(string input)
	{
		input.Replace(" ", string.Empty);
		if (String.IsNullOrEmpty(input))
		{
			return false;
		}
		if (input.Contains('|'))
		{
			string[] pieces = input.Split('|');
			for (int i = 0; i < pieces.Length -1; ++i)
			{
				string prePiece = "";
				string postPiece = "";
				for (int ii = 0; ii <= i; ++ii )
				{
					prePiece += pieces[ii];
				}
				for (int ii = i + 1; ii < pieces.Length; ++ii )
				{
					postPiece += pieces[ii];
				}
				int countOpen = prePiece.Split('(').Length - 1;
				countOpen -= prePiece.Split(')').Length - 1;
				if (countOpen <= 0)
					return false;
				int countClose = postPiece.Split(')').Length - 1;
				countClose -= postPiece.Split('(').Length - 1;
				if (countClose <= 0)
					return false;
			}
		}
		return true;
	}

    private bool checkAlphabet(string alphabet)
    {
        var empty = string.IsNullOrWhiteSpace(alphabet);

        if (!empty && alphabet.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void createTable(SortedSet<char> columns, int rows)
    {
        this.dataGridView1.ColumnCount = columns.Count;
        for(int i = 0; i < columns.Count; i++)
        {
            this.dataGridView1.Columns[i].Name = columns.ElementAt(i).ToString();
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        string alphabetInput = textBox3.Text;
        if (checkAlphabet(alphabetInput))
        {

        }
        else
        {
            MessageBox.Show("Alphabet not accepted, please try again");
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string alphabetInput = textBox5.Text;
        if (checkAlphabet(alphabetInput))
        {
            Alphabet alpha = new Alphabet(alphabetInput);
            SortedSet<char> columns = alpha.characters;

            int rows = 3;//(int)this.comboBox1.SelectedValue;

            
            createTable(columns, rows);
            this.Refresh();
        }
        else
        {
            MessageBox.Show("Alphabet not accepted, please try again");
        }
        
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
        if (checkAlphabet(textBox5.Text)) this.comboBox1.Show();
        else this.comboBox1.Hide();
    }

    
	
}
}
