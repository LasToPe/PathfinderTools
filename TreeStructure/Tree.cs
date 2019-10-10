using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DataTypes;

namespace TreeStructure
{
    public class FeatTree
    {
        private readonly List<TreeNode<Feat>> nodes = new List<TreeNode<Feat>>();

        public FeatTree() { }

        public FeatTree(IEnumerable<Feat> feats)
        {
            var tempNodes = new List<TreeNode<Feat>>();
            foreach (var feat in feats)
                tempNodes.Add(new TreeNode<Feat>(feat));

            nodes = tempNodes.OrderBy(n => n.Value.BabRequirement).ToList();

            foreach (var node in nodes)
            {
                var feat = node.Value;
                var reqsNodes = nodes.Where(n => feat.Prerequisites.Contains(n.Value.Name));

                foreach (var req in reqsNodes)
                    req.AddChild(node);
            }

            foreach (var node in nodes)
            {
                foreach (var n in node.Children)
                {
                    n.TraverseNodes(c => c.AddParent(node));
                }
            }

            foreach (var node in nodes)
            {
                var removed = new List<TreeNode<Feat>>();
                foreach (var n in node.Children)
                {
                    n.TraverseNodes(c => c.RemoveParentFeat(node));
                }
            }

            foreach (var node in nodes)
            {
                var toRemove = new List<TreeNode<Feat>>();
                foreach (var n in node.Children)
                {
                    if (!n.Parents.Contains(node))
                        toRemove.Add(n);
                }
                node.Children.RemoveAll(n => toRemove.Contains(n));
            }

            //HandleDirtyFighting();
        }

        //private void HandleDirtyFighting()
        //{
        //    var ceNode = nodes.Where(n => n.Value.Name == "Combat Expertise").FirstOrDefault();
        //    var iusNode = nodes.Where(n => n.Value.Name == "Improved Unarmed Strike").FirstOrDefault();
        //    var dfNode = nodes.Where(n => n.Value.Name == "Dirty Fighting").FirstOrDefault();

        //    foreach (var node in nodes)
        //    {
        //        if (node.Parents.Contains(ceNode) || node.Parents.Contains(iusNode))
        //        {
        //            node.Parents.Add(dfNode);
        //            dfNode.Children.Add(node);
        //        }
        //    }
        //}

        public IEnumerable<TreeNode<Feat>> GetTreeNodes() => nodes;
    }

    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
            Parents = new List<TreeNode<T>>();
        }

        public TreeNode<T> this[int i]
        {
            get { return Children[i]; }
        }

        public List<TreeNode<T>> Parents { get; }

        public void AddParent(TreeNode<T> node)
        {
            if (Parents.Contains(node))
                return;

            Parents.Add(node);
        }
        public void RemoveParentFeat(TreeNode<T> node)
        {
            List<TreeNode<T>> inherited = new List<TreeNode<T>>();
            foreach (var p in Parents)
                inherited.AddRange(p.Parents.Where( gp => inherited.All( i => !gp.Parents.Contains(Parents.Where(f => f == i).FirstOrDefault()))));

            if (inherited.Contains(node))
                Parents.Remove(node);
        }

        public T Value { get; }

        public List<TreeNode<T>> Children { get; }

        public void AddChild(TreeNode<T> node)
        {
            Children.Add(node);
        }

        public void Traverse(Action<T> action)
        {
            action(Value);
            foreach (var child in Children)
                child.Traverse(action);
        }

        public void TraverseNodes(Action<TreeNode<T>> action)
        {
            action(this);
            foreach (var child in Children)
                child.TraverseNodes(action);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Concat(Children.SelectMany(x => x.Flatten()));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
