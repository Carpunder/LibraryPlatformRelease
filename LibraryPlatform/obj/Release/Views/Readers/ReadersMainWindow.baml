   M S B A M L   `   `   `  ���� J  FLibraryPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:LibraryPlatform.Views.ReadersLibraryPlatform.Views.Readers  5    /LibraryPlatform.Views.Readers.ReadersMainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:LibraryPlatform.Views.Readers       � Title$  Читатели��$	��650��$
��1200�� � Icon$ /Images/icon.ico�� � 
ResizeMode$ CanMinimize=�.��� .+��� -    ��Name$ inLibraryLable��$��Читатели��$
��Left=�$��	10,10,0,0q�$	��Top=�$��36(�&   System.Windows.Controls.DataGrid  -     Name$ readersInLibrary��$��10,71,10,70q�   CanUserReorderColumns .     
IsReadOnly .    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Номер билета��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *LibraryCardNumber+  $	 ФИО��
 �� *FIO+  $	 Телефон��
 �� *Phone+  $	 
Адрес��
 �� *	Address+�� -    ��Name$ registerUserButton��$��Добавить��$
��Left=�$��
10,569,0,0q�$	��173��$��32��$	��Top=��� -   $ getAllBooksButton��$��Показать все��$
��Left=�$��234,569,0,0q�$	��173��$��32��$	��Top=��� -   $ readerDetailsButton��$��Подробно��$
��Left=�$��952,569,0,0q�$	��173��$��32��$	��Top=�