   M S B A M L   `   `   `  ���� B  >MovieDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MovieDB.ViewMovieDB.View  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity     MovieDB.View.ActorPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MovieDB.View     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       N� Title$  	ActorPage��.��� .+��� $
��Left=�$	��310��$��	22,22,0,0q�$	��Top=�$	��234������ *Actor.Photo+�� $
��Left=�$��
402,43,0,0q�$��25��$	��362��$	��Top=� �� Orientation$ 
Horizontal=�.+��� ���� *
Actor.Name+ �� 
IsReadOnly �� *
ReadOnly+�� ���� *Actor.Surname+ �� *
ReadOnly+�� ���� *Actor.Patronymic+ �� *
ReadOnly+�� $��Имя��$
��Left=�$��
284,44,0,0q�$	��Top=�$��25��$��81���� $��Дата рождения��$
��Left=�$��
284,83,0,0q�$	��Top=�$��95��$��25���� $	��Top=�$
��Left=�$��
402,83,0,0q�$��40��$��25������ *Days+ �� SelectedItem �� *Day+ �� 
IsReadOnly �� *
ReadOnly+�� $	��Top=�$
��Left=�$��
447,83,0,0q�$��40��$��25������ *Months+ �� *Month+ �� *
ReadOnly+�� $	��Top=�$
��Left=�$��
492,83,0,0q�$��60��$��25������ *Years+ �� *Year+ �� *
ReadOnly+�� $��Сохранить��$
��Left=�$	��Top=�$��402,494,0,0q�$	��103��$��50������ *
EditPerson+y��� *
Visibility+�� $ ��Редактировать��$
��Left=�$	��Top=�$��528,494,0,0q�$	��111��$��50������ *Edit+y��� *
Visibility+�� $#��Выбрать обложку��$
��Left=�$	��Top=�$��
22,345,0,0q�$	��115��$��37������ *	EditPhoto+y��� *
Visibility+�� $��Удалить��$
��Left=�$	��Top=�$��661,494,0,0q�$	��103��$��50������ *RemovePerson+y��� *
Visibility+�� $!��Место рождения��$
��Left=�$��284,122,0,0q�$	��Top=� J� RenderTransformOrigin$ -0.196,0.647&�$	��113��$��25���� -    ��Name$ country��$
��Left=�$	��Top=�$��402,121,0,0q�$��25��$	��362������ *Actor.Сountry+ �� *
ReadOnly+.���� $��Фильмография��$
��Left=�$��284,164,0,0q�$	��Top=�$��95���� $
��Left=�$	��Top=�$��402,164,0,0q�$	��292��$	��362������ *Movies+ �� *SelectedMovie+���� .R��� ���� *Title+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.  (System.Windows.Interactivity.TriggerBase	   Actions.	 6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 �� *ShowMovieInfo+�� $��+��$
��Left=�$��775,416,0,0q�$	��Top=�$��40��$��40��$��20(�$
��Bold"�$��Center=����� *
AddMovie+