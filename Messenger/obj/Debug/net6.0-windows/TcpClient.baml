   M S B A M L   `   `   `  ����D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Messenger	Messenger  5   	       Messenger.TcpClient   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   #localclr-namespace:Messenger  5   	   -   5          � Title$  Клиент��5	   	   $	��450��6   $	��800��6%    � WindowStartupLocation$ CenterScreen=�61   .��5
      � ���#D4CDF4 � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $
��0.5* �6   �� 5      $��2* �6    �� 5      $
��0.6* �6    � RowDefinitions 5   
   �� 5      $
��0.9* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $
��0.7* �6   .+�5   
   �� -   5         ��Name$ Count��5      $��0��6#   $��Пользователи:��60   $��Center=�6F   $��Center=�6a   $��22(�6~   ���	#FFCCAEFF6�   �� 5   
   -   5        $��	UsersList��5      $��0��6#   $��1��63   $��7��6@   �� 5   
   -   5        $��MessagesList��5      $��1��6&   $��3��66   $��0��6J   $��7��6W   �� 5   
   -   5        $��ExitBt��5      $��40��6   $��7��6+   $��1��68    #  MaterialDesignFlatLightBgButton#��[  6H    � ToolTip$# MaterialDesignFlatLightButton��6�   ���#8B85C1���#8B85C1.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�6&   $��35��67   $��35��6C   $��Center=�6N   $��Center=�6i   5       �� 5!   
   -   5        $��
MessageTbx��5!      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 5��6B   $��7��6{   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Введите сообщение��6�   $��5q�6�   ���#7A6F9B$��2��6�   $��18(�6�   �� 5"   
   -   5        $��SendBt��5"      $��40��6   $��7��6+   $��3��68   #��[  6H   $# MaterialDesignFlatLightButton��6�   ���#8B85C1���#8B85C1.��5#        $
 Send=�6&   $��25��62   $��25��6>   $��Center=�6I   $��Center=�6d   5$      5%      5&      