namespace PointerControl {
	[Flags]
	public enum ModKeys : uint {
		Alt = Win32.MOD_ALT,
		Control = Win32.MOD_CONTROL,
		NoRepeat = Win32.MOD_NOREPEAT,
		Shift = Win32.MOD_SHIFT,
		Win = Win32.MOD_WIN
	}
}
