using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormalMethods
{

public partial class Form1 : Form
{
	private TabControl tabControl1;
	private TabPage tabPage1;
	private Button button1;
	private Button button2;
	private TextBox textBox3;
	private TextBox textBox2;
	private TextBox textBox1;
	private Label label3;
	private Label label2;
	private Label label1;
	private TabPage tabPage2;
	
	public Form1()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
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
		this.tabControl1.Size = new System.Drawing.Size(870, 315);
		this.tabControl1.TabIndex = 0;
		// 
		// tabPage1
		// 
		this.tabPage1.Controls.Add(this.label3);
		this.tabPage1.Controls.Add(this.label2);
		this.tabPage1.Controls.Add(this.label1);
		this.tabPage1.Controls.Add(this.textBox3);
		this.tabPage1.Controls.Add(this.textBox2);
		this.tabPage1.Controls.Add(this.textBox1);
		this.tabPage1.Controls.Add(this.button1);
		this.tabPage1.Location = new System.Drawing.Point(4, 22);
		this.tabPage1.Name = "RegEx_Input";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(862, 289);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "RegEx Input";
		this.tabPage1.UseVisualStyleBackColor = true;
		// 
		// tabPage2
		// 
		this.tabPage2.Controls.Add(this.button2);
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Name = "FormalGrammar_Input";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(862, 594);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Formal Grammar Input";
		this.tabPage2.UseVisualStyleBackColor = true;
		// 
		// button outputRegEx
		// 
		this.button1.Location = new System.Drawing.Point(503, 134);
		this.button1.Name = "outputRegEx";
		this.button1.Size = new System.Drawing.Size(200, 60);
		this.button1.TabIndex = 0;
		this.button1.Text = "Create Output";
		this.button1.UseVisualStyleBackColor = true;
		// 
		// button outputFormalGrammar
		// 
		this.button2.Location = new System.Drawing.Point(500, 200);
		this.button2.Name = "outputFormalGrammar";
		this.button2.Size = new System.Drawing.Size(200, 60);
		this.button2.TabIndex = 0;
		this.button2.Text = "Create Output";
		this.button2.UseVisualStyleBackColor = true;
		// 
		// textBox1
		// 
		this.textBox1.Location = new System.Drawing.Point(41, 55);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(236, 20);
		this.textBox1.TabIndex = 1;
		// 
		// textBox2
		// 
		this.textBox2.Location = new System.Drawing.Point(500, 55);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(200, 20);
		this.textBox2.TabIndex = 2;
		// 
		// textBox3
		// 
		this.textBox3.Location = new System.Drawing.Point(44, 174);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(236, 20);
		this.textBox3.TabIndex = 3;
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(38, 39);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(39, 13);
		this.label1.TabIndex = 4;
		this.label1.Text = "RegEx";
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(500, 39);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(48, 13);
		this.label2.TabIndex = 5;
		this.label2.Text = "alphabet";
		// 
		// label3
		// 
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(41, 158);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(58, 13);
		this.label3.TabIndex = 6;
		this.label3.Text = "input string";
		// 
		// Form1
		// 
		this.ClientSize = new System.Drawing.Size(894, 644);
		this.Controls.Add(this.tabControl1);
		this.Name = "Form1";
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		this.tabPage2.ResumeLayout(false);
		this.ResumeLayout(false);

	}
}
}
