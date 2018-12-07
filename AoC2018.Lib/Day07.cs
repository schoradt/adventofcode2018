using System;
using System.Collections.Generic;

namespace AoC2018.Lib
{
    public class Day07
    {
        public string Part1(string[] lines)
        {
            SortedSet<TreeNode> nodes = this.ParseTree(lines);

            HashSet<TreeNode> ready = new HashSet<TreeNode>();

            string res = "";

            while (nodes.Count > 0)
            {
                // process
                foreach (TreeNode node in nodes)
                {
                    //Console.WriteLine("check " + node.Name);

                    if (node.IsReady(ready))
                    {
                        ready.Add(node);

                        res += node.Name;

                        nodes.Remove(node);

                        nodes.UnionWith(node.Children);

                        break;
                    }
                }
            }

            return res;
        }

        public int Part2(string[] lines, int workers, int baseTime)
        {
            SortedSet<TreeNode> nodes = this.ParseTree(lines);

            HashSet<TreeNode> done = new HashSet<TreeNode>();

            Dictionary<int, TreeNode> work = new Dictionary<int, TreeNode>();

            for (int i = 0; i < workers; i++)
            {
                work[i] = null;
            }

            string res = "";
            int second = 0;

            while (true)
            {
                for (int i = 0; i < workers; i++)
                {
                    if (work[i] != null)
                    {
                        if (work[i].Finished <= second)
                        {
                            done.Add(work[i]);

                            res += work[i].Name;

                            nodes.UnionWith(work[i].Children);

                            work[i] = null;
                        }
                    }
                }

                while (nodes.Count > 0 && OpenWorkers(work))
                {
                    bool b = false;

                    // process
                    foreach (TreeNode node in nodes)
                    {
                        if (node.IsReady(done))
                        {
                            for (int i = 0; i < workers; i++)
                            {
                                if (work[i] == null)
                                {
                                    b = true;

                                    work[i] = node;
                                    node.Finished = (second + baseTime + ((int)node.Name[0]) - 64);

                                    nodes.Remove(node);

                                    break;
                                }
                            }

                            break;
                        }
                    }

                    if (!b) break;
                }

                if (nodes.Count == 0 && NoWorkers(work))
                {
                    break;
                }

                second++;
            }

            return second;
        }

        private bool OpenWorkers(Dictionary<int, TreeNode> work)
        {
            foreach(var item in work)
            {
                if (item.Value == null)
                {
                    return true;
                }
            }

            return false;
        }

        private bool NoWorkers(Dictionary<int, TreeNode> work)
        {
            foreach (var item in work)
            {
                if (item.Value != null)
                {
                    return false;
                }
            }

            return true;
        }


        private SortedSet<TreeNode> ParseTree(string[] lines)
        {
            Dictionary<string, TreeNode> nodes = new Dictionary<string, TreeNode>();

            SortedSet<TreeNode> startNodes = new SortedSet<TreeNode>(new TreeNode.TreeNodeCompare());

            foreach (string line in lines)
            {
                string nodeName1 = line.Substring(5, 1);
                string nodeName2 = line.Substring(36, 1);

                TreeNode node1;

                if (nodes.ContainsKey(nodeName1))
                {
                    node1 = nodes[nodeName1];
                }
                else
                {
                    node1 = new TreeNode(nodeName1);

                    nodes.Add(nodeName1, node1);

                    startNodes.Add(node1);
                }

                TreeNode node2;

                if (nodes.ContainsKey(nodeName2))
                {
                    node2 = nodes[nodeName2];
                }
                else
                {
                    node2 = new TreeNode(nodeName2);

                    nodes.Add(nodeName2, node2);
                }

                node1.AddChild(node2);

                startNodes.Remove(node2);
            }

            return startNodes;
        }


        public class TreeNode
        {
            private SortedSet<TreeNode> children = new SortedSet<TreeNode>(new TreeNodeCompare());
            private SortedSet<TreeNode> prerequements = new SortedSet<TreeNode>(new TreeNodeCompare());
            private string name;
            private int finished;

            public TreeNode(string name)
            {
                this.name = name;
            }

            public string Name { get => this.name; private set => this.name = value; }
            public int Finished { get => this.finished; set => this.finished = value; }

            public SortedSet<TreeNode> Children { get => this.children; }

            public void AddChild(TreeNode node)
            {
                this.children.Add(node);

                node.AddPrereq(this);
            }

            public void AddPrereq(TreeNode node)
            {
                this.prerequements.Add(node);
            }

            public bool IsReady(HashSet<TreeNode> ready)
            {
                bool res = true;

                foreach (TreeNode req in this.prerequements)
                {
                    res &= ready.Contains(req);
                }

                return res;
            }

            public string Traverse()
            {
                string res = this.name;

                foreach(TreeNode child in this.children)
                {
                    res += child.Traverse();
                }

                return res;
            }

            public class TreeNodeCompare : IComparer<TreeNode>
            {
                public int Compare(TreeNode x, TreeNode y)
                {
                    return string.Compare(x.Name, y.Name);
                }
            }
        }
    }
}
