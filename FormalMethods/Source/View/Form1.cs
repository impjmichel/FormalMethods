using System;
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
	private TabPage tabPage2;
	
	public Form1()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(870, 251);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(862, 225);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "RegEx Input";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "RegEx";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 19);
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
			this.tabPage2.Controls.Add(this.textBox2);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(862, 225);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Regular Grammar Input";
			this.tabPage2.UseVisualStyleBackColor = true;
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Regular Grammar";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(10, 24);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(360, 195);
			this.textBox2.TabIndex = 2;
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(894, 280);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

	}

	private void button1_Click(object sender, EventArgs e)
	{
		string input = textBox1.Text;
		if (checkString(input))
		{
			RegExp reg = new RegExp();
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

	private void button2_Click(object sender, EventArgs e)
	{
		RegGram reg = new RegGram();
		string test = reg.CreateGraphizString(textBox2.Text);
		popup pu = new popup();
		pu.Graphiz(test);
		pu.Show();
	}
}
}
