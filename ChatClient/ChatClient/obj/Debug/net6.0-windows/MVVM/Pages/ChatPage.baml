   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ChatClient.MVVM.ViewModelChatClient.MVVM.ViewModel  5   D   $    ChatClient.MVVM.Pages.ChatPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =	viewmodel'clr-namespace:ChatClient.MVVM.ViewModel     6D     N� 
Background  �#36393f N� Title$ ChatPage��5	       � DataContext 5      -  'ChatClient.MVVM.ViewModel.MainViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   � ���#2F3136$��1��6$    � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      $��60 �6    .+�5      �� $��Contacts��6   $��Center=�5       $��Medium"�5!      
�������$��8,0,0,0q�5#      �� 5%      
������ $��0q�5(      $��1��5)         ContactCard#��[  5*      ��5%      �� *
Contacts+ �� SelectedItem 5&      �� *SelectedContact+5*      �� 5,      $��2��6    �� Orientation$ 
Horizontal=�5-      ���#292B2F.+�50      �� $��Center=�6   $��SemiBold"�65   
���   �$	��100��6^   $��18q�6j   ��6v   �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=��� 51      $��Center=�6   $��30��64   $��C��6@   $��30��6L   ��6W   �� *ConnectToServer+5>      5?      � 5A   
   $��1��6   $��1��6    5B      �� 5C      $��50 �6    �� 5D      �� 5E      $��70 �6    .+�5H      �� 
������ $��0q�5J        ChatItem#��[ 5K      $��8,0,0,0q�5L      $��1��5M      ��5H      �� *SelectedContact.Messages+5M      �� 5S      ���#2f3136$��0,0,0,2q�5T      ._�5U      � $��Stretch=�6   $��8q�65   .+�5V      �� 
�������$
��Bold"�5X      $��5,0,5,0q�5Y      $��Center=�5Z      ��5V      �� *SelectedContact.UserName+5Z      5[      5\      � 5b      $��2��6    5c      �� 5d      �� 5e      $��90 �6'   .+�5i      �� $��1��6   $��50��5j      $��8,0,8,0q�5k      $��Message @UserName��5l        
MessageBox#��[ 5m      $��2��5n      �� 5o      $ 
Horizontal=�6   $��Right=�5p      $��1��5q      $��0,0,16,0q�5r      .+�5t      �� $��/MVVM/View/plus.ico��6   $��20��5u      $��20��6'   $��5,5,5,0q�5v       �� BitmapScalingMode$
 Fant=�5w      �� 5x      $��/MVVM/View/arrow.ico��6   $��20��5y      $��20��6'   $��5,5,5,0q�5z      $
 Fant=�5{      5�      5�      5�      5�      5�      