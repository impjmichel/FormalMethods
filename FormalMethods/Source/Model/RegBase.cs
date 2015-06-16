using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
class RegBase
{
	protected const string cInitRegGrammar = "digraph usage{graph [rankdir=LR,fontsize=8]; node [shape=circle, color=black]";
	protected const string cEndingCircle = "[shape=circle,peripheries=2]";
	protected const string cStartingPoint = "x[shape=none];x->";
	protected const string cTo = "->";
	protected const string cA = "[label = a]";
	protected const string cB = "[label = b]";
	protected const string cEp = "[label = y]";
	protected const string cEndRegGrammar = "}";
	protected const string stop = ";";
}
}
