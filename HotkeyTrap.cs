namespace PointerControl {
	public class HotkeyTrap : Form {
		public event Action<int>? OnHotkey;

		public HotkeyTrap() {
			ShowInTaskbar = false;
			Text = "Pointer Control Hotkey Trap";
			Hide();
		}

		protected override void WndProc(ref Message m) {
			base.WndProc(ref m);
			if (m.Msg == Win32.WM_HOTKEY) OnHotkey?.Invoke(m.WParam.ToInt32());
		}
	}
}
