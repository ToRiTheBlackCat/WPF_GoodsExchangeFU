   M S B A M L   `   `   `  ����Q  MWPF-GoodsExchangeFUGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_GoodsExchangeFUGUIWPF_GoodsExchangeFUGUI  5   	   +    %WPF_GoodsExchangeFUGUI.RegisterWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:WPF_GoodsExchangeFUGUI     5   	     � Title$  RegisterWindow��5   	   $	��700��6    $
��1020��6-   ���	#FFD4F7D4$
��Aria)�5
   	   $��16(�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $	��14* �6   .+�5   
   �� $��Register account��6   $��20(�6,   $
��Bold"�6:   $��Center=�6L   $��	0,10,0,20q�6i   �� 5   
   $��1��6   $	��Top=�6"   $��2��6:   $��416,10,276,0q�6K   .+�5      �� -   5        $��UserNameTextBox��5      $	��0,5q�6.   $��5q�6;   $��30��6G   $	��249��6S   �� 5      -   5        $��EmailTextBox��5      $	��0,5q�6+   $��5q�68   $��30��6D   $	��250��6P   G� 5      -   5        $��PasswordBox��5      $	��0,5q�6.   $��5q�6;   $��30��6G   $	��250��6S   G� 5      -   5        $��ConfirmPasswordBox��5      $	��0,5q�65   $��5q�6B   $��30��6N   $	��252��6Z   �� 5      -   5        $��PhoneTextBox��5      $	��0,5q�6+   $��5q�68   $��30��6D   $	��252��6P   �� 5      -   5        $��AddressTextBox��5      $	��0,5q�6-   $��5q�6:   $��30��6F   $	��252��6R   �� 5      -   5        $��GenderComboBox��5      $	��0,5q�6-   $��30��6:   $��5q�6F   $	��254��6R   .@�5      �� $��Select gender��6    �� 
IsSelected$
 True��67   ${�False��6I   �� 5      $
��Male��6   �� 5      $��Female��6   5       (  "System.Windows.Controls.DatePicker  5!      -   5        $��DateOfBirthPicker��5!      $	��0,5q�63   $��30��6@   $��5q�6L   $	��257��6X   �� 5"      -	   5         ��Name$ SignUp_Button��5"      $��Sign up��6,   $
��0,10q�6>   $��30��6L   $	��259��6u   5$      �� 5%   
   $��Label��6   $
��Left=�6    $��254,60,0,528q�6;   $��2��6Q   �� 5&   
   $��UserName��6   $
��Left=�6#   $��
354,13,0,0q�6>   $��1��6R   $	��Top=�6_   �� 5'   
   $��Password��6   $
��Left=�6#   $��
358,55,0,0q�6>   $��2��6R   $	��Top=�6_   �� 5(   
   $��Email��6   $
��Left=�6    $��
386,10,0,0q�6;   $��2��6O   $	��Top=�6\   �� 5)   
   $��Confirm password��6   $
��Left=�6+   $��
296,89,0,0q�6F   $��2��6Z   $	��Top=�6g   �� 5*   
   $��Phone��6   $
��Left=�6    $��379,134,0,0q�6;   $��2��6P   $	��Top=�6]   �� 5+   
   $��Address��6   $
��Left=�6"   $��367,173,0,0q�6=   $��2��6R   $	��Top=�6_   �� 5,   
   $��Gender��6   $
��Left=�6!   $��369,213,0,0q�6<   $��2��6Q   $	��Top=�6^   �� 5-   
   $��Date of birth��6   $
��Left=�6(   $��331,253,0,0q�6C   $��2��6X   $	��Top=�6e   5.      5/      