using System.Diagnostics;
using System.Text;

namespace PointerControl {
	public class Keybind {
		public static IEnumerable<Keys> InvalidKeys { get; } = new Keys[] {
			Keys.None,
			Keys.ControlKey, Keys.LControlKey, Keys.RControlKey,
			Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey,
			Keys.Menu, Keys.LMenu, Keys.RMenu,
			Keys.LWin, Keys.RWin
		};

		public IntPtr WindowHandle { get; set; }
		public ModKeys Modifiers { get; set; }
		public Keys Key { get; set; }
		public int HotKeyId { get; private set; }
		public bool IsRegistered => HotKeyId != 0;

		public Keybind(Keybind bind) : this(bind.WindowHandle, bind.Modifiers, bind.Key) { }
		public Keybind(IntPtr window, ModKeys modifiers, Keys key) {
			(WindowHandle, Modifiers, Key) = (window, modifiers, key);
		}

		public bool Register() {
			if (IsRegistered) Unregister();
			HotKeyId = Win32.RegisterHotKey(WindowHandle, Modifiers, Key);
			Debug.WriteLine($"Registered {this}: {HotKeyId}");
			return IsRegistered;
		}
		public bool Unregister() {
			if (!IsRegistered) return true;
			int id = HotKeyId;
			HotKeyId = 0;
			bool result = Win32.UnRegisterHotKey(WindowHandle, id);
			Debug.WriteLine($"Unregistered {this}: {result}");
			return result;
		}

		public static Keybind Parse(IntPtr window, string s) {
			ModKeys mods = 0;
			Keys key = 0;
			string[] split = s.Split('+');
			foreach (string str in split) {
				if (str == "Ctrl") mods |= ModKeys.Control;
				else if (str == "Shift") mods |= ModKeys.Shift;
				else if (str == "Alt") mods |= ModKeys.Alt;
				else if (str == "Win") mods |= ModKeys.Win;
				else key = Enum.Parse<Keys>(str);
			}
			return new(window, mods, key);
		}

		public override string ToString() {
			if (Modifiers == 0) return Key.ToString();
			StringBuilder sb = new();
			if (Modifiers.HasFlag(ModKeys.Control)) sb.Append("Ctrl+");
			if (Modifiers.HasFlag(ModKeys.Shift)) sb.Append("Shift+");
			if (Modifiers.HasFlag(ModKeys.Alt)) sb.Append("Alt+");
			if (Modifiers.HasFlag(ModKeys.Win)) sb.Append("Win+");
			sb.Append(Key.ToString());
			return sb.ToString();
		}
	}
}
