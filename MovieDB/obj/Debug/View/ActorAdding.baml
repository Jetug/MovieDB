   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   B >MovieDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MovieDB.ViewMovieDB.View 5   	      MovieDB.View.ActorAdding   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ,localclr-namespace:MovieDB.View     5   	     � Title$'  !Добавление актёра��5	   	   $	��430��6#   $	��615��60   .��5
      � .+�5   
   �� $
��Left=�5      $��
284,19,0,0q�5      $	��Top=�5      $	��199��5      $��23��6   ��5      �� *SearchString+5      �� 5   
   $��
Поиск��5      $
��Left=�5      $	��Top=�6(   $��
500,19,0,0q�5      $��75��5      $��23��6   ��5      �� *SearchActors+5      �� 5   
   $
��Left=�5      $	��Top=�6(   $��	23,61,0,0q�5      $	��237��5      $	��224��6   ��5      �� *AddedActors+ �� SelectedItem 5      �� *SelectedActor1+��5      �� 5      .R�5       �� $��22��6!    �� Orientation$ 
Horizontal=�6-   .+�5!      �� ��6$   �� *Name+�� 5"      ��6$   �� *	Surname+5#      5$      5&      �� 5(   
   -   5         ��Name$ ActorsListBox��5)      $
��Left=�5,      $	��Top=�6(   $��
284,61,0,0q�5-      $	��237��5.      $	��301��6   ��5*      �� *	AllActors+ 5+      �� *SelectedActor2+��5/      �� 50      .R�51      �� $��22��6!   $ 
Horizontal=�6-   .+�52      �� ��6$   �� *Name+�� 53      ��6$   �� *	Surname+54      55      57      �� 58   
   $��Добавить��59      $
��Left=�5<      $��485,312,0,0q�5=      $	��Top=�5>      $	��100��5?      $��26��6   ��5:      �� *
AddActor+{�5;      �� *AddBtnEnabled+5A      �� 5B   
   $��Удалить��5C      $
��Left=�5F      $��147,312,0,0q�5G      $	��Top=�5H      $	��100��5I      $��26��6   ��5D      �� *RemoveActor+{�5E      �� *RemoveBtnEnabled+5I      �� 5J   
   $
��Ок��5K      $
��Left=�5M      $��406,360,0,0q�5N      $	��Top=�5O      $��77��5P      $��31��6   ��5L      �� *	OkClick+5P      �� 5Q   
   $��Отмена��5R      $
��Left=�5T      $��508,360,0,0q�5U      $	��Top=�5V      $��77��5W      $��31��6   ��5S      �� *CancleClick+5W      5X      5Y      