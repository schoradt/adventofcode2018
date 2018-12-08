namespace AoC2018.Lib
{
    using System.Collections.Generic;

    public class Day08
    {
        public int Part1(string line)
        {
            TreeNode root = new TreeNode(line);

            return root.SumMetaData();
        }

        public int Part2(string line)
        {
            TreeNode root = new TreeNode(line);

            return root.Value();
        }

        public class TreeNode
        {
            private List<TreeNode> children = new List<TreeNode>();

            private List<int> metadata = new List<int>();

            private string def;

            public TreeNode(string def)
            {
                this.def = def;

                int childrenCount = this.NextInt();

                int metadataCount = this.NextInt();

                for (int i = 0; i < childrenCount; i++)
                {
                    TreeNode child = new TreeNode(this.def);

                    this.def = child.def;

                    children.Add(child);
                }

                for (int i = 0; i < metadataCount; i++)
                {
                    metadata.Add(this.NextInt());
                }
            }

            private int NextInt()
            {
                int index = def.IndexOf(' ');

                int res;

                if (index < 0)
                {
                    res = int.Parse(def);

                    this.def = "";
                }
                else
                {
                    res = int.Parse(def.Substring(0, index));

                    this.def = this.def.Substring(index + 1);
                }

                return res;
            }

            public int SumMetaData()
            {
                int res = 0;

                foreach(TreeNode child in this.children)
                {
                    res += child.SumMetaData();
                }

                foreach(int meta in this.metadata)
                {
                    res += meta;
                }

                return res;
            }

            public int Value()
            {
                int res = 0;

                if (children.Count == 0)
                {
                    return this.SumMetaData();
                }

                foreach (int meta in this.metadata)
                {
                    if (meta > 0 && children.Count >= meta)
                    {
                        res += children[meta - 1].Value();
                    }
                }

                return res;
            }
        }
    }
}
