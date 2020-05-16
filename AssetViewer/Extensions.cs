using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssetViewer
{
    static class Extensions
    {
        public static TreeNode FindByName(this TreeNode node, string name)
        {
            foreach (TreeNode n in node.Nodes)
                if (n.Name == name)
                    return n;

            return null;
        }

        public static TreeNode FindItemInType(this TreeNode node, string typeName, string itemName)
        {
            TreeNode typeNode = node.FindByName(typeName);
            if (typeNode == null)
                return null;

            return typeNode.FindByName(itemName);
        }

        public static void Sort(this TreeNode node)
        {
            List<TreeNode> nodes = new List<TreeNode>(node.Nodes.Count);
            foreach (TreeNode n in node.Nodes)
                nodes.Add(n);

            nodes.Sort((a,b) => a.Text.CompareTo(b.Text));

            node.Nodes.Clear();
            node.Nodes.AddRange(nodes.ToArray());
        }

        public static void Sort(this Dictionary<string, int> dictionary)
        {
            List<DictionaryItem> items = new List<DictionaryItem>(dictionary.Keys.Count);

            foreach (string key in dictionary.Keys)
                items.Add(new DictionaryItem(key, dictionary[key]));

            items.Sort((a, b) => a.Key.CompareTo(b.Key));
            dictionary.Clear();

            foreach (DictionaryItem item in items)
                dictionary.Add(item.Key, item.Value);
        }

        private struct DictionaryItem
        {
            public string Key;
            public int Value;

            public DictionaryItem(string key, int value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
