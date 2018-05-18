Imports System.Windows.Forms

Class MetaCreator
    Private Declare Function GetTickCount Lib "kernel32" () As Long
    Dim bIsMetaPendingToSave As Boolean = False
    Dim sMetaText As String = ""

    Dim sLastSaveDir As String = ""


    Private Sub createMetaText() Handles btnStart.Click
        If Not (bIsMetaPendingToSave) OrElse (MsgBox("There is a meta pending to save, do you want to overwrite it?", MsgBoxStyle.OkCancel, "Warning") = MsgBoxResult.Ok) Then
            Dim lStartTick As Long = GetTickCount()

            Dim path As String = cbPaths.SelectedValue 'Get the currently selected path from the combobox
            If Not (IsNothing(path)) AndAlso (IO.Directory.Exists(path)) Then
                ' If the dir exists
                Dim saFilesInFolder As String() = System.IO.Directory.GetFiles(path, "*") ' Gets all the files available in the specified directory

                If (saFilesInFolder.Count() > 0) Then
                    ' If there are files
                    ' Loop thru
                    For Each sFilePath As String In saFilesInFolder
                        Dim sCleanedPath As String = sFilePath.Replace(path, "") 'Just remove the selected path from it, so we can include it into meta.xml
                        If (bcbInclLua.IsChecked()) OrElse Not (sCleanedPath.IndexOf(".lua") = -1) Then ' If the the include lua checkbox is enabled or the current file is not a lua file then
                            sCleanedPath = tbPathPerfix.Text & sCleanedPath
                            If (bcbShowFileAddingsInConsole.IsChecked()) Then
                                addConsoleText(String.Format("Adding {0} to meta.xml.", sCleanedPath), 2)
                            End If
                            sMetaText += vbNewLine & sCleanedPath
                        End If
                    Next

                    bIsMetaPendingToSave = True
                    addConsoleText(String.Format("Finished generating meta.xml in {0}", GetTickCount() - lStartTick), 2, True, MsgBoxStyle.Information)
                Else
                    ' If there are no files then
                    addConsoleText("There's no files in the selected directory.", 0)
                End If
            Else
                addConsoleText("The selected path doesnt exists, please browse or select a valid one.", 0, True, MsgBoxStyle.OkOnly)
            End If
        Else
            addConsoleText("Operating cancelled.", 0, True, MsgBoxStyle.OkOnly)
        End If
    End Sub

    Dim saTypes = New String(2) {"Error", "Warning", "Info"}
    Private Sub addConsoleText(ByVal sText As String, Optional ByVal iType As Integer = 2, Optional ByVal bMsgBox As Boolean = False, Optional ByVal msgBoxStyle As MsgBoxStyle = MsgBoxStyle.Critical)
        Console.AppendText(String.Format("[{0}]{1}", saTypes(iType), sText) & vbNewLine)
        If (bMsgBox) AndAlso (((iType = 0) AndAlso (bcbShowMsgBoxForError.IsChecked())) OrElse ((iType = 1) AndAlso (bcbShowMsgBoxForWarning.IsChecked())) OrElse ((iType = 2) AndAlso (bcbShowMsgBoxForInfo.IsChecked()))) Then
            MsgBox(sText, msgBoxStyle, saTypes(iType))
        End If
    End Sub

    Private Sub tbPathPerfix_KeyDown(sender As Object, e As KeyEventArgs) Handles tbPathPerfix.KeyDown
        If (e.IsDown) AndAlso (e.Key = Key.Enter) Then
            tbPathPerfix.Text = tbPathPerfix.Text.Replace("/", "\")
            If Not (tbPathPerfix.Text.Length = 0) AndAlso Not (tbPathPerfix.Text.IndexOf("\") = tbPathPerfix.Text.Length) Then ' If the text lenght is more than 0 and theres no '\' at the end we need to add one.
                tbPathPerfix.Text += "\"
            End If
        End If
    End Sub

    Private Sub btnSavePendingMeta_Click() Handles btnSavePendingMeta.Click
        If (bIsMetaPendingToSave) Then
            If ((System.IO.Directory.Exists(sLastSaveDir)) AndAlso (MsgBox("There is a directory where you saved a meta last time, do you want to save this meta there too?", MsgBoxStyle.OkCancel, "Question") = MsgBoxResult.Ok)) Then
                GoTo saveFile
            End If

            'Bring up a dialog let the user select a folder.


            Dim openFile As Microsoft.Win32.SaveFileDialog = New Microsoft.Win32.SaveFileDialog()
            If (openFile.ShowDialog()) Then
                sLastSaveDir = openFile.FileName
saveFile:
                Dim lStartTick As Long = GetTickCount()
                Using writer As IO.StreamWriter =
                    New IO.StreamWriter(sLastSaveDir)
                    writer.Write(sMetaText)
                    writer.Close()
                End Using
                bIsMetaPendingToSave = False
                addConsoleText(String.Format("Finished writing of meta.xml to {0} in {1} ms", sLastSaveDir, GetTickCount() - lStartTick), 2, True, MsgBoxStyle.OkOnly)
            Else
                    addConsoleText("Meta.xml saving operation cancelled.", 2, True, MsgBoxStyle.OkOnly)
            End If
        Else
            addConsoleText("There is no meta.xml save pending.", 2, True, MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnClipboardCopyMeta_Click() Handles btnClipboardCopyMeta.Click
        If (bIsMetaPendingToSave) Then
            Clipboard.SetText(sMetaText)
            addConsoleText("Copied meta.xml content to clipboard.", 2, True, MsgBoxStyle.OkOnly)
            bIsMetaPendingToSave = False
        Else
            addConsoleText("There is no meta.xml save pending.", 0, True, MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnBrowseFolders_Click() Handles btnBrowseFolders.Click
        Dim folderBrowser As WPFFolderBrowser.WPFFolderBrowserDialog = New WPFFolderBrowser.WPFFolderBrowserDialog("Select a save path")
        If (folderBrowser.ShowDialog()) Then
            Dim sPath As String = folderBrowser.FileName & "\"
            If Not (cbPaths.Items.Contains(sPath)) Then
                cbPaths.SelectedValue = sPath
                cbPaths.Items.Add(sPath)
                addConsoleText("Selected a path " & sPath, 2)
            Else
                addConsoleText("This path is already in the list.", 1, False)
            End If
        End If
    End Sub

    Private Sub GeneratorWindow_Close() Handles Me.Closing
        'Save the opened directories into a file
        Try
            Using writer As IO.StreamWriter =
            New IO.StreamWriter(My.Application.Info.DirectoryPath)
                For Each obj As Object In cbPaths.Items
                    Debug.Print(obj.Value)
                Next
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
