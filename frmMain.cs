using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace GFolder
{
    public partial class frmMain : Form
    {
        public bool Expanded { get; private set; }
        bool canOpenFile = true;

        const int RESTORED_WIDTH = 336;
        const int RESTORED_HEIGHT = 122;
        const int EXPANDED_WIDTH = 638;
        const int EXPANDED_HEIGHT = 427;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pbExpand.Image = Properties.Resources.ArrowDown.ToBitmap();
            Expanded = false;
            Height = RESTORED_HEIGHT;
            Width = RESTORED_WIDTH;
            txtPath.Text = Directory.GetCurrentDirectory();
            tvFolderTree.Nodes.Add(txtPath.Text);
            tvFolderTree.SelectedNode = tvFolderTree.Nodes[0];
            txtFolderName.SelectAll();

            // Add sequence types
            cboSequenceType.Items.Add(new IntSequence(1, 10));
            cboSequenceType.Items.Add(new LowerLettersSequence('a', 'z'));
            cboSequenceType.Items.Add(new UpperLettersSequence('A', 'Z'));
            cboSequenceType.Items.Add(new CustomSequence());

            cboSequenceType.SelectedIndex = 0;
        }

        private void ErrorMsg(string message)
        {
            MessageBox.Show(message, "G-Folder", MessageBoxButtons.OK);
            Log(message);
        }

        private void Log(string message)
        {
            lstLog.Items.Add(message);
            lstLog.SelectedIndex = lstLog.Items.Count - 1;
        }

        private void pbExpand_Click(object sender, EventArgs e)
        {
            if (Expanded)
            {
                Height = RESTORED_HEIGHT;
                Width = RESTORED_WIDTH;
                btnCreate.Text = "Create Folder";
                pbExpand.Image = Properties.Resources.ArrowDown.ToBitmap();
            }
            else
            {
                Height = EXPANDED_HEIGHT;
                Width = EXPANDED_WIDTH;
                btnCreate.Text = "Add to Tree";
                pbExpand.Image = Properties.Resources.ArrowUp.ToBitmap();
            }
            Expanded = !Expanded;
        }

        private void frmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            System.Diagnostics.Process.Start("https://github.com/gridersoftware/GFolder#gfolder");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!Expanded)
            {

                DirectoryInfo root = new DirectoryInfo(txtPath.Text);
                DirectoryInfo subfolder;
                string result;

                if (!root.Exists)
                {
                    ErrorMsg("Directory does not exist.");
                    return;
                }

                CreateFolder(root, txtFolderName.Text, out result, out subfolder);
                ErrorMsg(result);
            }
            else
            {
                tvFolderTree.SelectedNode.Nodes.Add(txtFolderName.Text);
                tvFolderTree.SelectedNode.Expand();
            }
            txtFolderName.Text = "";
        }

        bool CreateFolder(DirectoryInfo root, string folderName, out string message, out DirectoryInfo subfolder)
        {
            string outMsg = "";
            bool result = false;
            subfolder = null;

            Action<string> Message = new Action<string>(msg => 
                {
                     outMsg = string.Format("{0}: {1}", folderName, msg);
                });

            try
            {
                subfolder = root.CreateSubdirectory(folderName);
                Message(string.Format("Folder created!"));
                result = true;
            }
            catch (ArgumentNullException)
            {
                Message("ArgumentNullException. This shouldn't happen. If it does, please contact the developer!");
            }
            catch (ArgumentException)
            {
                Message("Invalid folder name.");
            }
            catch (DirectoryNotFoundException)
            {
                Message("DirectoryNotFoundException. This shouldn't happen. If it does, please contact the developer!");
            }
            catch (PathTooLongException)
            {
                Message("The specified path is too long.");
            }
            catch (IOException)
            {
                Message("The folder with the same name already exists or cannot be created.");
            }
            catch (System.Security.SecurityException)
            {
                Message("G-Folder does not have permission to create the folder.");
            }
            catch (NotSupportedException)
            {
                Message("The folder name has a colon in it.");
            }
    
            message = outMsg;
            return result;
        }

        /// <summary>
        /// Interprets a sequence code and returns a sequence of the appropriate range.
        /// </summary>
        /// <param name="code">Sequence code</param>
        /// <param name="sequence">Resulting sequence</param>
        /// <returns>Returns true if the sequence was succesfully interpreted. Otherwise, returns false.</returns>
        /// <exception cref="ArgumentException">Thrown if one or both of the From/To values cannot be parsed into the sequence type.</exception>
        bool InterpretSequence(string code, out ISequence sequence)
        {
            // Regex for a sequence code
            Regex rxCode = new Regex(@"\[([A-Z][A-Z]):([^-]+)-([^\]]+)\]");
            Match codeMatch = rxCode.Match(code);

            if (codeMatch.Success)
            {
                string header = codeMatch.Groups[1].Value;
                string from = codeMatch.Groups[2].Value;
                string to = codeMatch.Groups[3].Value;

                for (int i = 0; i < cboSequenceType.Items.Count; i++)
                {
                    if (((ISequence)cboSequenceType.Items[i]).Header == header)
                    {
                        sequence = ((ISequence)cboSequenceType.Items[i]).NewSequence();
                        if ((!sequence.TrySetFrom(from)) | (!sequence.TrySetTo(to)))
                            throw new ArgumentException();
                        return true;
                    }
                }
            }

            sequence = null;
            return false;
        }

        bool IsSequence(string value)
        {
            return Regex.IsMatch(value, @"\[[A-Z][A-Z]:[^-]+-[^\]]+\]");
        }

        bool ExtractNameComponents(string rawFolderName, out string[] parts, out ISequence[] sequences)
        {
            sequences = new ISequence[0];

            if (!ContainsSequences(rawFolderName, out parts))
            {
                parts = new string[] { rawFolderName };
                return true;
            }

            List<ISequence> seq = new List<ISequence>();
            ISequence temp;

            for (int i = 0; i < parts.Length; i++)
            {
                // Check if the part is a sequence code.
                if (IsSequence(parts[i]))
                {
                    try
                    {
                        // If it is a sequence code, interpret the code and get the sequence
                        if (!InterpretSequence(parts[i], out temp))
                        {
                            // If the sequence cannot be interpreted, it may not be supported.
                            ErrorMsg(string.Format("\"{0}\" is not a valid or supported sequence.", parts[i]));
                            return false;
                        }

                        // Add the sequence to the list.
                        seq.Add(temp);
                    }
                    catch (ArgumentException)
                    {
                        // In the case that something weird goes wrong and the txtFrom.Text or txtTo.Text values can't be parsed, it should throw an error.
                        ErrorMsg("The From or To parameters cannot be correctly parsed into the selected sequence type. Did you modify the sequence code?");
                        return false;
                    }
                }
            }

            // Set the sequence list.
            sequences = seq.ToArray();
            return true;
        }

        bool ContainsSequences(string folderName, out string[] parts)
        {
            Regex rxCode = new Regex(@"(\[[A-Z][A-Z]:[^-]+-[^\]]+\])");
            parts = rxCode.Split(folderName);

            return (parts.Length > 0);
        }

        private void cboSequenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((canOpenFile) && (cboSequenceType.SelectedItem is CustomSequence))
            {
                canOpenFile = false;
                DialogResult openFile = dlgOpenFile.ShowDialog();
                if (openFile == System.Windows.Forms.DialogResult.OK)
                    cboSequenceType.Items[cboSequenceType.SelectedIndex] = new CustomSequence(File.ReadAllLines(dlgOpenFile.FileName));
                else
                    cboSequenceType.SelectedIndex = 0;
            }
            canOpenFile = true;

            ISequence item = (ISequence)cboSequenceType.SelectedItem;

            txtTo.Text = item.To.ToString();
            txtFrom.Text = item.From.ToString();
        }

        private void btnAddSequence_Click(object sender, EventArgs e)
        {
            if (cboSequenceType.SelectedItem == null)
                return;

            ISequence sequence = ((ISequence)cboSequenceType.SelectedItem).NewSequence();
            if (!sequence.TrySetFrom(txtFrom.Text))
            {
                ErrorMsg(string.Format("From must be a value between {0} and {1}.", sequence.Minimum, sequence.Maximum));
                return;
            }
            if (!sequence.TrySetTo(txtTo.Text))
            {
                ErrorMsg(string.Format("To must be a value between {0} and {1}.", sequence.Minimum, sequence.Maximum));
                return;
            }

            txtFolderName.AppendText(sequence.Code);
        }

        private void btnCreateTree_Click(object sender, EventArgs e)
        {
            // First determine if the root folder exists.

            DirectoryInfo root = new DirectoryInfo(tvFolderTree.Nodes[0].Text);
            if (!root.Exists)
            {
                ErrorMsg("Directory does not exist.");
                return;
            }

            // Build all the folders
            for (int i = 0; i < tvFolderTree.Nodes[0].Nodes.Count; i++)
            {
                CreateNode(root, tvFolderTree.Nodes[0].Nodes[i]);
            }
        }

        private void CreateNode(DirectoryInfo root, TreeNode node)
        {
            if (!root.Exists)
                throw new DirectoryNotFoundException();

            string[] parts;
            ISequence[] sequences;

            int totalFolders = 1;

            if (!ExtractNameComponents(node.Text, out parts, out sequences))
                return;

            int[] counters = new int[sequences.Length];
            
            // Get total number of folders
            for (int i = 0; i < sequences.Length; i++)
            {
                totalFolders = totalFolders * sequences[i].Output.Length;
            }

            // Build folders
            for (int counter = 0; counter < totalFolders; counter++)
            {
                StringBuilder name = new StringBuilder();

                // Calculate the current counter values
                int quotient = counter;
                for (int i = 0; i < counters.Length; i++)
                {
                    counters[i] = quotient % sequences[i].Output.Length;
                    quotient = quotient / sequences[i].Output.Length;
                }

                // Build the folder name
                int sequenceIndex = 0;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (Regex.IsMatch(parts[i], @"\[[A-Z][A-Z]:[^-]+-[^\]]+\]"))
                    {
                        name.Append(sequences[sequenceIndex].Output[counters[sequenceIndex]]);
                        sequenceIndex++;
                    }
                    else
                    {
                        name.Append(parts[i]);
                    }
                }

                // Attempt to make the folder
                DirectoryInfo subfolder;
                string msg;

                bool folderMade = CreateFolder(root, name.ToString(), out msg, out subfolder);
                Log(msg);

                // Determine if subfolders should be made.
                if ((folderMade) & (node.Nodes.Count > 0))
                {
                    for (int i = 0; i < node.Nodes.Count; i++)
                    {
                        CreateNode(subfolder, node.Nodes[i]);
                    }
                }
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (tvFolderTree.Nodes.Count == 0)
                return;

            tvFolderTree.Nodes[0].Text = txtPath.Text;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if ((tvFolderTree.Nodes[0] != tvFolderTree.SelectedNode) && 
                (DialogResult.Yes == MessageBox.Show("Are you sure you want to remove this folder?", 
                 "G-Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                tvFolderTree.SelectedNode.Remove();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.Description = "Select the path to create folders in.";
            dlgFolderBrowser.ShowNewFolderButton = false;

            if (Directory.Exists(txtPath.Text))
                dlgFolderBrowser.SelectedPath = txtPath.Text;

            if (dlgFolderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = dlgFolderBrowser.SelectedPath;
            }
        }

        private void tvFolderTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnRemove.Enabled = tvFolderTree.SelectedNode != tvFolderTree.Nodes[0];
        }

        private void txtFolderName_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = txtFolderName.Text != "";
        }
    }
}
