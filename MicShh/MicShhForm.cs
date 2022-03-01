using GlobalHotKeys;
using GlobalHotKeys.Native.Types;
using NAudio.CoreAudioApi;
using System.Media;

namespace MicShh
{
    public partial class MicShhForm : Form
    {
        private bool _allowVisible;
        private bool _allowClose;
        private string _currentKeyBindString = string.Empty;
        private HotKeyManager _hotKeyManager;
        private readonly string _loadedKeyBindLabel;
        private readonly IEnumerable<string> _defaultKeys;
        private readonly IEnumerable<string> _defaultModfiers;
        private readonly string _defaultKeyBindString;

        public VirtualKeyCode VirtualKeyCodeFlags { get; private set; }
        public Modifiers ModifierFlags { get; private set; }

        public MicShhForm()
        {
            InitializeComponent();
            PopulateDeviceList();

            _loadedKeyBindLabel = CurrentKeyBindLabel.Text;

            _defaultKeys = Properties.Settings.Default.KeyBindSettings__DefaultKeyBind__Keys.Cast<string>();
            _defaultModfiers = Properties.Settings.Default.KeyBindSettings__DefaultKeyBind__Modifiers.Cast<string>();
            _defaultKeyBindString = Helpers.GetCurrentKeyBindString(_defaultModfiers, _defaultKeys);

            var userKeys = Properties.Settings.Default.KeyBindSettings__UserKeyBind__Keys?.Cast<string>();
            var userModfiers = Properties.Settings.Default.KeyBindSettings__UserKeyBind__Modifiers?.Cast<string>();

            if(userKeys?.Count() > 0 && userModfiers?.Count() > 0)
            {
                VirtualKeyCodeFlags = GetKeyCombos<VirtualKeyCode>(userKeys);
                ModifierFlags = GetKeyCombos<Modifiers>(userModfiers);
                _currentKeyBindString = Helpers.GetCurrentKeyBindString(userModfiers, userKeys);

                if (_defaultKeys.OrderBy(x => x).SequenceEqual(userKeys.OrderBy(x => x)) &&
                    _defaultModfiers.OrderBy(x => x).SequenceEqual(userModfiers.OrderBy(x => x)))
                {
                    DefaultButton.Enabled = false;
                }
                else
                {
                    DefaultButton.Enabled = true;
                }
            }
            else
            {
                VirtualKeyCodeFlags = GetKeyCombos<VirtualKeyCode>(_defaultKeys);
                ModifierFlags = GetKeyCombos<Modifiers>(_defaultModfiers);
                DefaultButton.Enabled = false;
                _currentKeyBindString = _defaultKeyBindString;
            }

            _hotKeyManager = new HotKeyManager();
            var subscription = _hotKeyManager.HotKeyPressed.Subscribe(HotKeyPressed);
            var registration = _hotKeyManager.Register(VirtualKeyCodeFlags, ModifierFlags);

            CurrentKeyBindLabel.Text = CurrentKeyBindLabel.Text + _currentKeyBindString;

            UseSoundCheckBox.Checked = Properties.Settings.Default.UseSound;
        }

        private void HotKeyPressed(HotKey hotKey)
        {
            Properties.Settings.Default.CurrentStateIsMuted = !Properties.Settings.Default.CurrentStateIsMuted;
            Properties.Settings.Default.Save();

            var deviceEnumerator = new MMDeviceEnumerator();

            var devices = deviceEnumerator
                .EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            foreach (var device in devices.Where(x => Properties.Settings.Default.SelectedDevices.Contains(x.DeviceFriendlyName)))
            {
                using (device)
                {
                    var volume = device.AudioEndpointVolume;

                    if (!Properties.Settings.Default.CurrentStateIsMuted)
                    {
                        volume.Mute = false;
                    }
                    else
                    {
                        volume.Mute = true;
                    }
                }
            }

            if (Properties.Settings.Default.UseSound)
            {
                if (!Properties.Settings.Default.CurrentStateIsMuted)
                {
                    using var soundPlayer = new SoundPlayer(Properties.Resources.unmute);
                    soundPlayer.Play();
                }
                else
                {
                    using var soundPlayer = new SoundPlayer(Properties.Resources.mute);
                    soundPlayer.Play();
                }
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!_allowVisible)
            {
                value = false;
                if (!IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose)
            {
                Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowVisible = true;
            Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowClose = true;
            Application.Exit();
            System.Environment.Exit(0);
        }

        private void MicShhForm_Leave(object sender, EventArgs e)
        {
            _allowClose = true;
            Close();
        }

        private void PopulateDeviceList()
        {
            var buttonDefaultText = RefereshDevicesButton.Text;

            var defaultButtonOriginalValue = DefaultButton.Enabled;

            try
            {
                DefaultButton.Enabled = false;
                DefaultButton.PerformLayout();
                DefaultButton.Refresh();
                RecordKeyBindButton.Enabled = false;
                RecordKeyBindButton.PerformLayout();
                RecordKeyBindButton.Refresh();
                UseSoundCheckBox.Enabled = false;
                UseSoundCheckBox.PerformLayout();
                UseSoundCheckBox.Refresh();
                AudioDevicesListView.Enabled = false;
                AudioDevicesListView.Items.Clear();
                AudioDevicesListView.PerformLayout();
                AudioDevicesListView.Refresh();
                RefereshDevicesButton.Enabled = false;
                RefereshDevicesButton.Text = "Refreshing...";
                RefereshDevicesButton.PerformLayout();
                RefereshDevicesButton.Refresh();

                var deviceEnumerator = new MMDeviceEnumerator();
                var devices = deviceEnumerator
                    .EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

                foreach (var device in devices)
                {
                    var listViewItem = new ListViewItem
                    {
                        Text = device.DeviceFriendlyName,
                        Name = device.DeviceFriendlyName,
                        Tag = device
                    };

                    if (Properties.Settings.Default.SelectedDevices != null && 
                        Properties.Settings.Default.SelectedDevices.Contains(device.DeviceFriendlyName))
                    {
                        listViewItem.Checked = true;
                    }

                    AudioDevicesListView.Items.Add(listViewItem);
                }

                var checkedItems = AudioDevicesListView.CheckedItems.Cast<List<ListViewItem>>();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RefereshDevicesButton.Text = buttonDefaultText;
                RefereshDevicesButton.Enabled = true; 
                AudioDevicesListView.Enabled = true;
                UseSoundCheckBox.Enabled = true;
                RecordKeyBindButton.Enabled = true;
                DefaultButton.Enabled = defaultButtonOriginalValue;
            }
        }

        private void RefereshDevicesButton_Click(object sender, EventArgs e)
        {
            PopulateDeviceList();
        }

        public static T GetKeyCombos<T>(IEnumerable<string> keyValues) where T : struct, Enum
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            var values =
                (T)(object)keyValues
                    .Select(x =>
                    {
                        Enum.TryParse(x, true, out T resultInputType);
                        return resultInputType;
                    })
                    .Cast<int>()
                    .Aggregate((prev, next) => prev | next);

            return values;
        }

        private void AudioDevicesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if(e.Item.Checked && !Properties.Settings.Default.SelectedDevices.Contains(e.Item.Text))
            {
                Properties.Settings.Default.SelectedDevices.Add(e.Item.Text);
                Properties.Settings.Default.Save();
                return;
            }

            if(!e.Item.Checked && Properties.Settings.Default.SelectedDevices.Contains(e.Item.Text))
            {
                Properties.Settings.Default.SelectedDevices.Remove(e.Item.Text);
                Properties.Settings.Default.Save();
            }
        }

        private void UseSoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                Properties.Settings.Default.UseSound = checkBox.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void RecordKeyBindButton_Click(object sender, EventArgs e)
        {
            var recordKeyBindForm = new RecordKeyBindForm(VirtualKeyCodeFlags, ModifierFlags, _currentKeyBindString);
            recordKeyBindForm.ShowDialog(this);

            if (recordKeyBindForm.DialogResult == DialogResult.Cancel) return;

            VirtualKeyCodeFlags = recordKeyBindForm.NewVirtualKeyCode;
            ModifierFlags = recordKeyBindForm.NewModifiers;

            _currentKeyBindString = Helpers.GetCurrentKeyBindString(recordKeyBindForm.ModifierList, recordKeyBindForm.VirtualKeyCodeList);

            if(_defaultKeys.OrderBy(x => x).SequenceEqual(recordKeyBindForm.VirtualKeyCodeList.OrderBy(x => x)) && 
                _defaultModfiers.OrderBy(x => x).SequenceEqual(recordKeyBindForm.ModifierList.OrderBy(x => x)))
            {
                DefaultButton.Enabled = false;
            }
            else
            {
                DefaultButton.Enabled = true;
            }

            _hotKeyManager.Dispose();
            GC.Collect();
            _hotKeyManager = new HotKeyManager();
            var subscription = _hotKeyManager.HotKeyPressed.Subscribe(HotKeyPressed);
            var registration = _hotKeyManager.Register(VirtualKeyCodeFlags, ModifierFlags);

            Properties.Settings.Default.KeyBindSettings__UserKeyBind__Keys.Clear();
            Properties.Settings.Default.KeyBindSettings__UserKeyBind__Keys.AddRange(recordKeyBindForm.VirtualKeyCodeList.ToArray());
            Properties.Settings.Default.KeyBindSettings__UserKeyBind__Modifiers.Clear();
            Properties.Settings.Default.KeyBindSettings__UserKeyBind__Modifiers.AddRange(recordKeyBindForm.ModifierList.ToArray());

            Properties.Settings.Default.Save();

            CurrentKeyBindLabel.Text = _loadedKeyBindLabel + _currentKeyBindString;
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Are you sure you want to reset the Key Bind value back to the default value of '{_defaultKeyBindString}'?", 
                "Reset to default", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            VirtualKeyCodeFlags = GetKeyCombos<VirtualKeyCode>(_defaultKeys);
            ModifierFlags = GetKeyCombos<Modifiers>(_defaultModfiers);

            _currentKeyBindString = _defaultKeyBindString;

            _hotKeyManager.Dispose();
            GC.Collect();
            _hotKeyManager = new HotKeyManager();
            var subscription = _hotKeyManager.HotKeyPressed.Subscribe(HotKeyPressed);
            var registration = _hotKeyManager.Register(VirtualKeyCodeFlags, ModifierFlags);

            Properties.Settings.Default.KeyBindSettings__UserKeyBind__Keys.Clear();
            Properties.Settings.Default.KeyBindSettings__UserKeyBind__Modifiers.Clear();
            Properties.Settings.Default.Save();

            CurrentKeyBindLabel.Text = _loadedKeyBindLabel + _currentKeyBindString;

            DefaultButton.Enabled = false;
        }
    }
}