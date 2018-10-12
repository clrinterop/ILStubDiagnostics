using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ILStubDiagnostic
{
    public partial class MainForm : Form
    {
        private const string StubHelperAPIHeader = "System.StubHelpers";

        private static readonly Font StubHelperAPIFont = new Font(
            "Courier New", 9f, FontStyle.Bold | FontStyle.Underline);

        private const string ButtonControllerEnableText = "Start";

        private const string ButtonControllerEnableToolTipText = "Start Monitoring";

        private const string ButtonControllerDisableText = "Stop";

        private const string ButtonControllerDisableToolTipText = "Stop Monitoring";

        private const float ZoomFactor = 1.1F;

        Bitmap m_startButtonImage = global::ILStubDiagnostic.Properties.Resources.Start;

        Bitmap m_stopButtonImage = global::ILStubDiagnostic.Properties.Resources.Stop;

        Bitmap m_findRepeatImage = global::ILStubDiagnostic.Properties.Resources.FindRepeat;

        BindingList<ILStubEvent> m_viewEventList = new BindingList<ILStubEvent>();

        ILStubEventFilterList m_filterList = new ILStubEventFilterList();

        private SortedList<int, ILStubCodeBlock> m_codeBlockList;

        private static string[] columnNames = {
            "MethodName", "CreateTime", "ProcessID", "ProcessName", "Category",
            "ManagedSignature", "ClrInstanceId", "ModuleId", "StubMethodId", "ManagedMethodToken",
            "NativeSignature"
        };

        private static bool[] initialColumnCheckedStatus = {
            true, true, false, true, true,
            true, false, false, false, false,
            true
        };

        private static string[] dataPropertyNames = {
            "MethodName", "CreateTimeString", "ProcessID", "ProcessName", "Category",
            "ManagedSignature", "ClrInstanceId", "ModuleId", "StubMethodId", "ManagedMethodToken",
            "NativeSignature"
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ILStubDiagnosticSessionController controller =
                ILStubDiagnosticSessionController.GetInstance();
            if (controller.IsEnabled)
                controller.DisableILStubSession();

            // Force the Kernel Process Trace thread to exit.
            // We do not need to stop the "NT Kernel Logger" session.
            controller.ExitKernelTraceProcess();

            Environment.Exit(0);
        }

        private void toolStripButtonControlSession_Click(object sender, EventArgs e)
        {
            ILStubDiagnosticSessionController controller =
                ILStubDiagnosticSessionController.GetInstance();
            if (controller.IsEnabled)
            {
                controller.DisableILStubSession();
                toolStripLabelRunning.Visible = false;
                toolStripButtonControlSession.Image = m_startButtonImage;
                toolStripButtonControlSession.Text = ButtonControllerEnableText;
                toolStripButtonControlSession.ToolTipText = ButtonControllerEnableToolTipText;
            }
            else
            {
                controller.EnableILStubSession();
                toolStripLabelRunning.Visible = true;
                toolStripButtonControlSession.Image = m_stopButtonImage;
                toolStripButtonControlSession.Text = ButtonControllerDisableText;
                toolStripButtonControlSession.ToolTipText = ButtonControllerDisableToolTipText;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ILStubDiagnosticSessionController controller =
                ILStubDiagnosticSessionController.GetInstance();
            controller.EnableKernelSession();
            controller.ILStubEventHandler += ILStubEventListener;

            // For ILStubEvents DataGridView
            dataGridViewILStubEvents.AutoGenerateColumns = false;
            for (int i = 0; i < columnNames.Length; i++)
            {
                dataGridViewILStubEvents.Columns.Add(columnNames[i], columnNames[i]);
                dataGridViewILStubEvents.Columns[i].DataPropertyName = dataPropertyNames[i];
                dataGridViewILStubEvents.Columns[i].Visible = false;
            }
            // Add the last padding column.
            dataGridViewILStubEvents.Columns.Add("", "");
            dataGridViewILStubEvents.Columns[columnNames.Length].Visible = true;
            dataGridViewILStubEvents.Columns[columnNames.Length].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // Bind to the event list.
            dataGridViewILStubEvents.DataSource = m_viewEventList;

            // For Filter DataGridView
            DataGridViewComboBoxColumn fieldColumn =
                dataGridViewFilter.Columns[0] as DataGridViewComboBoxColumn;
            fieldColumn.Items.Clear();
            List<IILStubEventFilterDef> filterDefList =
                ILStubEventFilterManager.GetInstance().FilterDefList;
            for (int i = 0; i < filterDefList.Count; i++)
            {
                fieldColumn.Items.Add(filterDefList[i].FilterName);
            }
            UpdateFilterMessage();

            // For contextMenuStripOnEventsColumnHeader
            for (int i = 0; i < columnNames.Length; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = columnNames[i];
                item.CheckOnClick = true;
                item.Click += ItemOfContextMenuStripOnEventsColumnHeader_Click;
                contextMenuStripOnEventsColumnHeader.Items.Add(item);
                if (initialColumnCheckedStatus[i])
                {
                    item.PerformClick();
                }
            }
            // We can not hide the first column.
            contextMenuStripOnEventsColumnHeader.Items[0].Enabled = false;
        }

        private void ItemOfContextMenuStripOnEventsColumnHeader_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            DataGridViewColumn column = FindEventsColumn(item.Text);
            if (column != null)
            {
                column.Visible = (item.CheckState == CheckState.Checked);
            }
        }

        private DataGridViewColumn FindEventsColumn(string columnName)
        {
            DataGridViewColumnCollection columns = dataGridViewILStubEvents.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                if (columnName == columns[i].HeaderText)
                    return columns[i];
            }
            return null;
        }

        private void ILStubEventListener(ILStubEvent ilStubEvent)
        {
            this.Invoke(new Action<ILStubEvent>(InsertViewEvent),
                new object[] { ilStubEvent });
        }

        private void InsertViewEvent(ILStubEvent ilStubEvent)
        {
            lock (m_viewEventList)
            {
                if (m_filterList.Match(ilStubEvent))
                    m_viewEventList.Insert(0, ilStubEvent);
            }
        }

        private void dataGridViewILStubEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewILStubEvents.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewILStubEvents.SelectedRows[0];
                Debug.Assert(selectedRow.DataBoundItem is ILStubEvent);
                ILStubEvent ilStubEvent = selectedRow.DataBoundItem as ILStubEvent;
                StringBuilder sb = new StringBuilder();
                sb.Append("// Managed Signature: ");
                sb.Append(ilStubEvent.ManagedSignature);
                sb.Append("\n// Native Signature: ");
                sb.Append(ilStubEvent.NativeSignature);
                sb.Append("\n\n// IL Stub:\n");
                sb.Append(ilStubEvent.StubMethodILCode);
                richTextBoxILCode.Text = sb.ToString();
            }
            else
            {
                richTextBoxILCode.Text = string.Empty;
            }
        }

        private void dataGridViewFilter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                DataGridViewCell operationCell = dataGridViewFilter.Rows[e.RowIndex].Cells[1];
                object oldSelectedItem = operationCell.Value;
                operationCell.Value = string.Empty;
                DataGridViewCell fieldCell = dataGridViewFilter.Rows[e.RowIndex].Cells[0];
                string filterName = fieldCell.Value.ToString();
                IILStubEventFilterDef filterDef =
                    ILStubEventFilterManager.GetInstance().GetFilterDef(filterName);
                if (filterDef != null)
                {
                    List<string> operations = filterDef.Operations;
                    DataGridViewComboBoxCell comboBoxOperationCell =
                        operationCell as DataGridViewComboBoxCell;
                    comboBoxOperationCell.Items.Clear();
                    comboBoxOperationCell.Items.AddRange(operations.ToArray());
                    if (oldSelectedItem != null &&
                        comboBoxOperationCell.Items.Contains(oldSelectedItem))
                    {
                        comboBoxOperationCell.Value = oldSelectedItem;
                    }
                }
            }
        }

        private void dataGridViewFilter_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewFilter.IsCurrentCellDirty)
            {
                dataGridViewFilter.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ILStubEventFilterList listFilter = new ILStubEventFilterList();
                int rowCount = dataGridViewFilter.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewFilter.Rows[i];
                    if (dataGridViewRow.IsNewRow)
                        continue;
                    if (dataGridViewRow.Cells[0].Value == null)
                    {
                        MessageBox.Show("The field of row " + (i + 1) + " is empty.");
                        return;
                    }
                    string filterName = dataGridViewRow.Cells[0].Value.ToString();
                    IILStubEventFilterDef filterDef =
                        ILStubEventFilterManager.GetInstance().GetFilterDef(filterName);
                    Debug.Assert(filterDef != null);
                    if (dataGridViewRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("The operation of row '" + filterName + "' is empty.");
                        return;
                    }
                    string operaton = dataGridViewRow.Cells[1].Value.ToString();
                    if (dataGridViewRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("The value of row '" + filterName + "' is empty.");
                        return;
                    }
                    string value = dataGridViewRow.Cells[2].Value.ToString();
                    try
                    {
                        IILStubEventFilter filter = filterDef.CreateFilter(operaton, value);
                        listFilter.Add(filter);
                    }
                    catch (FilterOperationIsNullException ex)
                    {
                        MessageBox.Show(String.Format(
                            Resource.ResourceManager.GetString("Wrn_FilterOperationIsNull"), ex.FilterName));
                        return;
                    }
                    catch (FilterOperationNotSupportException ex)
                    {
                        MessageBox.Show(String.Format(
                            Resource.ResourceManager.GetString("Wrn_FilterOperationNotSupport"),
                            ex.Operation, ex.FilterName));
                        return;
                    }
                    catch (FilterValueIsNullException ex)
                    {
                        MessageBox.Show(String.Format(
                            Resource.ResourceManager.GetString("Wrn_FilterValueIsNull"), ex.FilterName));
                        return;
                    }
                    catch (FilterValueNotIntegerException ex)
                    {
                        MessageBox.Show(String.Format(
                            Resource.ResourceManager.GetString("Wrn_FilterValueNotInteger"),
                            ex.Value, ex.FilterName));
                        return;
                    }
                }
                m_filterList = listFilter;
                UpdateFilterMessage();
                UpdateEventList();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UpdateFilterMessage()
        {
            textBoxFilterMessage.Text = m_filterList.Expression;
        }

        private void UpdateEventList()
        {
            ILStubEvent ilStubEventSelected = null;
            if (dataGridViewILStubEvents.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewILStubEvents.SelectedRows[0];
                ilStubEventSelected = selectedRow.DataBoundItem as ILStubEvent;
                selectedRow.Selected = false;
            }
            int newIndexSelected = -1;
            lock (m_viewEventList)
            {
                m_viewEventList.Clear();
                List<ILStubEvent> eventList =
                    ILStubDiagnosticSessionController.GetInstance().Search(m_filterList);
                for (int i = 0; i < eventList.Count; i++)
                {
                    m_viewEventList.Add(eventList[i]);
                    if (ilStubEventSelected != null && ilStubEventSelected == eventList[i])
                    {
                        newIndexSelected = i;
                    }
                }
            }
            if (newIndexSelected != -1)
            {
                dataGridViewILStubEvents.Rows[newIndexSelected].Selected = true;
            }
        }

        private void toolStripMenuItemDeleteFilter_Click(object sender, EventArgs e)
        {
            if (dataGridViewFilter.SelectedRows.Count > 0)
            {
                dataGridViewFilter.Rows.Remove(dataGridViewFilter.SelectedRows[0]);
            }
        }

        private void dataGridViewFilter_MouseDown(object sender, MouseEventArgs e)
        {
            // Clear context menu first.
            dataGridViewFilter.ContextMenuStrip = null;
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = dataGridViewFilter.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.RowHeader)
                {
                    int selectedIndex = hit.RowIndex;
                    if (selectedIndex >= 0)
                    {
                        DataGridViewRow selectedRow = dataGridViewFilter.Rows[selectedIndex];
                        if (!selectedRow.IsNewRow)
                        {
                            dataGridViewFilter.ClearSelection();
                            selectedRow.Selected = true;
                            dataGridViewFilter.ContextMenuStrip = contextMenuStripOnFilterRowHeader;
                        }
                    }
                }
            }
        }

        private void richTextBoxILCode_TextChanged(object sender, EventArgs e)
        {
            richTextBoxILCode.Visible = false;

            SetColoring();
            SetStubHelpersAPIs();

            richTextBoxILCode.DeselectAll();
            richTextBoxILCode.SelectionStart = 0;
            richTextBoxILCode.SelectionLength = 0;

            richTextBoxILCode.Visible = true;
        }

        private void SetStubHelpersAPIs()
        {
            int leftIndex = richTextBoxILCode.Find(StubHelperAPIHeader,
                    0, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
            int rightIndex;
            int textLength = richTextBoxILCode.Text.Length;
            string description;
            while (leftIndex != -1)
            {
                rightIndex = leftIndex + StubHelperAPIHeader.Length;
                while (rightIndex < textLength && IsValidAPISignatureLetter(richTextBoxILCode.Text[rightIndex]))
                    rightIndex++;
                string word = richTextBoxILCode.Text.Substring(leftIndex, rightIndex - leftIndex);
                if (StubHelpersAPIDictionary.GetInstance().TryGetValue(word, out description))
                {
                    richTextBoxILCode.Select(leftIndex, rightIndex - leftIndex);
                    richTextBoxILCode.SelectionFont = StubHelperAPIFont;
                }
                leftIndex = richTextBoxILCode.Find(StubHelperAPIHeader,
                    rightIndex, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
            }
        }

        private static bool IsValidAPISignatureLetter(char p)
        {
            return Char.IsLetterOrDigit(p) || p == '_' || p == '.' || p == ':';
        }

        private void SetColoring()
        {
            // Clear code block first.
            m_codeBlockList = new SortedList<int, ILStubCodeBlock>();

            SetSnippetColor("// Initialize {", "// } Initialize", Color.Brown);
            SetSnippetColor("// Marshal {", "// } Marshal", Color.DarkCyan);
            SetSnippetColor("// CallMethod {", "// } CallMethod", Color.Brown);
            SetSnippetColor("// UnmarshalReturn {", "// } UnmarshalReturn", Color.DarkCyan);
            SetSnippetColor("// Unmarshal {", "// } Unmarshal", Color.DarkCyan);
            SetSnippetColor("// Cleanup {", "// } Cleanup", Color.Green);

            SetSnippetColor("// argument {", "// } argument", Color.Blue);
            SetSnippetColor("// return {", "// } return", Color.Blue);
        }

        private void SetSnippetColor(string start, string end, Color color)
        {
            int firstCharIndex = richTextBoxILCode.Find(start, 0,
                RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
            int lastCharIndex;
            while (firstCharIndex != -1)
            {
                lastCharIndex = richTextBoxILCode.Find(end, firstCharIndex + 1,
                    RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
                if (lastCharIndex == -1)
                {
                    // If we can not find the close comment, that means the close comment is truncate, we
                    // close it at the end of the text.
                    lastCharIndex = richTextBoxILCode.Text.Length - 1;
                }
                else
                {
                    lastCharIndex += end.Length - 1;
                    lastCharIndex = GetLastCharIndexInTheSameLine(richTextBoxILCode, lastCharIndex);
                }
                firstCharIndex = GetFirstCharIndexInTheSameLine(richTextBoxILCode, firstCharIndex);

                m_codeBlockList.Add(firstCharIndex, new ILStubCodeBlock(firstCharIndex, lastCharIndex));
                
                richTextBoxILCode.Select(firstCharIndex, lastCharIndex - firstCharIndex + 1);
                richTextBoxILCode.SelectionColor = color;
                // lastCharIndex may point to the last char in the whole RichTextBox
                firstCharIndex = richTextBoxILCode.Find(start, lastCharIndex,
                    RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
            }
        }

        private static int GetLastCharIndexInTheSameLine(RichTextBox richTextBox, int index)
        {
            int lineNumber = richTextBox.GetLineFromCharIndex(index);
            int firstIndex = richTextBox.GetFirstCharIndexFromLine(lineNumber);
            Point point = richTextBox.GetPositionFromCharIndex(firstIndex);
            point.X = richTextBox.ClientRectangle.Width;
            int lastIndex = richTextBox.GetCharIndexFromPosition(point);
            return lastIndex;
        }

        private static int GetFirstCharIndexInTheSameLine(RichTextBox richTextBox, int index)
        {
            int lineNumber = richTextBox.GetLineFromCharIndex(index);
            return richTextBox.GetFirstCharIndexFromLine(lineNumber);
        }

        private void toolStripButtonNavigationHide_Click(object sender, EventArgs e)
        {
            toolStripNavigation.Hide();
            toolStripButtonFind.Checked = false;
        }

        private void toolStripButtonNextBlock_Click(object sender, EventArgs e)
        {
            toolStripLabelFindRepeat.Image = null;
            toolStripLabelFindRepeat.Text = string.Empty;

            if (m_codeBlockList == null || m_codeBlockList.Count == 0)
                return;
            int index = richTextBoxILCode.SelectionStart;
            IList<int> keyList = m_codeBlockList.Keys;
            for (int i = 0; i < keyList.Count; ++i)
            {
                if (keyList[i] > index)
                {
                    MoveToCodeBlock(richTextBoxILCode, m_codeBlockList[keyList[i]]);
                    return;
                }
            }

            toolStripLabelFindRepeat.Image = m_findRepeatImage;
            toolStripLabelFindRepeat.Text = "Reached end of code";
            MoveToCodeBlock(richTextBoxILCode, m_codeBlockList[keyList[0]]);
        }

        private static void MoveToCodeBlock(RichTextBox richTextBoxILCode, ILStubCodeBlock ilStubCodeBlock)
        {
            richTextBoxILCode.Select(ilStubCodeBlock.FirstCharIndex,
                ilStubCodeBlock.LastCharIndex - ilStubCodeBlock.FirstCharIndex + 1);
            richTextBoxILCode.ScrollToCaret();
        }

        private void toolStripButtonPreviousBlock_Click(object sender, EventArgs e)
        {
            toolStripLabelFindRepeat.Image = null;
            toolStripLabelFindRepeat.Text = string.Empty;

            if (m_codeBlockList == null || m_codeBlockList.Count == 0)
                return;
            int index = richTextBoxILCode.SelectionStart;
            IList<int> keyList = m_codeBlockList.Keys;
            for (int i = keyList.Count - 1; i >= 0; --i)
            {
                if (keyList[i] < index)
                {
                    MoveToCodeBlock(richTextBoxILCode, m_codeBlockList[keyList[i]]);
                    return;
                }
            }

            toolStripLabelFindRepeat.Image = m_findRepeatImage;
            toolStripLabelFindRepeat.Text = "Reached top of code";
            MoveToCodeBlock(richTextBoxILCode, m_codeBlockList[keyList[keyList.Count - 1]]);
        }

        private void toolStripTextBoxFind_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(toolStripTextBoxFind.Text))
            {
                toolStripButtonFindPrevious.Enabled = false;
                toolStripButtonFindNext.Enabled = false;
            }
            else
            {
                toolStripButtonFindPrevious.Enabled = true;
                toolStripButtonFindNext.Enabled = true;
            }
        }

        private void toolStripButtonFindNext_Click(object sender, EventArgs e)
        {
            toolStripLabelFindRepeat.Image = null;
            toolStripLabelFindRepeat.Text = string.Empty;

            if (string.IsNullOrEmpty(toolStripTextBoxFind.Text))
                return;
            int startIndex = richTextBoxILCode.SelectionStart + richTextBoxILCode.SelectionLength;
            int index = richTextBoxILCode.Find(toolStripTextBoxFind.Text,
                startIndex, RichTextBoxFinds.None);
            if (index != -1)
            {
                richTextBoxILCode.Select(index, toolStripTextBoxFind.Text.Length);
            }
            else
            {
                index = richTextBoxILCode.Find(toolStripTextBoxFind.Text,
                    0, RichTextBoxFinds.None);
                if (index != -1)
                {
                    toolStripLabelFindRepeat.Image = m_findRepeatImage;
                    toolStripLabelFindRepeat.Text = "Reached end of code";
                    richTextBoxILCode.Select(index, toolStripTextBoxFind.Text.Length);
                }
                else
                {
                    toolStripLabelFindRepeat.Image = m_findRepeatImage;
                    toolStripLabelFindRepeat.Text = "Phrase not found";
                    richTextBoxILCode.DeselectAll();
                }
            }
        }

        private void toolStripButtonFindPrevious_Click(object sender, EventArgs e)
        {
            toolStripLabelFindRepeat.Image = null;
            toolStripLabelFindRepeat.Text = string.Empty;

            if (string.IsNullOrEmpty(toolStripTextBoxFind.Text))
                return;
            int endIndex = richTextBoxILCode.SelectionStart;
            int index = richTextBoxILCode.Find(toolStripTextBoxFind.Text,
                0, endIndex, RichTextBoxFinds.Reverse);
            if (index != -1)
            {
                richTextBoxILCode.Select(index, toolStripTextBoxFind.Text.Length);
            }
            else
            {
                index = richTextBoxILCode.Find(toolStripTextBoxFind.Text,
                    0, -1, RichTextBoxFinds.Reverse);
                if (index != -1)
                {
                    toolStripLabelFindRepeat.Image = m_findRepeatImage;
                    toolStripLabelFindRepeat.Text = "Reached top of code";
                    richTextBoxILCode.Select(index, toolStripTextBoxFind.Text.Length);
                }
                else
                {
                    toolStripLabelFindRepeat.Image = m_findRepeatImage;
                    toolStripLabelFindRepeat.Text = "Phrase not found";
                    richTextBoxILCode.DeselectAll();
                }
            }
        }

        private void toolStripTextBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonFindNext.PerformClick();
                e.Handled = true;
            }
        }

        private void toolStripButtonCodeModel_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel1Collapsed = toolStripButtonCodeModel.Checked;
            splitContainerILStubEvents.Panel1Collapsed = toolStripButtonCodeModel.Checked;
        }

        private void richTextBoxILCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            toolStripButtonCodeModel.PerformClick();
        }

        private void toolStripButtonZoomIn_Click(object sender, EventArgs e)
        {
            richTextBoxILCode.ZoomFactor *= ZoomFactor;
        }

        private void toolStripButtonZoomOut_Click(object sender, EventArgs e)
        {
            richTextBoxILCode.ZoomFactor /= ZoomFactor;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                toolStripNavigation.Visible = true;
                toolStripButtonFind.Checked = true;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                toolStripNavigation.Hide();
                toolStripButtonFind.Checked = false;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (toolStripButtonFindNext.Enabled)
                {
                    toolStripButtonFindNext.PerformClick();
                }
                e.Handled = true;
            }
        }

        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            toolStripNavigation.Visible = toolStripButtonFind.Checked;
        }

        private void toolStripButtonAPILookup_Click(object sender, EventArgs e)
        {
            StubHelpersApiLookupForm form = new StubHelpersApiLookupForm();
            form.ShowDialog();
        }

        private void dataGridViewILStubEvents_MouseDown(object sender, MouseEventArgs e)
        {
            // Clear context menu first.
            dataGridViewILStubEvents.ContextMenuStrip = null;
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = dataGridViewILStubEvents.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.ColumnHeader)
                {
                    dataGridViewILStubEvents.ContextMenuStrip = contextMenuStripOnEventsColumnHeader;
                }
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            toolStripLabelRunning.PerformClick();
        }

        private void richTextBoxILCode_MouseMove(object sender, MouseEventArgs e)
        {
            int index = richTextBoxILCode.GetCharIndexFromPosition(e.Location);
            if (index < richTextBoxILCode.TextLength)
            {
                int leftIndex = index;
                while (leftIndex >= 0 && IsValidAPISignatureLetter(richTextBoxILCode.Text[leftIndex]))
                    leftIndex--;
                int rightIndex = index;
                while (IsValidAPISignatureLetter(richTextBoxILCode.Text[rightIndex]))
                    rightIndex++;
                if (leftIndex != rightIndex)
                {
                    leftIndex++;
                    string word = richTextBoxILCode.Text.Substring(leftIndex, rightIndex - leftIndex);
                    string description;
                    if (StubHelpersAPIDictionary.GetInstance().TryGetValue(word, out description))
                    {
                        // if the label is already shown on the same API, we do need to update it.
                        if (!labelStubHelperAPI.Visible || labelStubHelperAPI.Text != description)
                        {
                            labelStubHelperAPI.Text = description;
                            labelStubHelperAPI.Location = new Point(e.Location.X, e.Location.Y + 10);
                            labelStubHelperAPI.Visible = true;
                        }
                        return;
                    }
                }
                labelStubHelperAPI.Visible = false;
            }
        }

    }
}
