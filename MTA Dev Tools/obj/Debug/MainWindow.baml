   M S B A M L   `   `   `  ����N  JMTA Developer Tools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MTA_Developer_ToolsMTA_Developer_Tools  5   	   %    MTA_Developer_Tools.MetaCreator   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MTA_Developer_Tools     5   	     � Title$  Meta.xml creator tool��5   	   $��561.127��6'   $��848.328��68   .��5	      � $��0,0,2,-1q�6    � ColumnDefinitions 5
   
   �� 5      $
��308* �6   �� 5      $
��111* �6   �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ Console��5      $
��Left=�6#   $	��444��6>    �� TextWrapping$
 Wrap=�6K   $��Console��6_   $	��Top=�6n   $	��599��6�   $��	10,45,0,0q�6�   �� 5   
   -   5         ��Name$ cbPaths��5      $
��Left=�6$   $��	10,14,0,0q�6?   $	��Top=�6R   $	��599��6j   $��22��6v   �� 5   
   -   5         ��Name$ btnStart��5      $��Start��6#   $
��Left=�63   $��
14,499,0,0q�6N   $	��Top=�6b   $	��202��6z   $��1��6�   $��20��6�   �� 5   
   -   5        $ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
14,474,0,0q�6P   $	��Top=�6d   $	��202��6|   $��1��6�   $��20��6�   �� 5   
   $��  Show MsgBox for:
��6   $
��Left=�64   $��44��6O   $	��Top=�6[   $	��202��6s   $��1��6   $��	14,88,0,0q�6�   �� 5   
   -   5         ��Name$ 
bcbInclLua��5      $��Include Lua��6'   $
��Left=�6=   $��
14,143,0,0q�6X   $	��Top=�6l   $��1��6�   $��15��6�   $��80��6�   {�.  6�   �� 5   
   -   5        $ bcbLuaFileContainsType��5      $��Lua file contains type��63   $
��Left=�6T   $��
14,163,0,0q�6o   $	��Top=�6�    � ToolTip$U OLua files contains their type in the name. (S - Server, C - Client, G - Shared)��6�   $��1��6�   $��15��6  $	��132��6  {�.  6  �� 5   
   -   5        $ tbPathPerfix��5      $��1��6(   $
��Left=�68   $��18��6S   $��	14,70,0,0q�6_   $��files\��6r   $
 Wrap=�6�   $	��Top=�6�   $	��201��6�   $b \Enter the perfix of the files. For ex.: 'files\'. It must contain the slash('\') at the end.��6�   �� 5   
   -   5        $ btnOpenSettings��5      $��Open Settings��6*   $
��Left=�6B   $��	14,45,0,0q�6]   $	��Top=�6p   $	��202��6�   $��1��6�   $��20��6�   {�.  6�   �� 5   
   -	   5        $ btnBrowseFolders��5      $��Browse Folders��6+   $
��Left=�6D   $��	14,14,0,0q�6_   $	��Top=�6r   $	��202��6�   $��1��6�   $��22��6�   �� 5   
   -
   5        $ bcbShowMsgBoxForWarning��5      $��Warning��64   $��1��6F   $
��Left=�6V   $��
75,111,0,0q�6q   $	��Top=�6�    d� 	IsChecked$
 TrueY�6�   $��15��6�   $��65��6�   �� 5   
   -   5        $ bcbShowMsgBoxForError��5      $��Error��62   $��1��6B   $
��Left=�6R   $��
24,111,0,0q�6m   $	��Top=�6�   $
 TrueY�6�   $��15��6�   $��46��6�   �� 5   
   -   5        $ bcbShowMsgBoxForInfo��5      $
��Info��61   $��1��6@   $
��Left=�6P   $��157,111,0,0q�6k   $	��Top=�6�   $
 TrueY�6�   $��15��6�   $��41��6�   �� 5   
   -   5        $ btnSavePendingMeta��5      $��Save meta.xml��6-   $
��Left=�6E   $��
13,426,0,0q�6`   $	��Top=�6t   $	��199��6�   $��1��6�   $��20��6�   �� 5   
   -   5        $ btnClipboardCopyMeta��5      $ ��Copy meta.xml to clipboard��6/   $
��Left=�6T   $��
14,401,0,0q�6o   $	��Top=�6�   $	��198��6�   $��1��6�   $��20��6�   �� 5   
   -   5        $ 	tbCommand��5      $
��Left=�6%   $��23��6@   $��
10,496,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��504��6�   $D >Enter a command. Ex.: generatemeta C:\Users\file\ files\ False��6�   �� 5   
   -   5        $ btnSendCommand��5      $
��Send��6)   $
��Left=�68   $��519,496,0,0q�6S   $	��Top=�6h   $��90��6�   $��23��6�   �� 5    
   -   5        $! bcbShowFileAddingsInConsole��5       $&�� Show file addings in the console��68   $
��Left=�6c   $��
14,183,0,0q�6~   $	��Top=�6�   $U OLua files contains their type in the name. (S - Server, C - Client, G - Shared)��6�   $��1��6  $��15��6  $	��198��6   �� 5!   
   -   5        $ btnTestSave��5!      $��Button��6&   $��1��67   $
��Left=�6G   $��112,278,0,0q�6b   $	��Top=�6w   $��75��6�   5#      5$      