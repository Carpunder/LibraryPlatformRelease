   M S B A M L   `   `   `  ���� J  FLibraryPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryPlatform.Views.ReturnBook LibraryPlatform.Views.ReturnBook  8    2LibraryPlatform.Views.ReturnBook.BooksReturnWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @local.clr-namespace:LibraryPlatform.Views.ReturnBook       � Title$  ВозвратКниг��$	��450��$
��1070�� � 
ResizeMode$ CanMinimize=� � Icon$ /Images/icon.ico��.��� .+��� -    ��Name$ LibraryCardComboBox��$
��Left=�$��	10,50,0,0q�$	��Top=�$	��191��$��16(�&   System.Windows.Controls.DataGrid  -     Name$ booksDataGrid��$��255,10,10,10q�$��12(�   CanUserReorderColumns .     
IsReadOnly .    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Номер Книги��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *CopyLibNumber+  $!	 Название Книги��
 �� *
BookName+  $	 
Автор��
 �� *Author+  $	 Издание��
 �� *	Publisher+  $	 Дата Выдачи��
 �� *DateOfIssue+  $	 Дата Возврата��
 �� *DateOfService+�� -    ��Name$ libraryCardLabel��$)��#Читательский билет��$
��Left=�$��	10,10,0,0q�$	��Top=�$��20(��� -   $ bookCardComboBox��$
��Left=�$��
10,166,0,0q�$	��Top=�$	��191��$��16(��� -   $ bookCardNumber��$��Номер книги��$
��Left=�$��
10,126,0,0q�$	��Top=�$��20(��� -    ��Name$ returnButton��$��Вернуть��$
��Left=�$��
22,338,0,0q�$	��Top=�$	��179��$��46�� � Cursor$
 Hand��