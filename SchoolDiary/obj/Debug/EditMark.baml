   M S B A M L   `   `   `  ����F  BSchoolDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SchoolDiarySchoolDiary  5   	       SchoolDiary.EditMark   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SchoolDiary     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$+ %Электронный дневник��5	   	   $	��450��6%   $	��800��62   .��5
      � .+�5   
   �� -   5         ��Name$ back_to��5      $��
Назад��6"   $
��Left=�62   $��
709,10,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5         ��Name$ box_subject��5      $
��Left=�6(   $��	88,49,0,0q�6C   $	��Top=�6V   $	��224��6n   6z   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5   %      
IsReadOnly . $
��Left=�63   $	��252��6N   $��	88,96,0,0q�6[   $	��Top=�6n   $	��628��6�   �� 5   
   -   5        $ group��5      $
��Left=�6"   $��
330,49,0,0q�6=   $	��Top=�6Q   $	��103��6i   �� 5   
   -   5        $ 	_continue��5      $��Просмотреть��6$   $
��Left=�6:   $��
449,49,0,0q�6U   $	��Top=�6i   $	��116��6�   $��22��6�   6�   �� 5   
   -   5        $ edit_but��5      $��Изменить��6#   $
��Left=�66   $��404,371,0,0q�6Q   $	��Top=�6f   $��87��6~   $��22��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 	marks_box��5      $
��Left=�6&   $��313,371,0,0q�6A   $	��Top=�6V   $��72��6n   $y�Hidden=�6y   5      5      