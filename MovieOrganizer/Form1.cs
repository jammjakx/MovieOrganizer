using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MovieOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void importMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listboxItems = getDirectoryNames(getPathName());
            foreach (var item in listboxItems)
            {
                lbMovieNames.Items.Add(item);
            }
        }

        private string getPathName()
        {
            var fbd = new FolderBrowserDialog();

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            return null; 
        }

        private List<String> getDirectoryNames(string pathName)
        {
            var directoryNames = new List<String>();
            var directories = Directory.GetDirectories(pathName, "*", SearchOption.TopDirectoryOnly);

            foreach (var directory in directories)
            {
               directoryNames.Add(Path.GetFileName(directory));
            }
            return directoryNames;
        }
        
    }
}
