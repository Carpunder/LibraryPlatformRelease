   M S B A M L   `   `   `  ���� J  FLibraryPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:LibraryPlatform.Views.BooksLending"LibraryPlatform.Views.BooksLending  ?    9LibraryPlatform.Views.BooksLending.MainBooksLendingWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Blocal0clr-namespace:LibraryPlatform.Views.BooksLending       � Title$  
Книги��$	��800��$
��1600�� � Icon$ /Images/icon.ico�� � 
ResizeMode$ CanMinimize=�.���  � ColumnDefinitions �� .+��� -    ��Name$ readersComboBox��$
��Left=�$��	10,64,0,0q�$	��Top=�$	��399��$��22(� �� Text$  ��$��43���� -    ��Name$ readerLabel��$(��"Выберите читателя:��$
��Left=�$��	10,19,0,0q�$	��Top=�$��24(��� -    ��Name$ fioCheckBox��$��По Фамилли��$
��Left=�$��	10,55,0,0q�$	��Top=�$��24(�$��49��$	��224��{�.  $y�Hidden=��� -   $ 
booksLabel��$"��Выберите книгу:��$
��Left=�$��
10,160,0,0q�$	��Top=�$��24(��� -   $ booksComboBox��$
��Left=�$��
10,205,0,0q�$	��Top=�$	��399��$��22(�&   System.Windows.Controls.DataGrid  -     Name$ readersDeptDataGrid��$��978,50,27,0q�$	��724��$	��Top=�	   CanUserReorderColumns	 .  
   
IsReadOnly
 .    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Номер книги��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *CopyLibNumber+  $! Название Книги�� �� *
BookName+  $ 
Автор�� �� *Author+  $ Дата Выдачи�� �� *DateOfIssue+  $ Дата возврата�� �� *DateOfService+�� -   $ readersCredLabel��$%��Книги у читателя:��$
��Left=�$��	978,5,0,0q�$	��Top=�$��24(�$	��208���� -    ��Name$ giveBookButton��$��Оформить��$
��Left=�$��
67,636,0,0q�$	��Top=�$��24(�$��84��$	��290�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -0.147Q�T� �� -	    ��Name$ bookGroupBox��$��
Книга��$��419,362,627,10q�$��20(��� -
   $ readersGroupBox��$��Читатель��$��419,0,627,427q�$��20(�