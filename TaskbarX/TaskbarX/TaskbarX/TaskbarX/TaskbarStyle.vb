﻿Option Strict On

Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Public Class TaskbarStyle

    Public Delegate Function CallBack(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean

    Public Declare Function EnumWindows Lib "user32" (ByVal Adress As CallBack, ByVal y As Integer) As Integer
    Public Shared ActiveWindows As New System.Collections.ObjectModel.Collection(Of IntPtr)

    Public Shared Function GetActiveWindows() As ObjectModel.Collection(Of IntPtr)
        windowHandles.Clear()
        EnumWindows(AddressOf Enumerator, 0)


        Dim maintaskbarfound As Boolean = False
        Dim sectaskbarfound As Boolean = False

        For Each Taskbar In windowHandles
            Dim sClassName As New StringBuilder("", 256)
            Call Win32.GetClassName(CType(Taskbar, IntPtr), sClassName, 256)
            If sClassName.ToString = "Shell_TrayWnd" Then
                maintaskbarfound = True
            End If
            If sClassName.ToString = "Shell_SecondaryTrayWnd" Then
                sectaskbarfound = True
            End If
            Console.WriteLine("=" & maintaskbarfound)
        Next

        If maintaskbarfound = False Then
            Try
                windowHandles.Add(Win32.FindWindow("Shell_TrayWnd", Nothing))
            Catch
            End Try
        End If

        If sectaskbarfound = False Then
            If Screen.AllScreens.Count >= 2 Then
                ''MsgBox(Screen.AllScreens.Count)
                Try
                    windowHandles.Add(Win32.FindWindow("Shell_SecondaryTrayWnd", Nothing))
                Catch
                End Try
            End If
        End If



        Return ActiveWindows
    End Function

    Public Shared windowHandles As ArrayList = New ArrayList()
    Public Shared maximizedwindows As ArrayList = New ArrayList()
    Public Shared trays As ArrayList = New ArrayList()
    Public Shared traysbackup As ArrayList = New ArrayList()
    Public Shared normalwindows As ArrayList = New ArrayList()
    Public Shared resetted As ArrayList = New ArrayList()

    Public Shared Function Enumerator(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean
        Dim sClassName As New StringBuilder("", 256)
        Call Win32.GetClassName(hwnd, sClassName, 256)
        If sClassName.ToString = "Shell_TrayWnd" Or sClassName.ToString = "Shell_SecondaryTrayWnd" Then
            windowHandles.Add(hwnd)
        End If
        Return True
    End Function

    Shared Function IsPhanthom(ByVal hWnd As IntPtr) As Boolean
        Dim CloakedVal As Integer
        Dim hRes As Integer = Win32.DwmGetWindowAttribute(hWnd, Win32.DWMWINDOWATTRIBUTE.Cloaked, CloakedVal, Len(CloakedVal))
        If hRes = Not 0 Then
            CloakedVal = 0
        End If
        Return If(CBool(CloakedVal), True, False)
    End Function

    Public Shared Function Enumerator2(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean
        Try
            Dim intRet As Integer
            Dim wpTemp As New Win32.WINDOWPLACEMENT
            wpTemp.Length = System.Runtime.InteropServices.Marshal.SizeOf(wpTemp)
            intRet = CInt(Win32.GetWindowPlacement(hwnd, wpTemp))
            Dim style As Integer = Win32.GetWindowLong(hwnd, Win32.GWL_STYLE)

            If IsPhanthom(hwnd) = False Then 'Fix phanthom windows
                If (style And Win32.WS_VISIBLE) = Win32.WS_VISIBLE Then
                    If wpTemp.showCmd = 3 Then
                        maximizedwindows.Remove(hwnd)
                        maximizedwindows.Add(hwnd)
                    Else
                        normalwindows.Remove(hwnd)
                        normalwindows.Add(hwnd)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Public Shared Sub Tbsm()
        Do

            Dim windowsold As Integer
            Dim windowsnew As Integer
            windowsold = maximizedwindows.Count

            maximizedwindows.Clear()
            System.Threading.Thread.Sleep(250)
            EnumWindows(AddressOf Enumerator2, 0)

            windowsnew = maximizedwindows.Count

            If Not windowsnew = windowsold Then
                For Each tray As IntPtr In traysbackup
                    For Each normalwindow As IntPtr In normalwindows
                        Dim curmonx As Screen = Screen.FromHandle(normalwindow)
                        Dim curmontbx As Screen = Screen.FromHandle(tray)
                        If curmonx.DeviceName = curmontbx.DeviceName Then
                            trays.Remove(tray)
                            trays.Add(tray)

                            ''If Not Settings.TaskbarRounding = 0 Then
                            ''Dim tt As New Win32.RECT
                            ''Win32.GetClientRect(tray, tt)
                            ''Win32.SetWindowRgn(CType(tray, IntPtr), Win32.CreateRoundRectRgn(0, 0, tt.Right, tt.Bottom - tt.Top, Settings.TaskbarRounding, Settings.TaskbarRounding), True)
                            ''End If
                        End If
                    Next
                Next

                For Each tray As IntPtr In traysbackup
                    For Each maxedwindow As IntPtr In maximizedwindows
                        Dim curmonx As Screen = Screen.FromHandle(maxedwindow)
                        Dim curmontbx As Screen = Screen.FromHandle(tray)
                        If curmonx.DeviceName = curmontbx.DeviceName Then
                            trays.Remove(tray)
                            Win32.PostMessage(tray, &H31E, CType(&H1, IntPtr), CType(&H0, IntPtr))
                            ''  If Not Settings.TaskbarRounding = 0 Then
                            ''  Dim tt As New Win32.RECT
                            ''  Win32.GetClientRect(tray, tt)
                            ''  Win32.SetWindowRgn(CType(tray, IntPtr), Win32.CreateRoundRectRgn(0, 0, tt.Right, tt.Bottom - tt.Top, 0, 0), True)
                            ''End If
                        End If
                    Next
                Next
            End If

        Loop
    End Sub

    Public Shared Sub TaskbarStyler()
        Try

            GetActiveWindows()


            Dim accent = New Win32.AccentPolicy()
            Dim accentStructSize = Marshal.SizeOf(accent)

            'Select accent based on settings
            If Settings.TaskbarStyle = 1 Then
                accent.AccentState = Win32.AccentState.ACCENT_ENABLE_TRANSPARANT
            End If

            If Settings.TaskbarStyle = 2 Then
                accent.AccentState = Win32.AccentState.ACCENT_ENABLE_BLURBEHIND
            End If

            If Settings.TaskbarStyle = 3 Then
                accent.AccentState = Win32.AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND
            End If

            If Settings.TaskbarStyle = 4 Then
                accent.AccentState = Win32.AccentState.ACCENT_ENABLE_TRANSPARENTGRADIENT
            End If

            If Settings.TaskbarStyle = 5 Then
                accent.AccentState = Win32.AccentState.ACCENT_ENABLE_GRADIENT
            End If

            accent.AccentFlags = 2 'enable colorize
            accent.GradientColor = BitConverter.ToInt32(New Byte() {CByte(Settings.TaskbarStyleRed), CByte(Settings.TaskbarStyleGreen), CByte(Settings.TaskbarStyleBlue), CByte(Settings.TaskbarStyleAlpha * 2.55)}, 0)

            'Save accent data
            Dim accentPtr = Marshal.AllocHGlobal(accentStructSize)
            Marshal.StructureToPtr(accent, accentPtr, False)

            Dim data = New Win32.WindowCompositionAttributeData
            data.Attribute = Win32.WindowCompositionAttribute.WCA_ACCENT_POLICY
            data.SizeOfData = accentStructSize
            data.Data = accentPtr

            'Put all TrayWnds into an ArrayList
            For Each trayWnd As IntPtr In windowHandles
                trays.Add(trayWnd)
                traysbackup.Add(trayWnd)
            Next

            If Settings.DefaultTaskbarStyleOnWinMax = 1 Then
                Dim t2 As Thread = New Thread(AddressOf Tbsm)
                t2.Start()
            End If

            'Set taskbar style for all TrayWnds each 14 millisecond
            For Each tray As IntPtr In trays
                Dim trayptr As IntPtr = CType(tray.ToString, IntPtr)
                Win32.SetWindowCompositionAttribute(CType(trayptr, IntPtr), data)




                '' Dim tt As New ListBox
                '' Dim TrayPos2 As Win32.RECT
                '' Win32.GetWindowRect(tray, TrayPos2)
                '' tt.Top = 0
                '' tt.Left = 0
                '' tt.Height = 2000
                '' tt.Width = 2000
                '' tt.BackColor = Color.Red

                ''  tt.FormBorderStyle = FormBorderStyle.None
                ''  Win32.SetWindowLong(tt.Handle, CType(Win32.GWL_STYLE, Win32.WindowStyles), &H80000000L)
                '' tt.Show()
                '' Dim myProg As New Process
                '' With myProg.StartInfo
                ''     .FileName = "D:\Visual Studio Projects\!TaskbarX\APPX\TaskbarX\Release\TaskbarX Configurator.exe"
                ''     .Arguments = ""
                '' End With
                '' myProg.Start()

                '' Thread.Sleep(5000)


                ''Win32.SetParent(myProg.MainWindowHandle, tray)

            Next

            Do
                Try

                    For Each tray As IntPtr In trays
                        Win32.SetWindowCompositionAttribute(tray, data)
                    Next
                    System.Threading.Thread.Sleep(10)
                Catch
                End Try
            Loop
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Shared childLeft As Integer
    Public Shared childTop As Integer
    Public Shared childWidth As Integer
    Public Shared childHeight As Integer

    Public Shared Function GetLocation(ByVal acc As Accessibility.IAccessible, ByVal idChild As Integer) As Integer
        acc.accLocation(childLeft, childTop, childWidth, childHeight, idChild)
        Return Nothing
    End Function

End Class