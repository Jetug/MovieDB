   M S B A M L   `   `   `  ���� B  >MovieDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MovieDB.ViewMovieDB.View  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity     MovieDB.View.MoviePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MovieDB.View     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       N� Title  �� *Movie.Title+.��� .+��� $
��Left=�$	��310��$��	22,25,0,0q�$	��Top=�$	��234������ *Movie.Cover+�� -   $��title��$
��Left=�$	��Top=�$��
398,25,0,0q�$��25��$	��362������ *Movie.Title+ �� 
IsReadOnly �� *
ReadOnly+.���� $��Актёры��$
��Left=�$��284,242,0,0q�$	��Top=�$��80��$��25���� $��Название��$
��Left=�$	��Top=�$��
284,25,0,0q�$��25��$��81���� $��Год��$
��Left=�$	��Top=�$��
284,60,0,0q�$��80��$��25���� $��
Сюжет��$
��Left=�$��289,372,0,0q�$	��Top=�$��80��$��25���� -   $��description�� �� TextWrapping$
 Wrap=�$
��Left=�$	��Top=�$��398,372,0,0q�$	��110��$	��358������ *Movie.Description+ �� *
ReadOnly+.���� $��Сохранить��$
��Left=�$	��Top=�$��398,508,0,0q�$	��103��$��50������ *	EditMovie+y��� *
Visibility+�� $ ��Редактировать��$
��Left=�$	��Top=�$��524,508,0,0q�$	��111��$��50������ *Edit+y��� *
Visibility+�� $#��Выбрать обложку��$
��Left=�$	��Top=�$��
22,348,0,0q�$	��115��$��37������ *	EditCover+y��� *
Visibility+�� $��Удалить��$
��Left=�$	��Top=�$��657,508,0,0q�$	��103��$��50������ *RemoveMovie+y��� *
Visibility+�� $��Режиссёр��$
��Left=�$��284,189,0,0q�$	��Top=�$��80��$��28���� -   $
��year��$
��Left=�$	��Top=�$��
398,60,0,0q�$��25��$	��362������ *
Movie.Year+ �� *
ReadOnly+.���� $��Хронометраж��$
��Left=�$	��Top=�$��
284,95,0,0q�$	��113��$��25���� -   $��duration��$
��Left=�$	��Top=�$��
398,95,0,0q�$��25��$	��362������ *Movie.Duration+ �� *
ReadOnly+.���� $��
Жанры��$
��Left=�$	��Top=�$��284,131,0,0q�$��80��$��28���� $	��358��$��40��$
��Left=�$	��Top=�$��398,131,0,0q����� *Genres+���� .R�� $	��358��$��40������ .R��� $��20������ *Text+�� $
��Left=�$	��Top=�$��398,242,0,0q�$	��110��$	��358������ *Actors+ �� SelectedItem �� *SelectedActor+���� .R��� $��22�� �� Orientation$ 
Horizontal=�.+��� $��0,0,5,0q����� *Name+�� ���� *	Surname+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *ShowActorInfo+�� $��+��$
��Left=�$��770,312,0,0q�$	��Top=�$��40��$��40��$��20(�$
��Bold"�$��Center=����� *
AddActor+�� -   $	��Dir��$
��Left=�$	��Top=�$��398,185,0,0q�$��40��$	��358������ *	Directors+ �� *SelectedDirector+���� .R��� $��22��$ 
Horizontal=�.+��� $��0,0,5,0q����� *Name+�� ���� *	Surname+   $ MouseDoubleClick��.    �� *ShowDirectorInfo+�� $��+��$
��Left=�$��770,185,0,0q�$	��Top=�$��40��$��40��$��20(�$
��Bold"�$��Center=����� *AddDirector+�� $��+��$
��Left=�$��770,131,0,0q�$	��Top=�$��40��$��40��$��20(�$
��Bold"�$��Center=����� *A+