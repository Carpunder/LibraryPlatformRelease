   M S B A M L   `   `   `  ���� J  FLibraryPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:LibraryPlatform.Views.AdminLibraryPlatform.Views.Admin  1    +LibraryPlatform.Views.Admin.FromStockWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:LibraryPlatform.Views.Admin       � Title$%  Регистрация книг��$	��431��$
��1442�� � 
ResizeMode$ CanMinimize=� � Icon$ /Images/icon.ico��.���  � ColumnDefinitions �� $
��143* ��� $
��257* �.+��� -    ��Name$ booksComboBox��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��380��$��29��$��2���� -    ��Name$ avalibleCountLabel��$��Доступно:��$��
10,90,21,0q�$��24(�$��75��$	��Top=�$��2���� -    ��Name$ takeBooksButton��$��Заказать��$
��Left=�$��
37,306,0,0q�$	��Top=�$��59��$	��315��$��2���� -    ��Name$ booksCountTextBox��$
��Left=�$��
10,161,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��380��$��14(�$��2��&   System.Windows.Controls.DataGrid  -   	  Name$	 booksDataGrid��$��1��$��12,0,0,0q�
   CanUserReorderColumns
 .     
IsReadOnly .    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$! Название Книги��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Title+  $ 
Автор�� �� *Author+  $ Издание�� �� *PublisherName+  $ Год Издания�� �� *YearOfPublication+  $ Жанр�� �� *Genre+  $ Количество�� �� *Count+