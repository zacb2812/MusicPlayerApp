using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerApp
{
    public partial class MusicPlayer : Form
    {
        //global arrays for file paths and names
        string[] names, paths;

        public MusicPlayer()
        {
            InitializeComponent();
        }

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            //dialog box for selecting songs to add to player
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true; //enables multi select

            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)//check dialog box opened successfully 
            {
                names = ofd.SafeFileNames;//saves selected file names
                paths = ofd.FileNames;//saves selceted file paths
                listBoxSongs.Items.Clear();//clears current songs in list for new selection

                for (int i = 0; i<names.Length; i++)
                {
                    listBoxSongs.Items.Add(names[i]);//adds songs to list box
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //playing selected music in player
            musicMediaPlayer.URL = paths[listBoxSongs.SelectedIndex];
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();//closes application
        }
        
    }
}
