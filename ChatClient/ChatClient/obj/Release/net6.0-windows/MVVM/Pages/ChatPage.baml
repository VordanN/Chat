   M S B A M L   `   `   `  ���� E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ChatClient.MVVM.ViewModelChatClient.MVVM.ViewModel  $    ChatClient.MVVM.Pages.ChatPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =	viewmodel'clr-namespace:ChatClient.MVVM.ViewModel       N� 
Background  �#36393f N� Title$ ChatPage�� � DataContext -  'ChatClient.MVVM.ViewModel.MainViewModel  .���  � ColumnDefinitions �� $	��200 ��� .+�� ���#2F3136$��1�� � RowDefinitions �� $��50 ��� �� $��60 �.+��� $��Contacts��$��Center=�$��Medium"�
�������$��8,0,0,0q��� 
������ $��0q�$��1��   ContactCard#��[  ���� *
Contacts+ �� SelectedItem �� *SelectedContact+�� $��2�� �� Orientation$ 
Horizontal=����#292B2F.+��� $��Center=�$��SemiBold"�
���   �$	��100��$��18q����� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=��� $��Center=�$��30��$��C��$��30������ *ConnectToServer+� $��1��$��1�� �� $��50 ��� �� $��70 �.+��� 
������ $��0q�  ChatItem#��[ $��8,0,0,0q�$��1������ *SelectedContact.Messages+�� ���#2f3136$��0,0,0,2q�._�� $��Stretch=�$��8q�.+��� 
�������$
��Bold"�$��5,0,5,0q�$��Center=����� *SelectedContact.UserName+� $��2�� �� �� $��90 �.+��� $��1��$��50��$��8,0,8,0q�$��Message @UserName��  
MessageBox#��[ $��2���� $ 
Horizontal=�$��Right=�$��1��$��0,0,16,0q�.+��� $��/MVVM/View/plus.ico��$��20��$��20��$��5,5,5,0q� �� BitmapScalingMode$
 Fant=��� $��/MVVM/View/arrow.ico��$��20��$��20��$��5,5,5,0q�$
 Fant=�