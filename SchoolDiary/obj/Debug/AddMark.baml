   M S B A M L   `   `   `  ����F  BSchoolDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SchoolDiarySchoolDiary  5   	       SchoolDiary.AddMark   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SchoolDiary     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$+ %Электронный дневник��5	   	   $	��450��6%   $	��800��62   .��5
      � ��5   
   �� 5      .+�5   
   �� -   5        $��
Назад��5      $
��Left=�6!   $��
709,10,0,0q�6<   $	��Top=�6P   $��75��6h   6s   �� 5   
   -   5         ��Name$ box_subject��5      $
��Left=�6(   $��
107,33,0,0q�6C   $	��Top=�6W   $	��224��6o   6{   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5   %      
IsReadOnly . $
��Left=�63   $	��252��6N   $��
107,80,0,0q�6[   $	��Top=�6o   $	��628��6�   �� 5   
   -   5        $ group��5      $
��Left=�6"   $��
349,33,0,0q�6=   $	��Top=�6Q   $	��103��6i   �� 5   
   -   5         ��Name$ 	_continue��5      $��Просмотреть��6$   $
��Left=�6:   $��
468,33,0,0q�6U   $	��Top=�6i   $	��116��6�   $��22��6�   6�   �� 5   
   -   5        $ set_mark��5      $��Выставить��6#   $
��Left=�67   $��405,354,0,0q�6R   $	��Top=�6g   $	��116��6   $��22��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 	marks_box��5      $
��Left=�6&   $��321,354,0,0q�6A   $	��Top=�6V   $��68��6n   $y�Hidden=�6y   �� 5   
   -   5        $ date_lesson_box��5      $
��Left=�6,   $��107,354,0,0q�6G   $	��Top=�6\   $	��120��6t   $y�Hidden=�6�   5      5      