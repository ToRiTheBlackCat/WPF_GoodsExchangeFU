   M S B A M L   `   `   `  ����Q  MWPF-GoodsExchangeFUGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_GoodsExchangeFUGUIWPF_GoodsExchangeFUGUI  5   	   +    %WPF_GoodsExchangeFUGUI.UserInfoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_GoodsExchangeFUGUI     5   	   -   5          � Title$  UserInfoWindow��5   	   $	��700��6    $
��1017��6-   ���	#FFD4F7D4 � WindowStartupLocation$ CenterScreen=�6Q    � 
ResizeMode$ CanMinimize=�6v   .��5	      � .+�5
   
   �� $
��Left=�6   $	��684��6/   
���   �$��Center=�6K   $	��201��6f   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FE1CCA76��6#   � 5      $ 	#FF0ACCB5��6#    � Offset$ 1Q�65   5      5      �� 5   
   $��212,83,7,224q�6   
���   �6*   �� 5   
   $��View User Info��6   $
��Left=�6)   $��	445,2,0,0q�6D   $	��Top=�6W   $��Arial)�6o   $��48(�6�   $
��Bold"�6�   ���	#FFFD6C066�   �� 5   
   -   5         ��Name$ 
BackButton��5      $��Go Back��6%   $
��Left=�67   $��
50,613,0,0q�6R   $	��Top=�6f   $��35��6~   $��98��6�   $��16(�6�   $��Arial)�6�   $
��Bold"�6�   6�   �� 5   
   $��
User Name:��6   $
��Left=�6%   $��232,124,0,0q�6@   $	��Top=�6U   $��Arial)�6m   $��16(�6�   $
��Bold"�6�   �� 5   
   $��Email:��6   $
��Left=�6!   $��232,170,0,0q�6<   $	��Top=�6Q   $��Arial)�6i   $��16(�6|   $
��Bold"�6�   �� 5   
   $��Phone Number:��6   $
��Left=�6(   $��232,218,0,0q�6C   $	��Top=�6X   $��Arial)�6p   $��16(�6�   $
��Bold"�6�   �� 5   
   $��Gender:��6   $
��Left=�6"   $��232,264,0,0q�6=   $	��Top=�6R   $��Arial)�6j   $��16(�6}   $
��Bold"�6�   �� 5   
   $��
Birthdate:��6   $
��Left=�6%   $��232,310,0,0q�6@   $	��Top=�6U   $��Arial)�6m   $��16(�6�   $
��Bold"�6�   �� 5   
   $��Address:��6   $
��Left=�6#   $��232,358,0,0q�6>   $	��Top=�6S   $��Arial)�6k   $��16(�6~   $
��Bold"�6�   �� 5   
   $��	User Info��6   $
��Left=�6$   $��
242,66,0,0q�6?   $	��Top=�6S   $��Arial)�6k   $��24(�6~   ���	#FFD4F7D4$
��Bold"�6�   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6%   $��368,126,0,0q�6@   $
��Wrap=�6U   $��	TextBlock��6i   $	��Top=�6z   $��22��6�   $	��550��6�   $��Arial)�6�   $��16(�6�   �� 5   
   -   5        $ txtEmail��5      $
��Left=�6&   $��368,174,0,0q�6A   $
��Wrap=�6V   $��	TextBlock��6j   $	��Top=�6{   $��22��6�   $	��550��6�   $��Arial)�6�   $��16(�6�   �� 5   
   -   5        $ txtPhone��5      $
��Left=�6&   $��368,220,0,0q�6A   $
��Wrap=�6V   $��	TextBlock��6j   $	��Top=�6{   $��22��6�   $	��550��6�   $��Arial)�6�   $��16(�6�   �� 5    
   -   5        $ 	txtGender��5       $
��Left=�6'   $��368,267,0,0q�6B   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   $��22��6�   $	��550��6�   $��Arial)�6�   $��16(�6�   �� 5!   
   -   5        $ 
txtAddress��5!      $
��Left=�6(   $��368,360,0,0q�6C   $
��Wrap=�6X   $��	TextBlock��6l   $	��Top=�6}   $��22��6�   $	��550��6�   $��Arial)�6�   $��16(�6�   (  "System.Windows.Controls.DatePicker  5"   
   -   5        	  Name$	 BirthdateDatePicker��5"      ${�false��62   $
��Left=�6D   $��28��6_   $��368,310,0,0q�6k   $	��Top=�6�   $	��200��6�   �� 5#   
   -	   5        $ tbkAveScore��5#      $
��Left=�6)   $��368,403,0,0q�6D   $
��Wrap=�6Y   $��TextBox��6m   $	��Top=�6|   $��25��6�   $	��304��6�   $��Arial)�6�   $��16(�6�   �� 5$   
   -
   5        
 ��Name$
 txtAveScore��5$      $��Average Score:��6%   $
��Left=�6>   $��230,398,0,0q�6Y   $	��Top=�6n   $��Arial)�6�   $��16(�6�   $
��Bold"�6�   �� 5%   
   $��212,487,7,10q�6   
���   �6*   �� 5&   
   $��Rating | Comment List��6   $
��Left=�60   $��236,465,0,0q�6K   $	��Top=�6`   $��Arial)�6x   $��24(�6�   ���	#FFD4F7D4$
��Bold"�6�   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ RatingDataGrid��5'      $
��Left=�6+   $	��145��6F   $��232,503,0,0q�6S   $	��Top=�6h   $	��758��6�      
IsReadOnly$
 True��6�      AutoGenerateColumns$ False��6�      Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Rater Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Exchange.User.UserName+6s     5*      $ Score��6%   $	 100 64    6@   �� *Score+6]     5+      $ Comment��6%   $ * 66    6@   �� *	Comment+6_     5,      $ 	Rate Date��6%   $	 150 68    6D   �� *
RatingDate+ �� StringFormat$ {0:yyyy-MM-dd}��6�   5.      50      51      