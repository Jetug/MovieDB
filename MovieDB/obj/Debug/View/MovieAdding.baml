   M S B A M L   `   `   `  ����B  >MovieDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MovieDB.ViewMovieDB.View  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5          MovieDB.View.MovieAdding   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MovieDB.View     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � Title$'  !Добавление фильма��5	      $	��430��6!   $	��615��6.   .��5
      � .+�5   
   �� $
��Left=�5      $��
284,19,0,0q�5      $	��Top=�5      $	��199��5      $��23��6   ��5      �� *SearchString+5      �� 5   
   $��
Поиск��5      $
��Left=�5      $	��Top=�6(   $��
500,19,0,0q�5      $��75��5      $��23��6   ��5      �� *SearchMovies+5      �� 5   
   $
��Left=�5      $	��Top=�6(   $��	23,61,0,0q�5      $	��237��5      $	��224��6   ��5      �� *AddedMovies+ �� SelectedItem 5      �� *SelectedMovie1+��5      �� 5      .R�5       �� $��22��6!    �� Orientation$ 
Horizontal=�6-   .+�5!      �� ��6$   �� *Title+5"      5#      5%      �� 5'   
   -   5         ��Name$ ActorsListBox��5(      $
��Left=�5+      $	��Top=�6(   $��
284,61,0,0q�5,      $	��237��5-      $	��301��6   ��5)      �� *	AllMovies+ 5*      �� *SelectedMovie2+��5.      �� 5/      .R�50      �� $��22��6!   $ 
Horizontal=�6-   .+�51      �� ��6$   �� *Title+52      53      55      �� 56   
   $��Добавить��57      $
��Left=�5:      $��485,312,0,0q�5;      $	��Top=�5<      $	��100��5=      $��26��6   ��58      �� *
AddMovie+{�59      �� *AddBtnEnabled+5=      �� 5>   
   $��Удалить��5?      $
��Left=�5B      $��147,312,0,0q�5C      $	��Top=�5D      $	��100��5E      $��26��6   ��5@      �� *RemoveMovie+{�5A      �� *RemoveBtnEnabled+5E      �� 5F   
   $
��Ок��5G      $
��Left=�5I      $��406,360,0,0q�5J      $	��Top=�5K      $��77��5L      $��31��6   ��5H      �� *	OkClick+5L      �� 5M   
   $��Отмена��5N      $
��Left=�5P      $��508,360,0,0q�5Q      $	��Top=�5R      $��77��5S      $��31��6   ��5O      �� *CancleClick+5S      5T      5U      