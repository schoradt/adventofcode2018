// <copyright file="Day08.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System.Collections.Generic;

    /// <summary>
    /// Day08 solution class.
    /// </summary>
    public class Day08
    {
        /// <summary>
        /// Part1 of the puzzle solution.
        /// </summary>
        /// <returns>The solution.</returns>
        /// <param name="line">Input line.</param>
        public int Part1(string line)
        {
            TreeNode root = new TreeNode(line);

            return root.SumMetaData();
        }

        /// <summary>
        /// Part2 of the puzzle solution.
        /// </summary>
        /// <returns>The solution.</returns>
        /// <param name="line">Input line.</param>
        public int Part2(string line)
        {
            TreeNode root = new TreeNode(line);

            return root.Value();
        }

        /// <summary>
        /// Tree node.
        /// </summary>
        public class TreeNode
        {
            /// <summary>
            /// The children.
            /// </summary>
            private List<TreeNode> children = new List<TreeNode>();

            /// <summary>
            /// The metadata.
            /// </summary>
            private List<int> metadata = new List<int>();

            /// <summary>
            /// The def.
            /// </summary>
            private string def;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day08.TreeNode"/> class.
            /// </summary>
            /// <param name="def">Subtree definition.</param>
            public TreeNode(string def)
            {
                this.def = def;

                int childrenCount = this.NextInt();

                int metadataCount = this.NextInt();

                for (int i = 0; i < childrenCount; i++)
                {
                    TreeNode child = new TreeNode(this.def);

                    this.def = child.def;

                    this.children.Add(child);
                }

                for (int i = 0; i < metadataCount; i++)
                {
                    this.metadata.Add(this.NextInt());
                }
            }

            /// <summary>
            /// Compute node value.
            /// </summary>
            /// <returns>The value.</returns>
            public int Value()
            {
                int res = 0;

                if (this.children.Count == 0)
                {
                    return this.SumMetaData();
                }

                foreach (int meta in this.metadata)
                {
                    if (meta > 0 && this.children.Count >= meta)
                    {
                        res += this.children[meta - 1].Value();
                    }
                }

                return res;
            }

            /// <summary>
            /// Sums the meta data.
            /// </summary>
            /// <returns>The sum of all meta data.</returns>
            public int SumMetaData()
            {
                int res = 0;

                foreach (TreeNode child in this.children)
                {
                    res += child.SumMetaData();
                }

                foreach (int meta in this.metadata)
                {
                    res += meta;
                }

                return res;
            }

            /// <summary>
            /// Gets next integer from the definition string.
            /// </summary>
            /// <returns>The int.</returns>
            private int NextInt()
            {
                int index = this.def.IndexOf(' ');

                int res;

                if (index < 0)
                {
                    res = int.Parse(this.def);

                    this.def = string.Empty;
                }
                else
                {
                    res = int.Parse(this.def.Substring(0, index));

                    this.def = this.def.Substring(index + 1);
                }

                return res;
            }
        }
    }
}
