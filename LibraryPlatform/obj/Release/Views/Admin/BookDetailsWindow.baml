   M S B A M L   `   `   `  ���� J  FLibraryPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:LibraryPlatform.Views.AdminLibraryPlatform.Views.Admin  3    -LibraryPlatform.Views.Admin.BookDetailsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:LibraryPlatform.Views.Admin       � Title$  
Книги��$	��450��$
��1198�� � 
ResizeMode$ CanMinimize=� � Icon$ /Images/icon.ico��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ copiesDataGrid��$��278,21,18,28q�   CanUserReorderColumns .     
IsReadOnly .    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Номер билета��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *LibraryCardNumber+  $ ФИО��	 �� *FIO+  $ Телефон��	 �� *Phone+  $ 
Адрес��	 �� *	Address+  $ Дата выдачи��	 �� *DateOfIssue+  $ Дата возврата��	 �� *DateOfService+�� -   
 ��Name$
 bookCardComboBox��$
��Left=�$��	10,59,0,0q�$	��Top=�$	��191��$��16(��� -    ��Name$ bookCardNumber��$��Номер книги��$
��Left=�$��	10,19,0,0q�$	��Top=�$��20(��� -    ��Name$ exportButton��$��Экспорт��$
��Left=�$��
22,338,0,0q�$	��Top=�$	��179��$��46�� � Cursor$
 Hand��