   M S B A M L   `   `   `  ����Q  MWPF-GoodsExchangeFUGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_GoodsExchangeFUGUIWPF_GoodsExchangeFUGUI  5   	   1    +WPF_GoodsExchangeFUGUI.WaitingProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_GoodsExchangeFUGUI     5   	   -   5          �Name$  WaitingProduct_Window��5   	    � Title$ WaitingProductWindow��5   	   $	��700��6'   $
��1020��64   ���	#FFD4F7D4 � WindowStartupLocation$ CenterScreen=�6X   $
��1020��6}   $
��1020��6�   $	��700��6�   $	��700��6�   .��5	      � .+�5
   
   �� $��WAITING PRODUCT LIST��6   $��Center=�6/   $��87��6L   $��0,10,0,0q�6X   $	��Top=�6j   $	��726��6�   $��60(�6�   $
��Bold"�6�   $��Arial)�6�   ���	#FFFD6C066�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$  WaitingProductListGataGrid��5      $��Center=�67   $	��510��6T   $��	0,151,0,0q�6a   $	��Top=�6t   $
��1000��6�      AutoGenerateColumns$ False��6�   $��16(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	ProductId+  5      $
 Name��6%   $	 150 63    6?   �� *ProductName+  5      $ Image��6%   $	 200 64    6@   �� *ProductImage+  5      $ Description��6%   $	 280 6:    6F   �� *ProductDescription+  5      $ Type ID��6%   $ 70 66    6A   �� *TypeId+  5      $ 	Type Name��6%   $ 95 68    6C   �� *Type.TypeName+  5      $ Price��6%   $ 80 64    6?   �� *ProductPrice+  5      $ Owner��6%   $	 120 64    6@   �� *User.UserName+5      �� 5   
   -   5        	 ��Name$	 AcceptProductButton��5      $��Accept Product��6.   $
��Left=�6G   $��44��6b   $��
213,87,0,0q�6n   $	��Top=�6�   $	��267��6�   ���	#FFFFB264$��24(�6�   $
��Bold"�6�   $��Arial)�6�   
�������6  �� 5   
   -   5        $	 DenyProductButton��5      $��Deny Product��6,   $
��Left=�6C   $��44��6^   $��
564,87,0,0q�6j   $	��Top=�6~   $	��267��6�   ���	#FFF5635C$��24(�6�   $
��Bold"�6�   $��Arial)�6�   
�������6�   �� 5    
   -   5        $	 
BackButton��5       $
��Back��6%   $
��Left=�64   $��40��6O   $��	10,32,0,0q�6[   $	��Top=�6n   $��88��6�   ���	#FFA2A2A2$��24(�6�   $
��Bold"�6�   $��Arial)�6�   
�������6�   5"      5#      