   M S B A M L   `   `   `  ����B  >MovieDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MovieDB.ViewMovieDB.View  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5          MovieDB.View.ActorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MovieDB.View     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        N� Title$  	ActorPage��5
      .��5      � .+�5   
   �� $
��Left=�5      $	��310��6(   $��	22,22,0,0q�5      $	��Top=�5      $	��234��6%   ��5      �� *Person.Photo+5   %   �� 5   
   $
��Left=�6   $��
402,43,0,0q�5      $��25��5      $	��362��6!   $	��Top=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� ��6   �� *Person.Name+ �� 
IsReadOnly 63   �� *
ReadOnly+�� 5      ��6   �� *Person.Surname+ 66   �� *
ReadOnly+�� 5      ��6   �� *Person.Patronymic+ 69   �� *
ReadOnly+5      �� 5   
   $��Имя��5      $
��Left=�5      $��
284,44,0,0q�5      $	��Top=�5      $��25��5       $��81��6   �� 5!   
   $��Дата рождения��5"      $
��Left=�6%   $��
284,83,0,0q�5#      $	��Top=�6!   $��95��5$      $��25��6   �� 5&   
   $	��Top=�5*      $
��Left=�6%   $��
402,83,0,0q�5+      $��40��5,      $��25��6   ��5'      �� *Days+ �� SelectedItem 5(      �� *Day+ �� 
IsReadOnly 5)      �� *
ReadOnly+5,      �� 5-   
   $	��Top=�51      $
��Left=�6%   $��
447,83,0,0q�52      $��40��53      $��25��6   ��5.      �� *Months+ 5/      �� *Month+ 50      �� *
ReadOnly+53      �� 54   
   $	��Top=�58      $
��Left=�6%   $��
492,83,0,0q�59      $��60��5:      $��25��6   ��55      �� *Years+ 56      �� *Year+ 57      �� *
ReadOnly+5:      �� 5;   
   $��Сохранить��5<      $
��Left=�5?      $	��Top=�6)   $��402,494,0,0q�5@      $	��103��5A      $��50��6   ��5=      �� *
EditPerson+y�5>      �� *
Visibility+5A      �� 5B   
   $ ��Редактировать��5C      $
��Left=�5F      $	��Top=�6(   $��528,494,0,0q�5G      $	��111��5H      $��50��6   ��5D      �� *Edit+y�5E      �� *
Visibility+5H      �� 5I   
   $#��Выбрать обложку��5J      $
��Left=�5M      $	��Top=�6(   $��
22,345,0,0q�5N      $	��115��5O      $��37��6   ��5K      �� *	EditPhoto+y�5L      �� *
Visibility+5O      �� 5P   
   $��Удалить��5Q      $
��Left=�5T      $	��Top=�6)   $��661,494,0,0q�5U      $	��103��5V      $��50��6   ��5R      �� *RemovePerson+y�5S      �� *
Visibility+5V      �� 5W   
   $!��Место рождения��5X      $
��Left=�6&   $��284,122,0,0q�6A   $	��Top=�6V    J� RenderTransformOrigin$ -0.196,0.647&�6n   $	��113��6�   $��25��6�   �� 5Y   
   -   5         ��Name$ country��5Z      $
��Left=�5]      $	��Top=�6(   $��402,121,0,0q�5^      $��25��5_      $	��362��6   ��5[      �� *Person.Сountry+ 5\      �� *
ReadOnly+.��5_   %   5`      �� 5a   
   $��Фильмография��5b      $
��Left=�5c      $��284,164,0,0q�5d      $	��Top=�5e      $��95��5f      �� 5g   
   $
��Left=�5j      $	��Top=�6(   $��402,164,0,0q�5k      $	��292��5l      $	��362��6   ��5h      �� *Movies+ 5i      �� *SelectedMovie+��5m      �� 5n      .R�5o      �� ��6    �� *Title+5p      .  (System.Windows.Interactivity.Interaction   Triggers 5s      /  )System.Windows.Interactivity.EventTrigger  5t         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5u      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 5v      �� *ShowMovieInfo+5w      5y      �� 5z   
   $��+��5{      $
��Left=�5}      $��775,416,0,0q�5~      $	��Top=�5      $��40��5�      $��40��6   $��20(�5�      $
��Bold"�6   $��Center=�5�      ��5|      �� *
AddMovie+5�      5�      5�      