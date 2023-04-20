using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class MyTree
    {
        //private string rootPath;
        private TreeView tView;

        public MyTree(/*string rootPath, */ TreeView tView)
        {
            //this.rootPath = rootPath;
            this.tView = tView;
        }
        public void InitializeTree(int opt = 1, string rootPath = "")
        {
            tView.Nodes.Clear();
            //this.rootPath = rootPath;
            if (opt == 1)
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    TreeNode root = new TreeNode(drive.Name);
                    root.Tag = drive.Name;
                    tView.Nodes.Add(root);
                    PopulateTreeView(drive.Name, root);
                }
            }
            else
            {
                TreeNode root = new TreeNode(rootPath);
                root.Tag = rootPath;
                tView.Nodes.Add(root);
                PopulateTreeView(rootPath, tView.Nodes[0]);
            }
        }

        private void PopulateTreeView(string directoryPath, TreeNode parentNode)
        {

            parentNode.Nodes.Clear();
            string[] directoryPaths;
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    directoryPaths = Directory.GetDirectories(directoryPath);
                }
                else
                {
                    return;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return;
            }
            foreach (string directory in directoryPaths)
            {
                TreeNode directoryNode = new TreeNode(Path.GetFileName(directory));
                directoryNode.Tag = directory;
                parentNode.Nodes.Add(directoryNode);

                TreeNode emptyNode = new TreeNode("...");
                directoryNode.Nodes.Add(emptyNode);
            }
            string[] filePaths = Directory.GetFiles(directoryPath);
            if (filePaths.Length >= 3)
            {
                TreeNode fileNode = new TreeNode("<Files>");
                parentNode.Nodes.Add(fileNode);
                parentNode = fileNode;
            }
            foreach (string filePath in filePaths)
            {
                TreeNode fileNode = new TreeNode(Path.GetFileName(filePath));
                fileNode.Tag = filePath;
                parentNode.Nodes.Add(fileNode);
            }
        }

        public void expandTree(string name, TreeNode node)
        {
            if (node != null && Directory.Exists(name))
            {
                PopulateTreeView(name, node);
            }
        }

    }
}
