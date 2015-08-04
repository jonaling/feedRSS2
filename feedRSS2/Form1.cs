using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace feedRSS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlReader feedRead = XmlReader.Create(textBox1.Text);
                
                SyndicationFeed feedFeed = SyndicationFeed.Load(feedRead);
                TabPage feedTab = new TabPage(feedFeed.Title.Text);
                tabControl1.TabPages.Add(feedTab);
                ListBox feedList = new ListBox();
                

                feedTab.Controls.Add(feedList);
                feedList.Dock = DockStyle.Fill;
                feedList.HorizontalScrollbar = true;
                textBox1.Text = "";

                foreach (SyndicationItem feedItem in feedFeed.Items) {
                    String summary = (feedItem.Summary.Text);
                    // Console.WriteLine(summary.Split(new string[] { "<br clear='all'/" }, StringSplitOptions.None));
                   // Console.WriteLine(summary.Replace("<", "&lt;").Split(new string[] { "&lt;" }, StringSplitOptions.None));
                    feedList.Items.Add(feedItem.Title.Text);
                    feedList.Items.Add(summary);
                   /* if (feedItem.Links != null)
                    {
                        feedList.Items.Add(feedItem.Links.ToString());
                    }*/
                    feedList.Items.Add("----------");
                }

              /*  for(int i = 0; i<= 24; i++)
                {
                    Console.WriteLine(i.ToString());
                }*/
            }
            catch { }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
