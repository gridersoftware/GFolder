# G-Folder

## Requirements
* Windows XP SP3 or newer
* [Microsoft .Net Framework 4 Client Profile] (https://www.microsoft.com/en-us/download/details.aspx?id=24872) - You probably already have this if you meet the above prerequisite.

## What Is This?
G-Folder is a small utility program designed to make folders in bulk. It can be used to make individual folders,
of course, but the true power comes from the Sequence and Folder Tree features.

### Sequences
The Sequence feature allows the user to build an ordered list of folders. For example, if you wanted to have
200 folders labeled with numbers from 1 to 200, you could create an Integers sequence from 1 to 200, and G-Folder would create
all 200 folders for you automatically.

You can also have more than one sequence in a single folder name. For example, if you need folders A through Z,
numbered 1 through 10 (A1, A2, A3... A10, B1, B2... Z9, Z10), you would simply add a Uppercase Letter sequence
from A to Z followed by an Integers sequence from 1 to 10.

Sequences can also be used in combination with fixed names. For example, if you need a set of 20 folders labeled,
"Work Docs 1" through "Work Docs 20", you would write "Word Docs " and add an Integers sequence from 1 to 20.

### Folder Tree
In some cases, the user may want to create a series of nested folders. For instance, the user might want to create 200
folders on the first level, and each folder should contain five subfolders.

To do so, the user should create a normal Integers sequence and add it to the tree. After selecting the new node, they
should add the additional subfolders to the tree. When each folder is created, all of the subfolders associated with that folder
are created as well.

## Simple (Collapsed) Mode
When G-Folder first starts, it is in Simple Mode. In this mode, G-Folder can only create **one fixed-name folder** at a time.

Use the **Browse** button to search for the folder that you'd like to create your new folder in. You may also change the directory
by typing into the **Path** textbox.

When you're ready to create your folder, click **Create Folder**.

## Advanced (Expanded) Mode
Advanced mode is where the Sequencing and Folder Tree features live. **Click the arrows** to switch modes.

Note that in Advanced Mode the **Create Folder** button becomes the **Add to Tree** button. You can only create folders
in Advanced Mode by first adding them to the tree and then clicking **Create Folders** in the lower-right.

### Using Sequences
Select a sequence type from the dropdown list. As of this writing there are four sequence types:

* Integers - Numbers ranging from -2,147,483,648 to 2,147,483,647.
* Lowercase Letters - Letters in the English alphabet ranging from 'a' to 'z'.
* Uppercase Letters - Letters in the Engliish alphabet ranging from 'A' to 'Z'.
* Custom Sequence - A list of fixed names imported from a text file.

Once you have your **Type** selected, you may modify the values in **To** and **From**. These values are inclusive,
and will determine the range of the sequence.

After you've done this, click **Add Sequence**. The sequence will be translated into a Sequence Code in the format
"[XX:Y-Z]", which is appended to the end of the **Folder Name**. The "XX" component is a two-letter code representing the type
of sequence. NU is Integers, LL is Lowercase Letters, UL is Uppercase Letters, and CS is Custom Sequence. The Y and Z components
are the values you picked for From and To, respectively.

You may add as many sequences as you like, add fixed text before, after, and in between sequences in the **Folder Name** textbox.

Once you've finished your folder name, click **Add to Tree** to add the folder to the selected node in the **Folder Tree** pane.

### Using the Folder Tree
The first node in the **Folder Tree** is the directory listed in **Path**, where your folders will be created.
When the user clicks **Add to Tree**, the new folder is added to the selected node. This means that the user
can add subfolders to new folders using this method. Any subfolders added to a sequence folder will exist in all
folders of the sequence.

Once your folders have been added to the **Folder Tree**, click **Create Folders**. The status of the folder creation
will be listed in the **Log** on the lower-left. Any errors that occur during this process may also be listed there.

After the folders are created, the folder structure will remain in the Folder Tree. You may remove items from the Folder
Tree at any time by selecting them and clicking Remove Folder. Removing a node from the Folder Tree does not delete them
from your computer if they exist.

## Help and Support
You may access this help file at any time by clicking the **?** icon at the top of the window (Requires Internet connection).

If you have any problems with the software, or wish to request a feature, you may do so on the [GitHub Issues page] (https://github.com/gridersoftware/GFolder/issues).