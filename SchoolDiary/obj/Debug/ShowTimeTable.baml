   M S B A M L   `   `   `  ����F  BSchoolDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SchoolDiarySchoolDiary  5   	       SchoolDiary.ShowTimeTable   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SchoolDiary     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$+ %Электронный дневник��5	   	   $	��450��6%   $	��800��62   .��5
      � .+�5   
   �� -   5        $��
Назад��5      $
��Left=�6!   $��
709,10,0,0q�6<   $	��Top=�6P   $��75��6h   6s   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ sel_dat��5      $
��Left=�6&   $��	68,70,0,0q�6A   $	��Top=�6T   �� 5   
   -   5         ��Name$ check_table��5      $��Просмотреть��6&   $
��Left=�6<   $��	68,98,0,0q�6W   $	��Top=�6j   $��99��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5   %      
IsReadOnly . $
��Left=�63   $	��296��6N   $��
172,70,0,0q�6[   $	��Top=�6o   $	��526��6�   �� 5   
   -   5         ��Name$ lab_inf��5      $�� ��6!   $
��Left=�6,   $��
172,29,0,0q�6G   $	��Top=�6[   $	��526��6s   $��Times New Roman)�6   $��16(�6�   $��41��6�   5      5      