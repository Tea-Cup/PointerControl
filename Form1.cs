using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace PointerControl {
	public partial class Form1 : Form {
		private Keybind kbUp, kbDown, kbLeft, kbRight, kbMouse;
		private Keybind? kbEdit = null;
		private Button? bEdit = null;
		private HotkeyTrap trap;
		private bool init = true;

		public Form1() {
			InitializeComponent();
			Application.ApplicationExit += OnApplicationExit;
			trap = new();
			trap.OnHotkey += OnHotkey;
			ButtonBindings b = LoadButtons();
			bUp.Text = (bUp.Tag = kbUp = Keybind.Parse(trap.Handle, b.Up)).ToString();
			bDown.Text = (bDown.Tag = kbDown = Keybind.Parse(trap.Handle, b.Down)).ToString();
			bLeft.Text = (bLeft.Tag = kbLeft = Keybind.Parse(trap.Handle, b.Left)).ToString();
			bRight.Text = (bRight.Tag = kbRight = Keybind.Parse(trap.Handle, b.Right)).ToString();
			bMouse.Text = (bMouse.Tag = kbMouse = Keybind.Parse(trap.Handle, b.Mouse)).ToString();
			SetEnabled(true);
		}

		private void OnHotkey(int id) {
			if (id == kbMouse.HotKeyId) {
				Win32.SetMouseButton(MouseButton.Left, !MouseButtons.HasFlag(MouseButtons.Left));
				return;
			}
			(int x, int y) = (0, 0);
			if (id == kbUp.HotKeyId) (x, y) = (0, -1);
			else if (id == kbDown.HotKeyId) (x, y) = (0, 1);
			else if (id == kbLeft.HotKeyId) (x, y) = (-1, 0);
			else if (id == kbRight.HotKeyId) (x, y) = (1, 0);
			Win32.SetCursorPos(Win32.GetCursorPos() + new Size(x, y));
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			if (init && Environment.CommandLine.Contains("--hidden")) {
				Close();
			}
			init = false;
		}

		protected override void OnClosing(CancelEventArgs e) {
			ShowInTaskbar = false;
			Hide();
			e.Cancel = true;
			base.OnClosing(e);
		}

		protected override void OnDeactivate(EventArgs e) {
			base.OnDeactivate(e);
			OnLostFocus(this, e);
		}

		private void SetEnabled(bool state) {
			if (state) {
				RegisterButton(bUp);
				RegisterButton(bDown);
				RegisterButton(bLeft);
				RegisterButton(bRight);
				RegisterButton(bMouse);
			} else {
				kbUp.Unregister();
				kbDown.Unregister();
				kbLeft.Unregister();
				kbRight.Unregister();
				kbMouse.Unregister();
			}
			bRefresh.Enabled = state;
			bUp.Enabled = state;
			bLeft.Enabled = state;
			bRight.Enabled = state;
			bDown.Enabled = state;
			bMouse.Enabled = state;
			cbEnabled.Checked = state;
		}

		private void RegisterButton(Button b) {
			Keybind kb = (Keybind)b.Tag;
			if (kb.Register()) {
				b.BackColor = SystemColors.Control;
				b.ForeColor = SystemColors.ControlText;
			} else {
				b.BackColor = Color.Red;
				b.ForeColor = Color.White;
			}
		}

		private void StartEdit(Button button) {
			if (bEdit == button) {
				StopEdit();
				return;
			}
			bUp.Enabled = false;
			bLeft.Enabled = false;
			bRight.Enabled = false;
			bDown.Enabled = false;
			bMouse.Enabled = false;

			button.Enabled = true;
			button.Text = "...";
			button.BackColor = SystemColors.Control;
			button.ForeColor = SystemColors.ControlText;
			button.Focus();
			Keybind kb = (Keybind)button.Tag;
			kbEdit = new(kb);
			kb.Unregister();
			bEdit = button;
		}
		private void CancelEdit() {
			if (bEdit is not null) {
				RegisterButton(bEdit);
				bEdit.Text = bEdit.Tag.ToString();
			}
			bUp.Enabled = true;
			bLeft.Enabled = true;
			bRight.Enabled = true;
			bDown.Enabled = true;
			bMouse.Enabled = true;
			kbEdit = null;
			bEdit = null;
		}
		private void StopEdit() {
			if (bEdit is not null) {
				Debug.Assert(kbEdit is not null);
				Keybind kb = (Keybind)bEdit.Tag;
				kb.Key = kbEdit.Key;
				kb.Modifiers = kbEdit.Modifiers;
				bEdit.Text = kb.ToString();
				SaveButtons(new(
					kbUp.ToString(),
					kbDown.ToString(),
					kbLeft.ToString(),
					kbRight.ToString(),
					kbMouse.ToString()
				));
			}
			CancelEdit();
		}

		private ButtonBindings LoadButtons() {
			RegistryKey? root = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SaVlad\PointerControl", RegistryKeyPermissionCheck.ReadSubTree);
			if (root is null) return ButtonBindings.Default;
			string up = (string)root.GetValue("up", ButtonBindings.Default.Up)!;
			string down = (string)root.GetValue("down", ButtonBindings.Default.Down)!;
			string left = (string)root.GetValue("left", ButtonBindings.Default.Left)!;
			string right = (string)root.GetValue("right", ButtonBindings.Default.Right)!;
			string mouse = (string)root.GetValue("mouse", ButtonBindings.Default.Mouse)!;
			return new(up, down, left, right, mouse);
		}
		private void SaveButtons(ButtonBindings b) {
			RegistryKey? root = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SaVlad\PointerControl", RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (root is null) root = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SaVlad\PointerControl");
			root.SetValue("up", b.Up);
			root.SetValue("down", b.Down);
			root.SetValue("left", b.Left);
			root.SetValue("right", b.Right);
			root.SetValue("mouse", b.Mouse);
		}

		private void OnLostFocus(object sender, EventArgs e) {
			if (sender is Form) CancelEdit();
			else StopEdit();
		}

		private void OnKeyDown(object sender, KeyEventArgs e) {
			if (sender != bEdit) return;

			if (e.KeyCode == Keys.Enter) {
				StopEdit();
				e.SuppressKeyPress = true;
				return;
			}
			if (e.KeyCode == Keys.Escape) {
				CancelEdit();
				e.SuppressKeyPress = true;
				return;
			}
			if (Keybind.InvalidKeys.Contains(e.KeyCode)) return;

			Debug.Assert(kbEdit is not null);
			kbEdit.Key = e.KeyCode;
			kbEdit.Modifiers = 0;
			if (e.Control) kbEdit.Modifiers |= ModKeys.Control;
			if (e.Shift) kbEdit.Modifiers |= ModKeys.Shift;
			if (e.Alt) kbEdit.Modifiers |= ModKeys.Alt;
			bEdit.Text = kbEdit.ToString();
		}

		private void IconDoubleClick(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) return;
			Show();
			ShowInTaskbar = true;
		}

		private void MenuCloseClick(object sender, EventArgs e) {
			Application.Exit();
		}

		private void OnRefreshClick(object sender, EventArgs e) {
			RegisterButton(bUp);
			RegisterButton(bDown);
			RegisterButton(bLeft);
			RegisterButton(bRight);
			RegisterButton(bMouse);
		}

		private void OnQuitClick(object sender, EventArgs e) {
			MenuCloseClick(this, e);
		}

		private void OnButtonClick(object sender, EventArgs e) {
			StartEdit((Button)sender);
		}

		private void OnEnabledChanged(object sender, EventArgs e) {
			SetEnabled(cbEnabled.Checked);
		}

		private void OnApplicationExit(object? sender, EventArgs e) {
			SetEnabled(false);
			trap.Close();
		}

		private record ButtonBindings(string Up, string Down, string Left, string Right, string Mouse) {
			public static ButtonBindings Default { get; } = new(
				"Ctrl+NumPad8",
				"Ctrl+NumPad2",
				"Ctrl+NumPad4",
				"Ctrl+NumPad6",
				"Ctrl+NumPad5"
			);
		}
	}
}