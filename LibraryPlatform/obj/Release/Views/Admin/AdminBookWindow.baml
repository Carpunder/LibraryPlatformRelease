   M S B A M L   `   `   `  ���� J  FLibraryPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:LibraryPlatform.Views.AdminLibraryPlatform.Views.Admin  ?$clr-namespace:LibraryPlatform.ModelsLibraryPlatform.Models  1    +LibraryPlatform.Views.Admin.AdminBookWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:LibraryPlatform.Views.Admin     7Models$clr-namespace:LibraryPlatform.Models       � Title$  
Книги��$	��650��$
��1200�� � Icon$ /Images/icon.ico�� � 
ResizeMode$ CanMinimize=�.��� .+��� -    ��Name$ inLibraryLable��$��В библиотеке��$
��Left=�$��	10,10,0,0q�$	��Top=�$��36(�&   System.Windows.Controls.DataGrid  -     Name$ copiesInLibraryTable��$��10,71,10,70q�   CanUserReorderColumns .     
IsReadOnly .     AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Номер книги��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *
CopyNumber+  $%	 Номер библиотеки��
 �� *
CodeNumber+  $!	 Название Книги��
 �� *
BookName+  $	 
Автор��
 �� *Author+  $	 Издание��
 �� *	Publisher+  $	 Год Издания��
 �� *YearOfPublishing+  $	 Город Издания��
 �� *PublisherCity+  $	 Библиотека��
 �� *LibraryNumber+�� -    ��Name$ getFromStockButton��$��Заказать��$
��Left=�$��
10,569,0,0q�$	��173��$��32��$	��Top=��� -   $ getAllBooksButton��$��Показать все��$
��Left=�$��436,569,0,0q�$	��174��$��32��$	��Top=��� -   $ getInLibraryButton��$��В библиотеке��$
��Left=�$��630,569,0,0q�$	��172��$��32��$	��Top=��� -   $ giveToStockButton��$��Списать��$
��Left=�$��211,569,0,0q�$	��173��$��32��$	��Top=��� -   $ detailsButton��$��Подробно��$
��Left=�$��989,569,0,0q�$	��172��$��32��$	��Top=�