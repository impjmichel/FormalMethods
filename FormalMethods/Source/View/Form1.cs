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
    private TabPage tabPage3;
    private TextBox textBox3;
    private Label label3;
    private TextBox textBox4;
    private Label label4;
    private Button button3;

    private TextBox textBox5;
    private Label label5;
    private TabPage tabPage4;
    private Button button4;
    private DataGridView dataGridView1;
	private TabPage tabPage2;
	private Button startWithButton;
	private Label label6;
	private TextBox startWithINPUT;
	private Button endsWithButton;
	private Button containsButton;
	private Label label8;
	private Label label7;
	private TextBox endsWithINPUT;
	private TextBox containsINPUT;
	private Label checkLabel;
	private Label label9;
	private TextBox inputCheckINPUT;
	private Button checkButton;

    private int option = -1;
	
	public Form1()
	{
        this.Text = "Formal Methods";
		InitializeComponent();
	}

	private void InitializeComponent()
	{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.checkLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.inputCheckINPUT = new System.Windows.Forms.TextBox();
			this.endsWithButton = new System.Windows.Forms.Button();
			this.containsButton = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.endsWithINPUT = new System.Windows.Forms.TextBox();
			this.containsINPUT = new System.Windows.Forms.TextBox();
			this.startWithButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.startWithINPUT = new System.Windows.Forms.TextBox();
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
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.checkButton = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
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
			this.tabPage1.Controls.Add(this.checkButton);
			this.tabPage1.Controls.Add(this.checkLabel);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.inputCheckINPUT);
			this.tabPage1.Controls.Add(this.endsWithButton);
			this.tabPage1.Controls.Add(this.containsButton);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.endsWithINPUT);
			this.tabPage1.Controls.Add(this.containsINPUT);
			this.tabPage1.Controls.Add(this.startWithButton);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.startWithINPUT);
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
			// checkLabel
			// 
			this.checkLabel.AutoSize = true;
			this.checkLabel.Location = new System.Drawing.Point(644, 83);
			this.checkLabel.Name = "checkLabel";
			this.checkLabel.Size = new System.Drawing.Size(10, 13);
			this.checkLabel.TabIndex = 18;
			this.checkLabel.Text = " ";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(644, 18);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(128, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "check the following input:";
			// 
			// inputCheckINPUT
			// 
			this.inputCheckINPUT.Location = new System.Drawing.Point(644, 37);
			this.inputCheckINPUT.Name = "inputCheckINPUT";
			this.inputCheckINPUT.Size = new System.Drawing.Size(142, 20);
			this.inputCheckINPUT.TabIndex = 16;
			// 
			// endsWithButton
			// 
			this.endsWithButton.Location = new System.Drawing.Point(386, 298);
			this.endsWithButton.Name = "endsWithButton";
			this.endsWithButton.Size = new System.Drawing.Size(105, 23);
			this.endsWithButton.TabIndex = 15;
			this.endsWithButton.Text = "create";
			this.endsWithButton.UseVisualStyleBackColor = true;
			this.endsWithButton.Click += new System.EventHandler(this.endsWithButton_Click);
			// 
			// containsButton
			// 
			this.containsButton.Location = new System.Drawing.Point(386, 251);
			this.containsButton.Name = "containsButton";
			this.containsButton.Size = new System.Drawing.Size(105, 23);
			this.containsButton.TabIndex = 14;
			this.containsButton.Text = "create";
			this.containsButton.UseVisualStyleBackColor = true;
			this.containsButton.Click += new System.EventHandler(this.containsButton_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 278);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(109, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "\"eindigt met\" automat";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 235);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "\"bevat\" automat";
			// 
			// endsWithINPUT
			// 
			this.endsWithINPUT.Location = new System.Drawing.Point(10, 298);
			this.endsWithINPUT.Name = "endsWithINPUT";
			this.endsWithINPUT.Size = new System.Drawing.Size(356, 20);
			this.endsWithINPUT.TabIndex = 11;
			// 
			// containsINPUT
			// 
			this.containsINPUT.Location = new System.Drawing.Point(10, 251);
			this.containsINPUT.Name = "containsINPUT";
			this.containsINPUT.Size = new System.Drawing.Size(356, 20);
			this.containsINPUT.TabIndex = 10;
			// 
			// startWithButton
			// 
			this.startWithButton.Location = new System.Drawing.Point(386, 205);
			this.startWithButton.Name = "startWithButton";
			this.startWithButton.Size = new System.Drawing.Size(105, 20);
			this.startWithButton.TabIndex = 9;
			this.startWithButton.Text = "create";
			this.startWithButton.UseVisualStyleBackColor = true;
			this.startWithButton.Click += new System.EventHandler(this.startWithButton_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 187);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "\"begint met\" automat";
			// 
			// startWithINPUT
			// 
			this.startWithINPUT.Location = new System.Drawing.Point(6, 206);
			this.startWithINPUT.Name = "startWithINPUT";
			this.startWithINPUT.Size = new System.Drawing.Size(363, 20);
			this.startWithINPUT.TabIndex = 7;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(6, 19);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(360, 20);
			this.textBox3.TabIndex = 6;
			this.textBox3.Text = "a,b";
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
			this.textBox1.Text = "(a|b)";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(386, 37);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 60);
			this.button1.TabIndex = 0;
			this.button1.Text = "Create output";
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
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.textBox5);
			this.tabPage3.Controls.Add(this.button3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(862, 335);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "file input";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(191, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "File contains";
			// 
			// textBox5
			// 
			this.textBox5.Enabled = false;
			this.textBox5.Location = new System.Drawing.Point(194, 37);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(296, 245);
			this.textBox5.TabIndex = 1;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(20, 21);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(136, 53);
			this.button3.TabIndex = 0;
			this.button3.Text = "Open file";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.button4);
			this.tabPage4.Controls.Add(this.dataGridView1);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(862, 335);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "tabPage4";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(0, 0);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(6, 15);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(294, 317);
			this.dataGridView1.TabIndex = 0;
			// 
			// checkButton
			// 
			this.checkButton.Location = new System.Drawing.Point(793, 37);
			this.checkButton.Name = "checkButton";
			this.checkButton.Size = new System.Drawing.Size(50, 23);
			this.checkButton.TabIndex = 19;
			this.checkButton.Text = "check!";
			this.checkButton.UseVisualStyleBackColor = true;
			this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
			// 
			// Form1
			// 
			this.BackColor = System.Drawing.Color.Black;
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
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

	}

	private void button1_Click(object sender, EventArgs e)
	{
        regExp(textBox3.Text, textBox1.Text);
	}

    private void regExp(string abInput, string boxInput,bool toDFA = false)
    {
        string alphabetInput = abInput;
        if (checkAlphabet(alphabetInput))
        {
            Alphabet alpha = new Alphabet(alphabetInput);
            string input = boxInput;
            if (checkString(input))
            {
                RegExp reg = new RegExp(input, alpha);

				NDFA tempNDFA = reg.toNDFA();
				DFA tempDFA = tempNDFA.toDFA();

				string ndfa,dfa;
                ndfa = tempNDFA.toGraphVizString();
                dfa = tempDFA.toGraphVizString();

                popup dfaPu = new popup(input, "DFA");
                dfaPu.Graphiz(dfa);
                dfaPu.Show();

                popup ndfaPu = new popup(input, "NDFA");
                ndfaPu.Graphiz(ndfa);
                ndfaPu.Show();
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
        regGram(textBox4.Text, textBox2.Text);
    }

    public void regGram(string abInput, string boxInput)
    {
        string alphabetInput = abInput;
        if (checkAlphabet(alphabetInput))
        {
            Alphabet alpha = new Alphabet(alphabetInput);
            RegGram reg = new RegGram(alpha, boxInput);

            NDFA tempNDFA = reg.toNDFA();
            DFA tempDFA = tempNDFA.toDFA();

            string ndfa, dfa;
            ndfa = tempNDFA.toGraphVizString();
            dfa = tempDFA.toGraphVizString();

            popup dfaPu = new popup(boxInput, "DFA");
            dfaPu.Graphiz(dfa);
            dfaPu.Show();

            popup ndfaPu = new popup(boxInput, "NDFA");
            ndfaPu.Graphiz(ndfa);
            ndfaPu.Show();
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
            MessageBox.Show("string is empty");
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

    private void button3_Click(object sender, EventArgs e)
    {
        FileReader fr = new FileReader();
        string input = fr.getInput();
        string alphabet = fr.getAlphabet();

        if (input != null && alphabet != null)
        {
            this.option = fr.getOption(input);

            switch (this.option)
            {
                case 0: regGram(alphabet, input); break;
                case 1: regExp(alphabet, input); break;
            }

            Console.WriteLine(fr.getRawInput());
            this.textBox5.Text = fr.getRawInput();
        }
    }

	private void startWithButton_Click(object sender, EventArgs e)
	{
		staticAutomats(textBox3.Text, startWithINPUT.Text, 0);
	}

	private void staticAutomats(string abInput, string boxInput, int automat)
	{
		string alphabetInput = abInput;
		if (checkAlphabet(alphabetInput))
		{
			NDFA tempNDFA = null;
			DFA tempDFA = null;
			Alphabet alpha = new Alphabet(alphabetInput);
			string text = "";
			switch(automat)
			{
				case 0: // starts with
					tempNDFA = Util.ndfaStartsWith(boxInput, alpha);
					tempDFA = tempNDFA.toDFA();
					text = "starts with:  ";
					break;
				case 1: // contains
					tempNDFA = Util.ndfaContains(boxInput, alpha);
					tempDFA = tempNDFA.toDFA();
					text = "contains:  ";
					break;
				case 2: // ends with
					tempNDFA = Util.ndfaEndsWith(boxInput, alpha);
					tempDFA = tempNDFA.toDFA();
					text = "ends with:  ";
					break;
				default:
					break;
			}
			if (tempNDFA != null)
			{
				popup ndfaPu = new popup(text + boxInput, "NDFA");
				ndfaPu.Graphiz(tempNDFA.toGraphVizString());
				ndfaPu.Show();
			}
			if (tempDFA != null)
			{
				popup dfaPu = new popup(text + boxInput, "DFA");
				dfaPu.Graphiz(tempDFA.toGraphVizString());
				dfaPu.Show();
			}
		}
		else
		{
			MessageBox.Show("Alphabet not accepted, please try again");
		}
	}

	private void containsButton_Click(object sender, EventArgs e)
	{
		staticAutomats(textBox3.Text, containsINPUT.Text, 1);
	}

	private void endsWithButton_Click(object sender, EventArgs e)
	{
		staticAutomats(textBox3.Text, endsWithINPUT.Text, 2);
	}

	private void checkButton_Click(object sender, EventArgs e)
	{
		string alphabet = textBox3.Text;
		string regex = textBox1.Text;
		string input = inputCheckINPUT.Text;
		if (checkAlphabet(alphabet))
		{
			Alphabet alpha = new Alphabet(alphabet);
			if (checkString(regex))
			{
				RegExp reg = new RegExp(regex, alpha);
				NDFA tempNDFA = reg.toNDFA();
				if (tempNDFA.AcceptInput(input))
				{
					checkLabel.Text = "INPUT ACCEPTED!";
				}
				else
				{
					checkLabel.Text = "INPUT NOT ACCEPTED!";
				}
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
}
}
