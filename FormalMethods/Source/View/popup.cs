using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphVizWrapper;
using GraphVizWrapper.Queries;
using GraphVizWrapper.Commands;

namespace FormalMethods
{
	public partial class popup : Form
	{
        private string name;
        private string machine;
		
        public popup(string name, string machine)
		{
            this.machine = machine;
            this.name = name;
			InitializeComponent();
            this.label1.Text = name;
		}

		public void Graphiz(string input)
		{
			var getStartProcessQuery = new GetStartProcessQuery();
			var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
			var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

			// GraphGeneration can be injected via the IGraphGeneration interface
			var wrapper = new GraphGeneration(getStartProcessQuery,
											  getProcessStartInfoQuery,
											  registerLayoutPluginCommand);

			byte[] output = wrapper.GenerateGraph(input, Enums.GraphReturnType.Png);
			MemoryStream ms = new MemoryStream(output);
			pictureBox1.Image = Image.FromStream(ms);
        }
	}
}
