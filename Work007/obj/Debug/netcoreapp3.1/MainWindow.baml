   M S B A M L   `   `   `  ????B  >Work007, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Work007Work007  5   	       Work007.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Work007     5   	   -   5          ? Title$  Work007??5   	   $	??444??6   $	??800??6&   .??5	      ? 
??????? ? RowDefinitions 5
   
   ?? 5      $
??383* ?6   ?? 5      $	??51* ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgTodoList??5      $??16(?6(   $
??Bold"?66   $??10,10,10,10q?6H      AutoGenerateColumns$ False??6]   $??1??6y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$ False??6K      Header$ CreationDate??6^      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? 	 ?? Path$	 CreationDate?6t   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ False??6n   $
 Done??6?   $ 80 6?    6)   ?? $	 IsDone?
 ?? UpdateSourceTrigger$
 PropertyChanged=?6?     5      $ False??6C   $
 Todo??6V   $ * 6d    6%   ?? $
	 Text?6d   5      ?? 5   
   $??1??6   $??Center=?5       ?? Orientation$ 
Horizontal=?5      $??Center=?5      $??24??60   $	??300??6<   .+?5      ?? -   5        $??24??5      $??Обновить??5      $	??150??5      ?? 5      -   5        $??24??5      $??Center=?5       $??Удалить??5"      $	??150??5#      5$      5%      5&      