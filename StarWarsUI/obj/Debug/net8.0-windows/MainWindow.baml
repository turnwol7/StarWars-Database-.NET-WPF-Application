   M S B A M L   `   `   `  ����  
StarWarsUI    StarWarsUI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  DoggyDoDo Query App��5   	   $	��450��6%   $	��800��62   .��5      �  � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5	       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��
0,10,10,10q�6   $��1��6)   .+�5      �� -   5        $��List People��5      $��0 0 0 5q�6>   �� 5      -   5        $��List Planets��5      $��0 0 0 5q�6@   �� 5      -   5        $��List Tall People��5      $��0 0 0 5q�6G   �� 5      $��
0,10,10,10q�6   $��1��6-    �� Orientation$ 
Horizontal=�6=   .+�5      	� -   5        $
��Male��5       	� 	GroupName$ Gender��6-   6@   	� 5      -   5        $��Female��5      $ Gender��6/   6B   5      �� 5      $��
0,10,10,10q�6   $��1��6-   .+�5      �� -   5        $
��Edit��5      $��0 0 0 5q�6;   5       5"      �� 5$   
   -   5         ��Name$ 
lstResults��5$      $��1��6&   $��1��63   $��30q�6r   �� 5&   
   -   5         ��Name$ 	statusBar��5&   5   $��2��6   $��2��6!   $��Bottom=�6H   .@�5'      �� $	��267��6   .��5(      �� -	   5         ��Name$ 
statusText��5(      5)      5*      5-      5.      