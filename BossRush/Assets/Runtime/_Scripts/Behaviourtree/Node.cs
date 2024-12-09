using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    public enum NodeState
    {
        Success,
        Failure,
        Running
    }

    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children;

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }
        public Node(List<Node> children)
        {
            foreach(Node child in children)
            {
                _Attatch(child);
            }
        }

        private void _Attatch(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evalutate() => NodeState.Failure;

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if(_dataContext.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = parent;
            while(node != null)
            {
                value = node.GetData(key);
                if(node != null)
                {
                    return value;
                }
                node = node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if(_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);

                if(cleared)
                {
                    return true;
                }
                node = node.parent;
            }
            return false;
        }
    }
}

