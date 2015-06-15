using System.Collections;

namespace Models
{
    class NDFA
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

        public NDFA reverse(DFA dfa)
        {
            NDFA ndfa = new NDFA();
            return ndfa;
        }
    }
}
