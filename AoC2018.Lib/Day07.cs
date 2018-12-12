// <copyright file="Day07.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System.Collections.Generic;

    /// <summary>
    /// Day07 solution class.
    /// </summary>
    public class Day07
    {
        /// <summary>
        /// Part one of the puzzle solution.
        /// </summary>
        /// <returns>Instruction order.</returns>
        /// <param name="lines">Puzzle input.</param>
        public string Part1(string[] lines)
        {
            SortedSet<TreeNode> nodes = this.ParseTree(lines);

            HashSet<TreeNode> ready = new HashSet<TreeNode>();

            string res = string.Empty;

            while (nodes.Count > 0)
            {
                // process
                foreach (TreeNode node in nodes)
                {
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

        /// <summary>
        /// Solution of part two of the puzzle.
        /// </summary>
        /// <returns>Time to process all the steps.</returns>
        /// <param name="lines">Puzzle input.</param>
        /// <param name="workers">Number of workers.</param>
        /// <param name="baseTime">Base time.</param>
        public int Part2(string[] lines, int workers, int baseTime)
        {
            SortedSet<TreeNode> nodes = this.ParseTree(lines);

            HashSet<TreeNode> done = new HashSet<TreeNode>();

            Dictionary<int, TreeNode> work = new Dictionary<int, TreeNode>();

            for (int i = 0; i < workers; i++)
            {
                work[i] = null;
            }

            string res = string.Empty;
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

                while (nodes.Count > 0 && this.OpenWorkers(work))
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
                                    node.Finished = second + baseTime + ((int)node.Name[0]) - 64;

                                    nodes.Remove(node);

                                    break;
                                }
                            }

                            break;
                        }
                    }

                    if (!b)
                    {
                        break;
                    }
                }

                if (nodes.Count == 0 && this.NoWorkers(work))
                {
                    break;
                }

                second++;
            }

            return second;
        }

        /// <summary>
        /// Are there opens the workers.
        /// </summary>
        /// <returns>true if there are workers without work.</returns>
        /// <param name="work">Worker map.</param>
        private bool OpenWorkers(Dictionary<int, TreeNode> work)
        {
            foreach (var item in work)
            {
                if (item.Value == null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Do have all workers are idle.
        /// </summary>
        /// <returns><c>true</c>, if all workers are idle, <c>false</c> otherwise.</returns>
        /// <param name="work">Worker map.</param>
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

        /// <summary>
        /// Parses the tree.
        /// </summary>
        /// <returns>The tree.</returns>
        /// <param name="lines">Line of tree description.</param>
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

        /// <summary>
        /// Tree node.
        /// </summary>
        public class TreeNode
        {
            /// <summary>
            /// The children.
            /// </summary>
            private SortedSet<TreeNode> children = new SortedSet<TreeNode>(new TreeNodeCompare());

            /// <summary>
            /// The prerequements.
            /// </summary>
            private SortedSet<TreeNode> prerequements = new SortedSet<TreeNode>(new TreeNodeCompare());

            /// <summary>
            /// The name.
            /// </summary>
            private string name;

            /// <summary>
            /// The finished.
            /// </summary>
            private int finished;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day07.TreeNode"/> class.
            /// </summary>
            /// <param name="name">Name of the node.</param>
            public TreeNode(string name)
            {
                this.name = name;
            }

            /// <summary>
            /// Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get => this.name; private set => this.name = value; }

            /// <summary>
            /// Gets or sets the finished.
            /// </summary>
            /// <value>The finished.</value>
            public int Finished { get => this.finished; set => this.finished = value; }

            /// <summary>
            /// Gets the children.
            /// </summary>
            /// <value>The children.</value>
            public SortedSet<TreeNode> Children { get => this.children; }

            /// <summary>
            /// Adds the child.
            /// </summary>
            /// <param name="node">New child node.</param>
            public void AddChild(TreeNode node)
            {
                this.children.Add(node);

                node.AddPrereq(this);
            }

            /// <summary>
            /// Adds the prereq.
            /// </summary>
            /// <param name="node">New pre node.</param>
            public void AddPrereq(TreeNode node)
            {
                this.prerequements.Add(node);
            }

            /// <summary>
            /// Check if node is ready.
            /// </summary>
            /// <returns><c>true</c>, if ready was ised, <c>false</c> otherwise.</returns>
            /// <param name="ready">Is ready.</param>
            public bool IsReady(HashSet<TreeNode> ready)
            {
                bool res = true;

                foreach (TreeNode req in this.prerequements)
                {
                    res &= ready.Contains(req);
                }

                return res;
            }

            /// <summary>
            /// Traverse this instance.
            /// </summary>
            /// <returns>The traverse.</returns>
            public string Traverse()
            {
                string res = this.name;

                foreach (TreeNode child in this.children)
                {
                    res += child.Traverse();
                }

                return res;
            }

            /// <summary>
            /// Tree node compare.
            /// </summary>
            public class TreeNodeCompare : IComparer<TreeNode>
            {
                /// <summary>
                /// Compare the specified x and y.
                /// </summary>
                /// <returns>The compare.</returns>
                /// <param name="x">The x coordinate.</param>
                /// <param name="y">The y coordinate.</param>
                public int Compare(TreeNode x, TreeNode y)
                {
                    return string.Compare(x.Name, y.Name);
                }
            }
        }
    }
}
