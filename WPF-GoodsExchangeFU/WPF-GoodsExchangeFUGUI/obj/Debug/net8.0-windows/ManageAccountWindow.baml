   M S B A M L   `   `   `  ����Q  MWPF-GoodsExchangeFUGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_GoodsExchangeFUGUIWPF_GoodsExchangeFUGUI  5   	   0    *WPF_GoodsExchangeFUGUI.ManageAccountWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_GoodsExchangeFUGUI     5   	     � Title$  ManageAccountWindow��5   	   $	��700��6%   $
��1020��62   ���	#FFD4F7D4$
��Aria)�5
   	   $��16(�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� .+�5      �� $��Manage Accounts��6   $��20(�6/   $
��Bold"�6=   $��10q�6O   �� 5      -   5         ��Name$ RefreshButton��5      $��Refresh��6,   $��10q�6Z   ���	#FFFF8304
�������$��18(�6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ AccountsDataGrid��5         AutoGenerateColumns$ False��61   $��10q�6M      
IsReadOnly$
 True��6Y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ User ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6:   �� *UserId+6U     5      $ Username��6)   $ * 6X   	 6;   �� *
UserName+6X     5      $ Password��6)   $ * 6X   	 6;   �� *
Password+6X     5      $ Email��6)   $ * 6R   	 68   �� *Email+6R     5      $ Phone��6)   $ * 6R   	 68   �� *Phone+6R     5      $
 Role��6)   $ * 6R   	 67   �� *RoleId+6R     5      $ 	Is Banned��6)   $ * 6Y   	 6<   �� *
IsBanned+6Y   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6-   $ * 6>   
   CellTemplate
 5      �� 5      .R�5   "   �� -   5        $��Delete��5   )   ��6:   �� *UserId+6^   5      5       5"      �� 5#       �� Orientation$ Vertical=�6   $��10q�60   .+�5$      �� $��Create Mod Account��6   $��16(�66   $
��Bold"�6D   $��10q�6V   �� 5%      $ 
Horizontal=�6   $��5q�66   .+�5&      �� $��	Username:��6   $	��100��60   $��Center=�6<   �� 5'      -   5         ��Name$ NewUsernameTextBox��5'      $	��200��6:   $��5q�6F   5(      �� 5)      $ 
Horizontal=�6   $��5q�66   .+�5*      �� $��Email:��6   $	��100��6-   $��Center=�69   �� 5+      -   5        $ NewEmailTextBox��5+      $	��200��67   $��5q�6C   5,      �� 5-      $ 
Horizontal=�6   $��5q�66   .+�5.      �� $��Phone:��6   $	��100��6-   $��Center=�69   �� 5/      -   5        $ NewPhoneTextBox��5/      $	��200��67   $��5q�6C   50      �� 51      $ 
Horizontal=�6   $��5q�66   .+�52      �� $��	Password:��6   $	��100��60   $��Center=�6<   G� 53      -   5         G�Name$ NewPasswordBox��53   "   $	��200��6:   $��5q�6F   54      �� 55      -   5        $��Create Mod Account��55      $��5q�6T   ���	#FFFF8304
�������$��18(�6�   56      57      58      59      