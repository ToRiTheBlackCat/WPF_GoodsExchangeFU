   M S B A M L   `   `   `  ����Q  MWPF-GoodsExchangeFUGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_GoodsExchangeFUGUIWPF_GoodsExchangeFUGUI  5   	   0    *WPF_GoodsExchangeFUGUI.DetailProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_GoodsExchangeFUGUI     5   	     � Title$  DetailProductWindow��5   	   $	��700��6%   $
��1017��62   ���	#FFD4F7D4 � WindowStartupLocation$ CenterScreen=�6V    � 
ResizeMode$ CanMinimize=�6{   .��5	      � -   5        $��0,0,-3,0q�5	       .+�5
   
   �� $��Product Detail��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $��48(�6o   $��Arial)�6}   $
��Bold"�6�   $	��626��6�   $��65��6�   �� 5   
   -   5         ��Name$ grbCategory��5      $��Product Details��6(   $��	0,80,34,0q�6A   $��20(�6T   $
��Bold"�6b   $	��564��6t   $	��Top=�6�   $��Right=�6�   $	��511��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FF0ACCB5��6#    � Offset$ 1Q�65   � 5      $ 	#FE2FB6B9��6#   $ 0Q�65   � 5      $ 	#FE1CCA76��6#   5      .��5      � -   5         �Name$ grbCateSelect��5      $��10,0,8,0q�6*   $	��515��6<   	 � RowDefinitions	 5      �� 5      
 � ColumnDefinitions
 5      �� 5      .+�5      �� $��Product Name��6   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   $��14(�6u   $��32��6�   $	��149��6�   �� 5      -   5         ��Name$ txtPdctName��5      $
��Left=�6/   $��
164,10,0,0q�6J   $	��Top=�6^   $	��271��6v   $��14(�6�   $��69��6�    �� TextWrapping$
 Wrap=�6�   �� 5      $��Product Description��6   $
��Left=�66   $��	10,84,0,0q�6Q   $	��Top=�6d   $��14(�6|   $��32��6�   $	��149��6�    J� RenderTransformOrigin$ 0.505,1.211&�6�   �� 5      -   5        $ txtPdctDesc��5      $
��Left=�6/   $��
164,84,0,0q�6J   $	��Top=�6^   $	��271��6v   $��14(�6�   $	��106��6�   $
 Wrap=�6�   �� 5      $��Product Price��6   $
��Left=�60   $��
10,195,0,0q�6K   $	��Top=�6_   $��14(�6w   $��32��6�   $	��149��6�   $ 0.505,1.211&�6�   �� 5       -   5        $ txtPdctPrice��5       $
��Left=�60   $��164,195,0,0q�6K   $	��Top=�6`   $	��136��6x   $��14(�6�   $��32��6�   �� 5!      $��Category��6   $
��Left=�6+   $��
10,232,0,0q�6F   $	��Top=�6Z   $��14(�6r   $��32��6�   $	��149��6�   $ 0.505,1.211&�6�   �� 5"      -   5         ��Name$ btnSave��5"      $
��Save��6*   $
��Left=�69   $��
84,365,0,0q�6T   $	��Top=�6h   $��48��6�   $	��110��6�   6�   �� 5#      -   5        $ btnExit��5#      $
��Exit��6*   $
��Left=�69   $��
84,432,0,0q�6T   $	��Top=�6h   $��48��6�   $	��110��6�   6�   �� 5$      -	   5        $ 	btnRemove��5$      $��Remove��6,   $
��Left=�6=   $��266,365,0,0q�6X   $	��Top=�6m   $��48��6�   $	��110��6�   6�   �� 5%      -
   5         ��Name$ CateComboBox��5%      $
��Left=�61   $��40��6L   $��164,232,0,0q�6X   $	��Top=�6m   $	��242��6�   5&      5'      � 5(   
   $��
40,152,0,0q�6   $	��380��6#   $	��380��60   ���	#FFD4C9C9$
��Left=�6S   $	��Top=�6n   .+�5)      �� -   5         ��Name$ 
imgPdctPic��5)      $��14,13,14,14q�6(   5*      �� 5+   
   -   5        $ ChooseImageButton��5+      $��Choose Image��6,   $
��Left=�6C   $��37��6^   $��104,607,0,0q�6j   $	��Top=�6   $	��252��6�   6�   �� 5,   
   -   5        $ txtImageUrl��5,      $
��Left=�6'   $��26��6B   $��
73,554,0,0q�6N   $
 Wrap=�6b   $��TextBox��6v   $	��Top=�6�   $	��314��6�   5/      50      