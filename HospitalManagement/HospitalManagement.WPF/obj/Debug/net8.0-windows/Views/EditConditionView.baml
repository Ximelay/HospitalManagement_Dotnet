   M S B A M L   `   `   `  ����  HospitalManagement.WPF4    .HospitalManagement.WPF.Views.EditConditionView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$5  /Редактирование состояния��5   	   $	��250��6*   $	��400��67   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   .+�5   
   �� $*��$Описание состояния:��6   $��14(�6/   $��0,0,0,5q�6=   �� 5   
    �� AcceptsReturn$
 True��5      $��80��6'   $	��360��63   " �� VerticalScrollBarVisibility$
 Auto=�5      $��1��65   ��5      �� *ConditionDescription+ �� UpdateSourceTrigger$ PropertyChanged=�5   5   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��2��6J   $��0,10,0,0q�6W   .+�5      �� $��Сохранить��6   $��80��6I   $��5q�6T   ��6)   �� *SaveCommand+6T   �� 5      $��Отмена��6   $��80��6H   $��5q�6S   ��6&   �� *CancelCommand+6S   5      5      5      