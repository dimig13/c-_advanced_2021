   M S B A M L   `   `   `  ����G  CZonnepanelen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ZonnepanelenZonnepanelen  5   	       Zonnepanelen.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Zonnepanelen     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $��823.276��6)   .��5	      ]� .+�5
   
   o� $	��Top=�6   ���	#FF706E6E���	#FFFBF6F6.@�5      m� $��Inlezen bestand��6   $��0,6,0,0q�60   $
��Bold"�6B   ���	#FFFBF8F8.@�5      m� -   5         m�Name$ 
MnuDetails��5      $�� Details��6/   
����������	#FF6863636m   m� 5      -   5        $ MnuSamenvatting��5      $�� Samenvatting��64   
����������	#FF6863636|   5      m� 5      $��Opties��6   $��0,6,0,0q�6'   $
��Bold"�69   ���	#FFF9F4F4.@�5      m� -   5        $ MnuDatum��5      $�� Datum tonen/verbergen��6-   ���	#FF686363���	#FFFDFBFB m� IsCheckable .  m� 	IsChecked . 6�   �� 5      m� 5      -   5        $ MnuAchtergrond��5      $�� Achtergrondkleur��63   ���	#FF686363���	#FFFDFBFB6|   5      5      �� 5   
   $��Bottom=�6   ���	#FF706E6E���	#FFFBF8F8.@�5      �� $��Ready��6   $��Italic$�6%   �� 5      $��DateTime.png��6   $��19��6*   $��37��66   �� 5      $��Right=�6   .��5      �� -   5         ��Name$ TextBlockDateTime��5      $��Datum / tijd��67   $��	460,0,0,0q�6K   $��Italic$�6^   $
��Bold"�6q   5      5      � 5   
    � ColumnDefinitions 5      �� 5      $	��26* �6#   �� 5      $
��106* �6#   �� 5       $	��27* �6#   �� 5!      $
��656* �6#    � RowDefinitions 5#      �� 5$      $
��180* �6    �� 5%      $
��439* �6    .+�5'      �� -   5         ��Name$ 
ImgSeizoen��5'      $��
20,10,0,10q�6(   $
��Left=�6<   $	��300��6X   $��4��6d   �� 5(      -   5         ��Name$ TxtResultaat��5(      "	 �� VerticalScrollBarVisibility$	 Visible=�6,   $��Consolas)�6R   $��1��6i   $��20q�6v   $��4��6�   5)      5*      5+      