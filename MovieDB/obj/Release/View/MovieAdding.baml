   M S B A M L   `   `   `  ���� B  >MovieDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MovieDB.ViewMovieDB.View  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity     MovieDB.View.MovieAdding   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MovieDB.View     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � Title$'  !Добавление фильма��$	��430��$	��615��.��� .+��� $
��Left=�$��
284,19,0,0q�$	��Top=�$	��199��$��23������ *SearchString+�� $��
Поиск��$
��Left=�$	��Top=�$��
500,19,0,0q�$��75��$��23������ *SearchMovies+�� $
��Left=�$	��Top=�$��	23,61,0,0q�$	��237��$	��224������ *AddedMovies+ �� SelectedItem �� *SelectedMovie1+���� .R��� $��22�� �� Orientation$ 
Horizontal=�.+��� ���� *Title+�� -    ��Name$ ActorsListBox��$
��Left=�$	��Top=�$��
284,61,0,0q�$	��237��$	��301������ *	AllMovies+ �� *SelectedMovie2+���� .R��� $��22��$ 
Horizontal=�.+��� ���� *Title+�� $��Добавить��$
��Left=�$��485,312,0,0q�$	��Top=�$	��100��$��26������ *
AddMovie+{��� *AddBtnEnabled+�� $��Удалить��$
��Left=�$��147,312,0,0q�$	��Top=�$	��100��$��26������ *RemoveMovie+{��� *RemoveBtnEnabled+�� $
��Ок��$
��Left=�$��406,360,0,0q�$	��Top=�$��77��$��31������ *	OkClick+�� $��Отмена��$
��Left=�$��508,360,0,0q�$	��Top=�$��77��$��31������ *CancleClick+