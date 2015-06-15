using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphVizWrapper;
using GraphVizWrapper.Queries;
using GraphVizWrapper.Commands;

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
	private Panel panel1;
	private Label label5;
	private Label label4;
	private PictureBox NDFABox;
	private PictureBox DFABox;
	private VScrollBar vScrollBar1;
	private TabPage tabPage2;
	
	public Form1()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.DFABox = new System.Windows.Forms.PictureBox();
			this.NDFABox = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DFABox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NDFABox)).BeginInit();
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
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.textBox2);
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(41, 158);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "input string";
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(38, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "RegEx";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(44, 174);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(236, 20);
			this.textBox3.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(500, 55);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(200, 20);
			this.textBox2.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(41, 55);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(236, 20);
			this.textBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(503, 134);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 60);
			this.button1.TabIndex = 0;
			this.button1.Text = "Create Output";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(862, 225);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Formal Grammar Input";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(502, 131);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(200, 60);
			this.button2.TabIndex = 0;
			this.button2.Text = "Create Output";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.NDFABox);
			this.panel1.Controls.Add(this.DFABox);
			this.panel1.Controls.Add(this.vScrollBar1);
			this.panel1.Location = new System.Drawing.Point(12, 270);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(866, 362);
			this.panel1.TabIndex = 1;
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(846, 0);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(20, 362);
			this.vScrollBar1.TabIndex = 0;
			// 
			// DFABox
			// 
			this.DFABox.Location = new System.Drawing.Point(4, 33);
			this.DFABox.Name = "DFABox";
			this.DFABox.Size = new System.Drawing.Size(383, 326);
			this.DFABox.TabIndex = 1;
			this.DFABox.TabStop = false;
			// 
			// NDFABox
			// 
			this.NDFABox.Location = new System.Drawing.Point(460, 33);
			this.NDFABox.Name = "NDFABox";
			this.NDFABox.Size = new System.Drawing.Size(383, 326);
			this.NDFABox.TabIndex = 2;
			this.NDFABox.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "DFA";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(460, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "NDFA";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(894, 644);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DFABox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NDFABox)).EndInit();
			this.ResumeLayout(false);

	}

    public void Graphiz()
    {
        var getStartProcessQuery = new GetStartProcessQuery();
        var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
        var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

        // GraphGeneration can be injected via the IGraphGeneration interface

        var wrapper = new GraphGeneration(getStartProcessQuery,
                                          getProcessStartInfoQuery,
                                          registerLayoutPluginCommand);

        byte[] output = wrapper.GenerateGraph("digraph{a -> b [ label = a];b->a; b -> c; c -> a; a[shape=circle,peripheries=2]; x->a; x[shape=none];}", Enums.GraphReturnType.Png);
    }
}
}
