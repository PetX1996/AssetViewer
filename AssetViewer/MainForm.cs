using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CSVFiles;

namespace AssetViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string gameDir;
        string assetDir;
        int totalOverwrites;
        private void MainForm_Load(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            DirectoryInfo binDir = Directory.GetParent(curDir);
            DirectoryInfo gameDir = Directory.GetParent(binDir.FullName);

            this.gameDir = gameDir.FullName;
            this.assetDir = Path.Combine(gameDir.FullName, @"zone_source\english\assetlist");

            if (!Directory.Exists(this.gameDir)
                || !File.Exists(Path.Combine(this.gameDir, "iw3mp.exe"))
                || !Directory.Exists(this.assetDir))
                MessageBox.Show("Bad working directory.");

            UpdateTree();
        }

        private void ModCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTree();
        }

        private void MapTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            UpdateTree();
        }

        private void UpdateTree()
        {
            this.AssetTree.Nodes.Clear();
            this.totalOverwrites = 0;

            BuildTree(Path.Combine(this.assetDir, "common_mp.csv"));
            BuildTree(Path.Combine(this.assetDir, "code_post_gfx_mp.csv"));
            BuildTree(Path.Combine(this.assetDir, "localized_common_mp.csv"));
            BuildTree(Path.Combine(this.assetDir, "localized_code_post_gfx_mp.csv"));

            if (this.ModCheckBox.Checked)
                BuildTree(Path.Combine(this.assetDir, "mod.csv"));

            if (this.MapCheckBox.Checked 
                && this.MapTextBox.Text != "MapName")
                BuildTree(Path.Combine(this.assetDir, this.MapTextBox.Text + ".csv"));

            UpdateInfo();
        }

        private void BuildTree(string filePath)
        {
            try
            {
                CSVFile csv = new CSVFile(filePath);
                csv.Read();


                string fileName = Path.GetFileNameWithoutExtension(filePath);
                BuildFileTree(fileName, csv);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void BuildFileTree(string fileName, CSVFile csv)
        {
            TreeNode fileNode = new TreeNode(fileName);

            int lineI = 0;
            string type;
            string item;
            while (true)
            {
                type = csv.GetValueByLine(lineI, 0);
                item = csv.GetValueByLine(lineI, 1);
                lineI++;

                if (type == null || type == "")
                    break;

                TreeNode itemNode = new TreeNode(item);
                itemNode.Name = item;
                
                TreeNode overwriteNode;
                if (IsOverwrite(type, item, out overwriteNode))
                {
                    itemNode.ForeColor = Color.Blue;
                    overwriteNode.ForeColor = Color.Blue;
                    this.totalOverwrites++;
                }

                TreeNode typeNode = fileNode.FindByName(type);
                if (typeNode == null)
                {
                    typeNode = new TreeNode(type);
                    typeNode.Name = type;
                    fileNode.Nodes.Add(typeNode);
                }

                typeNode.Nodes.Add(itemNode);
            }

            fileNode.Sort();

            foreach (TreeNode n in fileNode.Nodes)
            {
                n.Text = n.Text + " (" + n.Nodes.Count + ")";
                n.Sort();
            }

            this.AssetTree.Nodes.Add(fileNode);            
        }

        private bool IsOverwrite(string type, string item, out TreeNode anotherItem)
        {
            anotherItem = null;
            foreach (TreeNode fileNode in this.AssetTree.Nodes)
            {
                anotherItem = fileNode.FindItemInType(type, item);
                if (anotherItem != null)
                    return true;
            }
            return false;
        }

        enum Limits
        {
            aitype = 0,
            col_map_mp = 2,
            col_map_sp = 1,
            com_map = 1,
            font = 16,
            fx = 400,
            game_map_mp = 1,
            game_map_sp = 1,
            gfx_map = 1,
            image = 2400,
            impactfx = 4,
            lightdef = 32,
            loaded_sound = 1200,
            localize = 6144,
            map_ents = 2,
            material = 2048,
            menu = 640,
            menufile = 128,
            mptype = 0,
            physpreset = 64,
            rawfile = 1024,
            sndcurve = 64,
            snddriverglobals = 1,
            sound = 16000,
            stringtable = 50,
            techset = 1024,
            ui_map = 0,
            weapon = 128,
            xanim = 4096,
            xmodel = 1000,
            xmodelalias = 0,
            xmodelpieces = 64
        }

        private void UpdateInfo()
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (TreeNode fileNode in this.AssetTree.Nodes)
            {
                foreach (TreeNode typeNode in fileNode.Nodes)
                {
                    AddCount(counts, typeNode.Name, typeNode.Nodes.Count);
                }
            }

            counts.Sort();

            StringBuilder text = new StringBuilder("Total stats" + Environment.NewLine);

            string curLine;
            foreach (string key in counts.Keys)
            {
                curLine = key + ": " + counts[key];
                if (Enum.IsDefined(typeof(Limits), key))
                {
                    Limits limit = (Limits)Enum.Parse(typeof(Limits), key);
                    curLine += "/" + (int)limit;
                }
                text.Append(curLine + Environment.NewLine);
            }

            text.Append(Environment.NewLine);
            text.Append("Overwrites: " + this.totalOverwrites);

            this.TotalInfoTextBox.Text = text.ToString();
        }

        private void AddCount(Dictionary<string, int> counts, string type, int value)
        {
            foreach (string key in counts.Keys)
            {
                if (key == type)
                {
                    counts[key] += value;
                    return;
                }
            }
            counts.Add(type, value);
        }
    }
}
