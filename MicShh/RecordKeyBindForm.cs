using GlobalHotKeys.Native.Types;

namespace MicShh
{
    public partial class RecordKeyBindForm : Form
    {
        private bool _isRecording;
        private VirtualKeyCode _beforeRecordVirtualKeyCodeValue;
        private Modifiers _beforeRecordModifiersValue;
        private List<string> _beforeRecordVirtualKeyCodeList = new();
        private List<string> _beforeRecordModifiersList = new();
        private string _beforeRecordLabelString = string.Empty;
        private const string _recordingString = "Confirm";
        private const string _notRecordingString = "Record";
        private readonly VirtualKeyCode _loadedVirtualKeyCode;
        private readonly Modifiers _loadedModifiers;

        public List<string> ModifierList { get; set; } = new();
        public List<string> VirtualKeyCodeList { get; set; } = new();
        public Modifiers NewModifiers { get; private set; }
        public VirtualKeyCode NewVirtualKeyCode { get; private set; }

        public RecordKeyBindForm(VirtualKeyCode loadedVirtualKeyCode, Modifiers loadedModifiers, string currentKeyBind)
        {
            InitializeComponent();

            RecordButton.Enabled = true;
            RecordButton.Text = _notRecordingString;
            CancelRecordingButton.Visible = false;
            _loadedVirtualKeyCode = loadedVirtualKeyCode;
            _loadedModifiers = loadedModifiers;
            KeyBindLabel.Text = currentKeyBind;
            OkButton.Enabled = false;

            NewModifiers = _loadedModifiers;
            NewVirtualKeyCode = _loadedVirtualKeyCode;
        }

        private void RecordKeyBindForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(_isRecording)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if(e.Alt || e.Control || e.Shift || e.KeyData == Keys.LWin || e.KeyData == Keys.RWin)
                {
                    if(e.Alt && !NewModifiers.HasFlag(Modifiers.Alt))
                    {
                        NewModifiers |= Modifiers.Alt;
                        ModifierList.Add(Modifiers.Alt.ToString());
                    }
                    if(e.Control && !NewModifiers.HasFlag(Modifiers.Control))
                    {
                        NewModifiers |= Modifiers.Control;
                        ModifierList.Add(Modifiers.Control.ToString());

                    }
                    if (e.Shift && !NewModifiers.HasFlag(Modifiers.Shift))
                    {
                        NewModifiers |= Modifiers.Shift;
                        ModifierList.Add(Modifiers.Shift.ToString());
                    }
                    if ((e.KeyData == Keys.LWin || e.KeyData == Keys.RWin) 
                        && !NewModifiers.HasFlag(Modifiers.Win))
                    {
                        NewModifiers |= Modifiers.Win;
                        ModifierList.Add(Modifiers.Win.ToString());
                    }
                }
                else
                {
                    var intKeyCode = Convert.ToInt32(e.KeyCode);
                    NewVirtualKeyCode = (VirtualKeyCode)intKeyCode;
                    var keyCode = (VirtualKeyCode)intKeyCode;
                    VirtualKeyCodeList.Add(keyCode.ToString());
                    _isRecording = false;
                    RecordButton.Text = _notRecordingString;
                    CancelRecordingButton.Visible = false;
                    OkButton.Enabled = true;
                    CancelButton.Enabled = true;
                }

                KeyBindLabel.Text = Helpers.GetCurrentKeyBindString(ModifierList, VirtualKeyCodeList);
            }

            OkButton.Enabled = _loadedModifiers != NewModifiers || _loadedVirtualKeyCode != NewVirtualKeyCode;
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            ModifierList.Clear();
            VirtualKeyCodeList.Clear();

            _beforeRecordVirtualKeyCodeValue = NewVirtualKeyCode;
            _beforeRecordModifiersValue = NewModifiers;
            _beforeRecordVirtualKeyCodeList = VirtualKeyCodeList;
            _beforeRecordModifiersList = ModifierList;
            _beforeRecordLabelString = KeyBindLabel.Text;

            if (sender is Button button)
            {
                if (!_isRecording)
                {
                    KeyBindLabel.Text = string.Empty;
                    _isRecording = true;
                    button.Text = _recordingString;
                    CancelRecordingButton.Visible = true;
                    OkButton.Enabled = false;
                    CancelButton.Enabled = false;
                    NewModifiers = 0;
                    NewVirtualKeyCode = 0;
                    ModifierList.ToList().Clear();
                }
                else
                {
                    _isRecording = false;
                    button.Text = _notRecordingString;
                    CancelRecordingButton.Visible = false;
                    OkButton.Enabled = true;
                    CancelButton.Enabled = true;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            NewModifiers = _loadedModifiers;
            NewVirtualKeyCode = _loadedVirtualKeyCode;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelRecordingButton_Click(object sender, EventArgs e)
        {
            NewVirtualKeyCode = _beforeRecordVirtualKeyCodeValue;
            NewModifiers = _beforeRecordModifiersValue;
            VirtualKeyCodeList = _beforeRecordVirtualKeyCodeList;
            ModifierList = _beforeRecordModifiersList;
            KeyBindLabel.Text = _beforeRecordLabelString;

            _isRecording = false;
            RecordButton.Text = _notRecordingString;
            CancelRecordingButton.Visible = false;
            OkButton.Enabled = _loadedModifiers != NewModifiers || _loadedVirtualKeyCode != NewVirtualKeyCode;
            CancelButton.Enabled = true;
        }
    }
}
