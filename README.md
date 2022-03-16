# Better Virtual Desktops

Pretty simple. 

- Registers two hotkeys, `Control + Win + UpArrow`, `Control + Win + DownArrow` which will round-robin cycle through desktops with the numbers going in the direction of the arrow key pressed. Can be bound to CapsLock hyperkeys or mouse buttons.
- If your mouse is down (i.e., you're dragging a window) the window will be seamlessly transported to the new desktop, letting you drag windows between desktops without the task switcher.

Uses C# native bindings for the [Windows 11 Virtual Desktop API from @MScholtes](https://github.com/MScholtes/VirtualDesktop). This is an undocumented API, so it can break at any point in the future.

You should be able to swap out the `VirtualDesktop.cs` for the Windows 10 version, and I have a branch/release with this version of the library, but I'm on Windows 11 so I cannot test it. Should work fine though.
