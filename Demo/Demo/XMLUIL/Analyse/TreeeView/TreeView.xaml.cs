using Demo.Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.ComponentModel;
using Demo.XMLUIL.Analyse.GridControl;
using XMLAnalyzer.Business;

namespace Demo.XMLUIL.Analyse
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView 
    {
        public TreeView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void DataTreeView_OnLoaded(object sender, RoutedEventArgs e)
        {
      
        }
        private void FillTreeView()
        {
            var rootinfo = Domain.Instance.StructureInfo;
            var rootNode = new TreeViewItem();
            rootNode.Header = rootinfo.Name;
            DataTreeView.Items.Add(rootNode);
            AddChildNodesRecursive(rootinfo, rootNode);          
        }

        private void AddChildNodesRecursive(StructureInfo info, TreeViewItem node)
        {
            foreach (var childInfo in info.Childs)
            {
                var childNode = new TreeViewItem();
                childNode.Header = childInfo.Name;
                childNode.Tag = childInfo;
                node.Items.Add(childNode);
                AddChildNodesRecursive(childInfo, childNode);
            }
        }

        private void btnopen_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTreeView.Items.Clear();
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                string filename = open.FileName;
                Domain.Instance.StructureInfo = XmlParser.Execute(XDocument.Load(filename));
                FillTreeView();
            }
            catch (Exception)
            {

              
            }
           
        }

        private void DataTreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selected = DataTreeView.SelectedItem as TreeViewItem;
            if (selected != null)
            {
                var structureInfo = selected.Tag as StructureInfo;
                Domain.Instance.SelectedStructureInfo = structureInfo;
                
                //all data sind hier 
            }
        }
    }
}
