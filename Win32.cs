using System.Runtime.InteropServices;

namespace PointerControl {
	public static class Win32 {
		// DWORD = uint   (U32)
		// WORD  = ushort (U16)
		// LONG  = int    (S32)

		public const int WM_HOTKEY = 0x0312;
		public const uint MOD_ALT = 0x0001;
		public const uint MOD_CONTROL = 0x0002;
		public const uint MOD_NOREPEAT = 0x4000;
		public const uint MOD_SHIFT = 0x0004;
		public const uint MOD_WIN = 0x0008;
		private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
		private const uint MOUSEEVENTF_LEFTUP = 0x0004;
		private const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
		private const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
		private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
		private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
		private const uint MOUSEEVENTF_XDOWN = 0x0080;
		private const uint MOUSEEVENTF_XUP = 0x0100;
		private const uint XBUTTON1 = 0x0001;
		private const uint XBUTTON2 = 0x0002;
		private const uint INPUT_MOUSE = 0;
		private const uint INPUT_KEYBOARD = 1;
		private const uint INPUT_HARDWARE = 2;

		[StructLayout(LayoutKind.Sequential)]
		private struct Point {
			public int x, y;
		}
		[StructLayout(LayoutKind.Explicit)]
		private struct Input {
			[FieldOffset(0)]
			public uint type;
			[FieldOffset(4)]
			public MouseInput mi;
			[FieldOffset(4)]
			public KeybdInput ki;
			[FieldOffset(4)]
			public HardwareInput hi;
		}
		[StructLayout(LayoutKind.Sequential)]
		private struct MouseInput {
			public int dx, dy;
			public uint mouseData, dwFlags, time;
			public IntPtr dwExtraInfo;
		}
		[StructLayout(LayoutKind.Sequential)]
		private struct KeybdInput {
			public ushort wVk, wScan;
			public uint dwFlags, time;
			public IntPtr dwExtraInfo;
		}
		[StructLayout(LayoutKind.Sequential)]
		private struct HardwareInput {
			public uint uMsg;
			public ushort wParamL, wParamH;
		}

		private static int nextId = 1;

		[DllImport("user32")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
		public static int RegisterHotKey(IntPtr hWnd, ModKeys modifiers, Keys vk) {
			int id = nextId++;
			if (!RegisterHotKey(hWnd, id, (uint)modifiers, (uint)vk)) return 0;
			// if (!RegisterHotKey(IntPtr.Zero, id, (uint)modifiers, (uint)vk)) return 0;
			return id;
		}

		[DllImport("user32")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
		public static bool UnRegisterHotKey(IntPtr hwnd, int id) {
			return UnregisterHotKey(hwnd, id);
		}

		[DllImport("user32")]
		public static extern bool SetCursorPos(int x, int y);
		public static bool SetCursorPos(System.Drawing.Point point) {
			return SetCursorPos(point.X, point.Y);
		}
		[DllImport("user32")]
		private static extern bool GetCursorPos(out Point point);
		public static System.Drawing.Point GetCursorPos() {
			GetCursorPos(out Point pt);
			return new(pt.x, pt.y);
		}

		[DllImport("user32")]
		private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
		public static void SetMouseButton(MouseButton button, bool down) {
			uint dwFlags = 0;
			if (button.HasFlag(MouseButton.Left))
				dwFlags |= down ? MOUSEEVENTF_LEFTDOWN : MOUSEEVENTF_LEFTUP;
			if (button.HasFlag(MouseButton.Middle))
				dwFlags |= down ? MOUSEEVENTF_MIDDLEDOWN : MOUSEEVENTF_MIDDLEUP;
			if (button.HasFlag(MouseButton.Right))
				dwFlags |= down ? MOUSEEVENTF_RIGHTDOWN : MOUSEEVENTF_RIGHTUP;
			if (button.HasFlag(MouseButton.XButton1) || button.HasFlag(MouseButton.XButton2))
				dwFlags |= down ? MOUSEEVENTF_XDOWN : MOUSEEVENTF_XUP;

			uint dwData = 0;
			if (button.HasFlag(MouseButton.XButton1))
				dwData |= XBUTTON1;
			if (button.HasFlag(MouseButton.XButton2))
				dwData |= XBUTTON2;

			mouse_event((int)dwFlags, 0, 0, (int)dwData, 0);
		}
	}
}
