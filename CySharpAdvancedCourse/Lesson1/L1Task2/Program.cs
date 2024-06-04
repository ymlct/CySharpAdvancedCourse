using System;
using System.Collections.Generic;

namespace L1Task2
{
    /*
    Задание 3
    Создайте коллекцию, которая бы по свой структуре напоминала «родовое дерево» (имя
    человека, год рождения), причем в нее можно добавлять/удалять нового родственника, есть
    возможность увидеть всех наследников выбранного человека, отобрать родственников по году
    рождения.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            Node node1 = new Node(
                description: new NodeDescription(
                    name: "Елизавета II",
                    birthYear: 1926
                    )
                );
            
            Node node2 = new Node(
                description: new NodeDescription(
                    name: "принц Филипп II",
                    birthYear: 1921
                )
            );
            
            Node node3 = new Node(
                description: new NodeDescription(
                    name: "Карл III",
                    birthYear: 1948
                )
            );
            
            Node node4 = new Node(
                description: new NodeDescription(
                    name: "Диана",
                    birthYear: 1961
                )
            );
            
            Node node5 = new Node(
                description: new NodeDescription(
                    name: "Уильям Принц Уэльский",
                    birthYear: 1982
                )
            );
            
            Node node6 = new Node(
                description: new NodeDescription(
                    name: "Принц Гарри",
                    birthYear: 1984
                )
            );

            FamilyTree familyTree = new FamilyTree();

            familyTree.AddChildToParent(node1, node3);
            familyTree.AddChildToParent(node2, node3);
            
            familyTree.AddChildToParent(node3, node5);
            familyTree.AddChildToParent(node3, node6); 
            familyTree.AddChildToParent(node4, node5);
            familyTree.AddChildToParent(node4, node6);

            familyTree.ShowChildrenTreeForNode(node1);
        }
    }

    internal class FamilyTree
    {

        private readonly List<Node> _familyMembers = new List<Node>();

        public void AddChildToParent(Node parent, Node child)
        {
            _familyMembers.Add(child);
            child.AddParent(parent);
            parent.AddChild(child);
        }
        
        public void RemoveChildFromParent(Node parent, Node child)
        {
            _familyMembers.Remove(child);
            child.DeleteParent(child);
            parent.DeleteChild(child);
        }
        
        public void ShowChildrenTreeForNode(Node node)
        {
            HashSet<Node> setOfChildren = new HashSet<Node>();

            IterateChildren(node, setOfChildren);
            
            foreach (var child in setOfChildren)
            {
                Console.WriteLine(child.Description.Name);
            }

            return;

            void IterateChildren(Node tnode, HashSet<Node> children)
            {
                if (tnode.Children.Count == 0) return;
                
                foreach (var child in tnode.Children)
                {
                    children.Add(child);
                }
                foreach (var child in tnode.Children)
                {
                    IterateChildren(child, children);
                }
            }
        }
    }

    internal class Node
    {

        
        public readonly List<Node> Parents;
        
        public readonly List<Node> Children;
        
        public readonly NodeDescription Description;

        public Node(NodeDescription description)
        {
            Description = description;
            Parents = new List<Node>();
            Children = new List<Node>();
        }

        public void AddChild(Node child)
        {
            Children.Add(child);
        }
        
        public void DeleteChild(Node child)
        {
            if (!Children.Remove(child)) throw new Exception("DeleteChild");
        }
        
        public void AddParent(Node parent)
        {
            if (Parents.Count >= 2) throw new Exception("AddParent");
            Parents.Add(parent);
        }
        
        public void DeleteParent(Node parent)
        {
            if (!Parents.Remove(parent)) throw new Exception("DeleteParent");
        }
    }


    internal class NodeDescription
    {
        public readonly string Name;
        
        public readonly int BirthYear;

        public NodeDescription(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }
    }

}