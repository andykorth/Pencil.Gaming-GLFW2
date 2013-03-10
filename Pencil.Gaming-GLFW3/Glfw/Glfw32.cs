using System;
using System.Runtime.InteropServices;

namespace Pencil.Gaming {
    internal static unsafe class Glfw32 {
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwInit();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwTerminate();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwGetVersion(out int major, out int minor, out int rev);
        [DllImport("natives32/glfw.dll")] 
        internal static extern sbyte * glfwGetVersionString();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetErrorCallback(GlfwErrorFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern GlfwMonitorPtr * glfwGetMonitors(out int count);
        [DllImport("natives32/glfw.dll")] 
        internal static extern GlfwMonitorPtr glfwGetPrimaryMonitor();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwGetMonitorPos(GlfwMonitorPtr monitor, out int xpos, out int ypos);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwGetMonitorPhysicalSize(GlfwMonitorPtr monitor, out int width, out int height);
        [DllImport("natives32/glfw.dll")] 
        internal static extern sbyte * glfwGetMonitorName(GlfwMonitorPtr monitor);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetMonitorCallback(GlfwMonitorFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern GlfwVidMode * glfwGetVideoModes(GlfwMonitorPtr monitor, out int count);
        [DllImport("natives32/glfw.dll")] 
        internal static extern GlfwVidMode glfwGetVideoMode(GlfwMonitorPtr monitor);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetGamma(GlfwMonitorPtr monitor, float gamma);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwGetGammaRamp(GlfwMonitorPtr monitor, out GlfwGammaRamp ramp);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetGammaRamp(GlfwMonitorPtr monitor, ref GlfwGammaRamp ramp);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwDefaultWindowHints();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwWindowHint(int target, int hint);
        [DllImport("natives32/glfw.dll")] 
        internal static extern GlfwWindowPtr glfwCreateWindow(int width, int height, [MarshalAs(UnmanagedType.LPStr)] string title, GlfwMonitorPtr monitor, GlfwWindowPtr share);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwDestroyWindow(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwWindowShouldClose(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowShouldClose(GlfwWindowPtr window, int value);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowTitle(GlfwWindowPtr window, [MarshalAs(UnmanagedType.LPStr)] string title);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwGetWindowPos(GlfwWindowPtr window, out int xpos, out int ypos);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowPos(GlfwWindowPtr window, int xpos, int ypos);
        [DllImport("natives32/glfw.dll")]
        internal static extern void glfwGetWindowSize(GlfwWindowPtr window, out int width, out int height);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowSize(GlfwWindowPtr window, int width, int height);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwIconifyWindow(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwRestoreWindow(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwShowWindow(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwHideWindow(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern GlfwMonitorPtr glfwGetWindowMonitor(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwGetWindowParam(GlfwWindowPtr window, int param);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowUserPointer(GlfwWindowPtr window, IntPtr pointer);
        [DllImport("natives32/glfw.dll")] 
        internal static extern IntPtr glfwGetWindowUserPointer(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowPosCallback(GlfwWindowPtr window, GlfwWindowPosFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowSizeCallback(GlfwWindowPtr window, GlfwWindowSizeFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowCloseCallback(GlfwWindowPtr window, GlfwWindowCloseFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowRefreshCallback(GlfwWindowPtr window, GlfwWindowRefreshFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowFocusCallback(GlfwWindowPtr window, GlfwWindowFocusFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetWindowIconifyCallback(GlfwWindowPtr window, GlfwWindowIconifyFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwPollEvents();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwWaitEvents();
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwGetInputMode(GlfwWindowPtr window, InputMode mode);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetInputMode(GlfwWindowPtr window, InputMode mode, CursorMode value);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwGetKey(GlfwWindowPtr window, Key key);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwGetMouseButton(GlfwWindowPtr window, MouseButton button);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwGetCursorPos(GlfwWindowPtr window, out int xpos, out int ypos);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetCursorPos(GlfwWindowPtr window, int xpos, int ypos);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetKeyCallback(GlfwWindowPtr window, GlfwKeyFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetCharCallback(GlfwWindowPtr window, GlfwCharFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetMouseButtonCallback(GlfwWindowPtr window, GlfwMouseButtonFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetCursorPosCallback(GlfwWindowPtr window, GlfwCursorPosFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetCursorEnterCallback(GlfwWindowPtr window, GlfwCursorEnterFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetScrollCallback(GlfwWindowPtr window, GlfwScrollFun cbfun);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwGetJoystickParam(Joystick joy, JoystickParam param);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwGetJoystickAxes(Joystick joy, [MarshalAs(UnmanagedType.LPArray)] float[] axes, int numaxes);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwGetJoystickButtons(Joystick joy, [MarshalAs(UnmanagedType.LPArray)] byte[] buttons, int numbuttons);
        [DllImport("natives32/glfw.dll")] 
        internal static extern sbyte * glfwGetJoystickName(Joystick joy);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetClipboardString(GlfwWindowPtr window, [MarshalAs(UnmanagedType.LPStr)] string @string);
        [DllImport("natives32/glfw.dll")] 
        internal static extern sbyte * glfwGetClipboardString(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern double glfwGetTime();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSetTime(double time);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwMakeContextCurrent(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern GlfwWindowPtr glfwGetCurrentContext();
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSwapBuffers(GlfwWindowPtr window);
        [DllImport("natives32/glfw.dll")] 
        internal static extern void glfwSwapInterval(int interval);
        [DllImport("natives32/glfw.dll")] 
        internal static extern int glfwExtensionSupported([MarshalAs(UnmanagedType.LPStr)] string extension);
        [DllImport("natives32/glfw.dll")] 
        internal static extern IntPtr glfwGetProcAddress([MarshalAs(UnmanagedType.LPStr)] string procname);
    }
}

