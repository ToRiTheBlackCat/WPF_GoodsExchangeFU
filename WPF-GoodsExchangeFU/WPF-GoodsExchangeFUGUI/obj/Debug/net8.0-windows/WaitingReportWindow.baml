   M S B A M L   `   `   `  ����Q  MWPF-GoodsExchangeFUGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_GoodsExchangeFUGUIWPF_GoodsExchangeFUGUI  5   	   0    *WPF_GoodsExchangeFUGUI.WaitingReportWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_GoodsExchangeFUGUI     5   	   -   5          �Name$  WaitingReport_Window��5   	    � Title$ WaitingReportWindow��5   	   $	��700��6&   $
��1017��63   ���	#FFD4F7D4 � WindowStartupLocation$ CenterScreen=�6W   $
��1020��6|   $
��1020��6�   $	��700��6�   $	��700��6�   .��5	      � .+�5
   
   �� $��WAITING REPORT LIST��6   $��Center=�6.   $��87��6K   $��0,10,0,0q�6W   $	��Top=�6i   $	��726��6�   $��60(�6�   $
��Bold"�6�   $��Arial)�6�   ���	#FFFD6C066�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ WaitingReportListGataGrid��5      $��Center=�66   $	��510��6S   $��	0,152,0,0q�6`   $	��Top=�6s   $
��1000��6�      AutoGenerateColumns$ False��6�   $��16(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
ReportId+  5      $ 	Writer ID��6%   $ 75 68    6C   �� *UserId+  5      $ Prod. ID��6%   $ 70 67    6B   �� *	ProductId+  5      $ 
Prod. Name��6%   $	 120 69    6E   �� *Product.ProductName+  5      $ 
Prod. Desc��6%   $	 160 69    6E   �� *Product.ProductDescription+  5      $ Owner��6%   $	 120 64    6@   �� *User.UserName+  5      $ Report Detail��6%   $	 255 6<    6H   �� *Detail+  5      $ Report Date��6%   $	 166 6:    6F   �� *
ReportDate+5      �� 5   
   -   5        	 ��Name$	 RemoveProductButton��5      $��Remove Product��6.   $��Center=�6G   $��44��6d   $��0,87,0,0q�6p   $	��Top=�6�   $	��224��6�   ���	#FFFF8478$��24(�6�   $
��Bold"�6�   $��Arial)�6�   
�������6  �� 5   
   -   5        $	 
BackButton��5      $
��Back��6%   $
��Left=�64   $��40��6O   $��	10,32,0,0q�6[   $	��Top=�6n   $��88��6�   ���	#FFA2A2A2$��24(�6�   $
��Bold"�6�   $��Arial)�6�   
�������6�   �� 5   
   -   5        $	 BanUserButton��5      $��Ban User��6(   $
��Left=�6;   $��44��6V   $��
695,87,0,0q�6b   $	��Top=�6v   $	��224��6�   ���	#FFFF8478$��24(�6�   $
��Bold"�6�   $��Arial)�6�   
�������6�   �� 5   
   -   5        $	 MarkDoneButton��5      $��	Mark Done��6)   $
��Left=�6=   $��44��6X   $��
114,87,0,0q�6d   $	��Top=�6x   $	��223��6�   ���	#FF82D87B$��24(�6�   $
��Bold"�6�   $��Arial)�6�   
�������6�   5      5      