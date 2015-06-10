using System.Collections;
namespace Models
{
    class DFA
    {
        string input;
        ArrayList nodes;

        public void setInput(string newInput)
        {
            input = newInput;
        }

        public string getInput()
        {
            return input;
        }

        public void setNodes(ArrayList newNodes)
        {
            nodes = newNodes;
        }

        public void addNode(Node node)
        {
            nodes.Add(node);
        }

        public ArrayList getNodes()
        {
            return nodes;
        }

        public DFA minimalize(DFA dfa)
        {
            return dfa;
        }

        public NDFA reverse(DFA dfa)
        {
            NDFA ndfa = new NDFA();
            return ndfa;
        }
    }
}
