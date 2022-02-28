# PointerControl
Background app for cursor control hotkeys.

## Controls
* Press **Refresh** to reload hotkeys if they fail to work.
* Press **Quit** to terminate the application (Closing the window minimizes it to tray)
* Context Menu of a tray icon has a **Quit** button aswell.
* Checkbox **Enabled** controls whether the application is active. If it is unchecked, hotkeys won't work.
* Cursor moving is assigned to 4 big buttons for all directions.
* Bottom left button is for sticky mouse down/up toggle.

Single press of a hotkey moves cursor for a single pixel in a given location. Holding the hotkey will repeat movement.  
To press the Left Mouse Button, press the hotkey assigned by bottom-left button. To release it, press again. This event is not repeated.

Default bindings are:
* Up - `Ctrl+NumPad8`
* Down - `Ctrl+NumPad2`
* Left - `Ctrl+NumPad4`
* Right - `Ctrl+NumPad6`
* Mouse Button - `Ctrl+NumPad5`

NumPad bindings only work with NumLock turned on.

Bindings can be changed by pressing the corresponding button on the window. It will display the binding as it changes.
To assign the binding, press `Enter` key or press the button again. `Escape` key press will cancel changes.  
If failed to register hotkey, button will be colored in red.

Hotkeys won't work if currently active window is launched with elevated rights. To fix this, launch this app elevated aswell (Run as administrator).

## Command line
Pass `--hidden` argument to start the program minimezed to tray.

## Settings storage
All keybinds are saved in registry: `HKCU\SOFTWARE\SaVlad\PointerControl`  
Keybinds missing in the registry will revert to default.

## Building
This program is made using **.NET 6.0** and **C# 10.0** on **VisualStudio 2022**.

## What's going on in there
Hotkeys and cursor movement is controlled with Win32 API functions:
* [RegisterHotKey](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerhotkey) and [UnregisterHotKey](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unregisterhotkey) for hotkeys.
* [SetCursorPos](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setcursorpos) and [GetCursorPos](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursorpos) for cursor movement.
* [mouse_event](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mouse_event) for mouse presses.

Source code has more functionality than that (semi-full mouse_event support) because I like translating Win32 API. Most of it is not used.

Besides the main window, anothe hidden window is used for catching hotkey presses, because WinForms has to recreate the window in order to hide it from taskbar and that changes hWnd.

This program does not have a function to make it start with Windows. You'll have to do that yourself.  
What I did is to create a system task that starts specified .exe at LogOn with elevated rights.
