﻿Option Strict On

Imports System.Runtime.InteropServices
Imports System.Text

Public Class Win32

    <DllImport("user32.dll")>
    Public Shared Function ShowWindow(hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> nCmdShow As ShowWindowCommands) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInt32) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetClassName(ByVal hWnd As System.IntPtr, ByVal lpClassName As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Boolean
    End Function

    <DllImport("User32.dll")>
    Public Shared Function EnumChildWindows(ByVal WindowHandle As IntPtr, ByVal Callback As EnumWindowProcess, ByVal lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SetWindowCompositionAttribute(ByVal hwnd As IntPtr, ByRef data As WindowCompositionAttributeData) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function FindWindowEx(ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, ByVal lclassName As String, ByVal windowTitle As String) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)>
    Public Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetClientRect(ByVal hWnd As System.IntPtr, ByRef lpRECT As RECT) As Integer
    End Function

    <DllImport("user32.dll")>
    Shared Function SetWindowRgn(ByVal hWnd As IntPtr, ByVal hRgn As IntPtr, ByVal bRedraw As Boolean) As Integer
    End Function

    <DllImport("user32.dll")>
    Shared Function GetWindowRgn(ByVal hWnd As IntPtr, ByVal hRgn As IntPtr) As Integer
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function CreateRoundRectRgn(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal w As Integer, ByVal h As Integer) As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function CreateRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer) As IntPtr
    End Function


    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function MonitorFromWindow(ByVal hwnd As IntPtr, ByVal dwFlags As UInteger) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetMonitorInfo(ByVal hMonitor As IntPtr, ByRef lpmi As MONITORINFO) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("SHCore.dll", SetLastError:=True)>
    Public Shared Function SetProcessDpiAwareness(ByVal awareness As PROCESS_DPI_AWARENESS) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="FindWindow", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Public Shared Function FindWindowByClass(ByVal lpClassName As String, ByVal zero As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Boolean, ByVal lParam As Int32) As Integer
    End Function

    <DllImport("kernel32.dll")>
    Public Shared Function SetProcessWorkingSetSize(ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Int32, ByVal dwMaximumWorkingSetSize As Int32) As Int32
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SetWindowLong")>
    Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> nIndex As WindowStyles, ByVal dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function AllocConsole() As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=False)>
    Public Shared Function GetDesktopWindow() As IntPtr
    End Function

    <DllImport("dwmapi.dll")>
    Public Shared Function DwmGetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As DWMWINDOWATTRIBUTE, ByRef pvAttribute As Integer, ByVal cbAttribute As Integer) As Integer
    End Function

    <DllImport("dwmapi.dll")>
    Public Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As DWMWINDOWATTRIBUTE, ByRef pvAttribute As RECT, ByVal cbAttribute As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)>
    Public Shared Function SendNotifyMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As String) As Boolean
    End Function


    <DllImport("user32.dll")>
    Public Shared Function SetLayeredWindowAttributes(ByVal hwnd As IntPtr, ByVal crKey As UInteger, ByVal bAlpha As Byte, ByVal dwFlags As UInteger) As Boolean
    End Function


    <DllImport("user32.dll")>
    Public Shared Function RedrawWindow(hWnd As IntPtr, lprcUpdate As IntPtr, hrgnUpdate As IntPtr, flags As RedrawWindowFlags) As Boolean
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function CombineRgn(ByVal hrgnDest As IntPtr,
   ByVal hrgnSrc1 As IntPtr, ByVal hrgnSrc2 As IntPtr,
   ByVal fnCombineMode As Integer) As Integer
    End Function


    Enum DWMWINDOWATTRIBUTE As UInteger
        NCRenderingEnabled = 1
        NCRenderingPolicy
        TransitionsForceDisabled
        AllowNCPaint
        CaptionButtonBounds
        NonClientRtlLayout
        ForceIconicRepresentation
        Flip3DPolicy
        ExtendedFrameBounds
        HasIconicBitmap
        DisallowPeek
        ExcludedFromPeek
        Cloak
        Cloaked
        FreezeRepresentation
    End Enum


    Enum RedrawWindowFlags As UInteger
        Invalidate = &H1
        InternalPaint = &H2
        [Erase] = &H4
        Validate = &H8
        NoInternalPaint = &H10
        NoErase = &H20
        NoChildren = &H40
        AllChildren = &H80
        UpdateNow = &H100
        EraseNow = &H200
        Frame = &H400
        NoFrame = &H800
    End Enum

    Public Structure POINTAPI
        Public x As Integer
        Public y As Integer
    End Structure

    Public Shared WS_BORDER As Integer = 8388608
    Public Shared WS_DLGFRAME As Integer = 4194304
    Public Shared WS_CAPTION As Integer = WS_BORDER Or WS_DLGFRAME
    Public Shared WS_VISIBLE As Integer = 268435456

    Public Structure WINDOWPLACEMENT
        Public Length As Integer
        Public flags As Integer
        Public showCmd As Integer
        Public ptMinPosition As POINTAPI
        Public ptMaxPosition As POINTAPI
        Public rcNormalPosition As RECT
    End Structure

    Public Enum PROCESS_DPI_AWARENESS
        Process_DPI_Unaware = 0
        Process_System_DPI_Aware = 1
        Process_Per_Monitor_DPI_Aware = 2
    End Enum

    Public Shared WM_DWMCOLORIZATIONCOLORCHANGED As Integer = &H320
    Public Shared WM_DWMCOMPOSITIONCHANGED As Integer = &H31E
    Public Shared WM_THEMECHANGED As Integer = &H31A

    Public Const WM_SETREDRAW As Integer = 11

    Public Structure WindowCompositionAttributeData
        Public Attribute As WindowCompositionAttribute
        Public Data As IntPtr
        Public SizeOfData As Integer
    End Structure

    Public Enum WindowCompositionAttribute
        WCA_ACCENT_POLICY = 19
    End Enum

    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Public Structure MONITORINFO
        Public cbSize As Long
        Public rcMonitor As RECT
        Public rcWork As RECT
        Public dwFlags As Long
    End Structure

    Friend Enum AccentState
        ACCENT_DISABLED = 0
        ACCENT_ENABLE_GRADIENT = 1
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2
        ACCENT_ENABLE_BLURBEHIND = 3
        ACCENT_ENABLE_TRANSPARANT = 6
        ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
        ACCENT_NORMAL = 150
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure AccentPolicy
        Public AccentState As AccentState
        Public AccentFlags As Integer
        Public GradientColor As Integer
        Public AnimationId As Integer
    End Structure

    Public Const GWL_STYLE = -16
    Public Const GWL_EXSTYLE = -20
    Public Const WS_MAXIMIZE = 16777216
    Public Const WS_POPUP = 2147483648
    Public Const WS_EX_LAYERED As Integer = 524288

    Public Enum WindowStyles
        WS_BORDER = &H800000
        WS_CAPTION = &HC00000
        WS_CHILD = &H40000000
        WS_CLIPCHILDREN = &H2000000
        WS_CLIPSIBLINGS = &H4000000
        WS_DISABLED = &H8000000
        WS_DLGFRAME = &H400000
        WS_GROUP = &H20000
        WS_HSCROLL = &H100000
        WS_MAXIMIZE = &H1000000
        WS_MAXIMIZEBOX = &H10000
        WS_MINIMIZE = &H20000000
        WS_MINIMIZEBOX = &H20000
        WS_OVERLAPPED = &H0
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED Or WS_CAPTION Or WS_SYSMENU Or WS_SIZEFRAME Or WS_MINIMIZEBOX Or WS_MAXIMIZEBOX
        WS_SIZEFRAME = &H40000
        WS_SYSMENU = &H80000
        WS_TABSTOP = &H10000
        WS_VISIBLE = &H10000000
        WS_VSCROLL = &H200000
    End Enum

    Enum ShowWindowCommands As Integer
        Hide = 0
        Normal = 1
        ShowMinimized = 2
        Maximize = 3
        ShowMaximized = 3
        ShowNoActivate = 4
        Show = 5
        Minimize = 6
        ShowMinNoActive = 7
        ShowNA = 8
        Restore = 9
        ShowDefault = 10
        ForceMinimize = 11
    End Enum

    Public Delegate Function EnumWindowProcess(ByVal Handle As IntPtr, ByVal Parameter As IntPtr) As Boolean

    Public Shared SWP_NOSIZE As UInt32 = 1
    Public Shared SWP_ASYNCWINDOWPOS As UInt32 = 16384
    Public Shared SWP_NOACTIVATE As UInt32 = 16
    Public Shared SWP_NOSENDCHANGING As UInt32 = 1024
    Public Shared SWP_NOZORDER As UInt32 = 4
    Public Shared WM_COMMAND As Long = &H111
    Public Shared HWND_BROADCAST As IntPtr = New IntPtr(65535)
    Public Shared WM_SETTINGCHANGE As UInteger = 26
    Public Shared SMTO_ABORTIFHUNG As Integer = 2



    Public Shared TOPMOST_FLAGS As UInt32 = &H2 Or &H1
    Public Shared ReadOnly HWND_TOPMOST As IntPtr = New IntPtr(-1)



    Public Shared Sub ShowStartMenu()
        Dim shell = FindWindow("Shell_TrayWnd", Nothing)


        '' Const keyControl As Byte = &H11
        '' Const keyEscape As Byte = &H1B
        '' keybd_event(keyControl, 0, 0, UIntPtr.Zero)
        '' keybd_event(keyEscape, 0, 0, UIntPtr.Zero)
        '' Const KEYEVENTF_KEYUP As UInteger = &H2
        '' keybd_event(keyControl, 0, KEYEVENTF_KEYUP, UIntPtr.Zero)
        ''keybd_event(keyEscape, 0, KEYEVENTF_KEYUP, UIntPtr.Zero)

        '' keybd_event(CByte(Keys.LWin), 0, &H0, CType(0, UIntPtr)) : Application.DoEvents() 'Press the Left Win key
        ''keybd_event(CByte(Keys.LWin), 0, &H0, CType(0, UIntPtr)) : Application.DoEvents() 'Press the Left Win key

        '' Dim tt As New RECT
        '' GetWindowRect(shell, tt)

        '' MsgBox(tt.Top)

        ''SHOWS DESKTOP
        ''SendMessage(shell, &H400 + 377, CBool(CType(&H1, IntPtr)), CInt(CType(0, IntPtr)))



        ''  Dim sClassName As New StringBuilder("", 256)
        ''  GetClassName(GetActiveWindow(), sClassName, 256)

        '' PostMessage(shell, &H400 + 465, CType(&H1, IntPtr), CType(&H10001, IntPtr))
        '' PostMessage(shell, &H127, CType(&H30001, IntPtr), CType(0, IntPtr))
        ''SendMessage(shell, &H400 + 377, CBool(CType(&H100, IntPtr)), CInt(CType(1, IntPtr)))

        ''PostMessage(shell, &H400 + 243, CType(shell, IntPtr), CType(0, IntPtr))
        ''SetFocus(shell)
        keybd_event(CByte(Keys.LWin), 0, &H0, CType(0, UIntPtr)) 'Press the Left Win key


        keybd_event(CByte(Keys.LWin), 0, &H2, CType(0, UIntPtr)) 'Press the Left Win key
        ''  SetFocus(shell)







        '' End If

        ''  SetFocus(shell)


        '' keybd_event(CByte(Keys.LWin), 0, &H2, CType(0, UIntPtr)) : Application.DoEvents() 'Press the Left Win key
        '' keybd_event(CByte(Keys.LWin), 0, &H2, CType(0, UIntPtr)) : Application.DoEvents() 'Press the Left Win key

        '' PostMessage(shell, &H112, CType(&HF131, IntPtr), CType(&H1, IntPtr))

        ''PostMessage(shell, wm_s, CType(&H1, IntPtr), CType(&H10001, IntPtr))

        '' PostMessage(shell, &H400 + 465, CType(&H1, IntPtr), CType(&H10001, IntPtr))
        '' PostMessage(shell, &H400 + 443, CType(&H1, IntPtr), CType(0, IntPtr))
        '' PostMessage(shell, &H400 + 377, CType(&H0, IntPtr), CType(0, IntPtr))



        '' keybd_event(CByte(Keys.LWin), 0, &H2, CType(0, UIntPtr)) 'Press the Left Win key

    End Sub

    <DllImport("user32.dll")>
    Public Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UIntPtr)

    End Sub

    Private Declare Function SetFocus Lib "user32.dll" (ByVal hwnd As IntPtr) As IntPtr

    <DllImport("user32.dll")>
    Public Shared Function GetWindowText(ByVal hwnd As IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetActiveWindow() As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")>
    Private Shared Function GetWindowLongPtr(ByVal hWnd As HandleRef, <MarshalAs(UnmanagedType.I4)> nIndex As WindowLongFlags) As IntPtr
    End Function


    Public Enum WindowLongFlags As Integer
        GWL_EXSTYLE = -20
        GWLP_HINSTANCE = -6
        GWLP_HWNDPARENT = -8
        GWL_ID = -12
        GWL_STYLE = -16
        GWL_USERDATA = -21
        GWL_WNDPROC = -4
        DWLP_USER = &H8
        DWLP_MSGRESULT = &H0
        DWLP_DLGPROC = &H4
    End Enum

End Class