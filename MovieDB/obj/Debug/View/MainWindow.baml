   M S B A M L   `   `   `  ����B  >MovieDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MovieDB.ViewModelMovieDB.ViewModel  5   	   !clr-namespace:MovieDBMovieDB  5   	       MovieDB.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .vmclr-namespace:MovieDB.ViewModel     5   	   'localclr-namespace:MovieDB     5   	     � Title$  
MainWindow��5	   	   $	��650��6   $
��1025��6)    � DataContext 5
      %  MovieDB.ViewModel.MainViewModel  5   
   5      .��5      � .+�5   
    � $
��Left=�5      $	��600��5      $	��850��6   $	��Top=�5      $��
158,10,0,0q�6%   ��5      �� *FrameContent+5   %   �� 5   
   $��Фильмы��5      $
��Left=�5      $��	12,26,0,0q�5      $	��Top=�5      $	��135��5      $��74��6   ��5      �� *
ShowMovies+{�5      �� *	IsEnabled+5      �� 5   
   $��Актёры��5      $
��Left=�5!      $��
12,122,0,0q�5"      $	��Top=�5#      $	��135��5$      $��74��6   ��5      �� *
ShowActors+{�5       �� *	IsEnabled+5$      �� 5%   
   $��Режисёры��5&      $
��Left=�5)      $��
12,216,0,0q�5*      $	��Top=�5+      $	��135��5,      $��74��6   ��5'      �� *ShowDirectors+{�5(      �� *	IsEnabled+5,      5B      5C      