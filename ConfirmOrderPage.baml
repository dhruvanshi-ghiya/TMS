   M S B A M L   `   `   `  ����>  :TMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TMS.Pages	TMS.Pages  5   	   (    "TMS.Pages.Planner.ConfirmOrderPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TMS.Pages     5   	     � Title$  ConfirmOrderPage��5   	   $	��500��6"   $
��1000��6/   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��385* �6   �� 5      $
��607* �6   .+�5   
   �� $
��Left=�6   $	��469��6/   
���   �$	��Top=�6K   $	��992��6c   $��2��6o   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5      �  � Color$ #1D3354��6#    � Offset$	 0.0Q�63   � 5      $ #9ED8DB��6#   $	 1.0Q�63   5      5      �� 5   
   -   5        $��OrderInfoSecondary��5      
�������$
��Left=�6H   $��
316,91,0,0q�6c   $
��Wrap=�6w   $	��Top=�6�   $��26��6�   $	��326��6�   $��18(�6�    J� RenderTransformOrigin$ 0.609,0.404&�6�   $��2��6�    �� TextAlignment$ Center=�6  �� 5   
   -   5        $��RouteVisual��5      
�������$
��Left=�6A   $��	10,34,0,0q�6\   $
��Wrap=�6o   $	��Top=�6�   $��33��6�   $	��972��6�   $
��Bold"�6�   $��18(�6�   $ Center=�6�   $��2��6�   �� 5   
   $
��Left=�6   $��19��6/   $��
243,72,0,0q�6;   $	��Top=�6O   $	��470��6g   $��2��6s   �� 5   
   $��Planet Express:��6   $
��Left=�6*   $��	6,351,0,0q�6E   $	��Top=�6X   $��32��6p   $	��135��6|   $
��Bold"�6�   $��14(�6�   �� 5   
   $
��Left=�6   $��
19,372,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��82��6o   $��96��6{   �� 5      $�Windsor��6	   �� 5      �� 5      $�Hamilton��6	   �� 5      �� 5       $�Oshawa��6	   �� 5!      �� 5"      $�
Belleville��6	   �� 5#      �� 5$      $�Ottawa��6	   5%      �� 5&   
   $��
Schooner's��6   $
��Left=�6%   $��120,351,0,0q�6@   $	��Top=�6U   $��32��6m   $	��135��6y   $
��Bold"�6�   $��14(�6�   �� 5'   
   $
��Left=�6   $��131,375,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��84��6p   $��96��6|   �� 5(      $�London��6	   �� 5)      �� 5*      $�Toronto��6	   �� 5+      �� 5,      $�Kingston��6	   5-      �� 5.   
   $��Tillman Transport��6   $
��Left=�6,   $��208,351,0,0q�6G   $	��Top=�6\   $��32��6t   $	��135��6�   $
��Bold"�6�   $��14(�6�   �� 5/   
   $
��Left=�6   $��220,375,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��84��6p   $��96��6|   �� 50      $�Windsor��6	   �� 51      �� 52      $�London��6	   �� 53      �� 54      $�Hamilton��6	   55      �� 56   
   $��We Haul��6   $
��Left=�6"   $��338,352,0,0q�6=   $	��Top=�6R   $��32��6j   $	��135��6v   $
��Bold"�6�   $��14(�6�   $��2��6�   �� 57   
   $
��Left=�6   $��348,375,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��47��6p   $��96��6|   $��2��6�   �� 58      $�Toronto ��6	   �� 59      �� 5:      $�Ottawa��6	   5;      �� 5<   
   
���   �$��1q�6%   $
��Left=�69   $	��169��6T   $��-22,338,0,-38q�6a   $	��Top=�6x   $	��444��6�   $��2��6�   �� 5=   
   $��Add trip to order:��6   $
��Left=�6-   $��
19,158,0,0q�6H   $	��Top=�6\   $��39��6t   $	��167��6�   $
��Bold"�6�   $��18(�6�   $ 0.503,-0.359&�6�   �� 5>   
   $��Order summary:��6   $
��Left=�6)   $��306,145,0,0q�6D   $	��Top=�6Y   $��30��6q   $	��167��6}   $
��Bold"�6�   $��16(�6�   $��1��6�   $ 0.144,0.718&�6�   �� 5?   
   -   5        $��ConfirmOrderBtn��5?      ���#E9FFF9$��Confirm Order��6=   $
��Left=�6U   $��25��6p   $��340,405,0,0q�6|   $	��Top=�6�   $��84��6�   $��1��6�   $ 
0.76,0.604&�6�   �� 5@   
   -   5        $��
AddTripBtn��5@      ���#E9FFF9$��Add trip��68   $
��Left=�6K   $��25��6f   $��258,249,0,0q�6r   $	��Top=�6�   $��85��6�   6�   �� 5A   
   -   5        $��CarrierDropdown��5A      ���#E9FFF9$
��Left=�6?   $��
82,211,0,0q�6Z   $	��Top=�6n   $	��120��6�   6�   �� 5B   
   -   5        $��StartCityDropdown��5B      ���#E9FFF9$
��Left=�6A   $��
82,249,0,0q�6\   $	��Top=�6p   $	��120��6�   �� 5C   
   -   5        $��EndCityDropdown��5C      ���#E9FFF9$
��Left=�6?   $��
82,285,0,0q�6Z   $	��Top=�6n   $	��120��6�   �� 5D   
   $��Carrier:��6   $
��Left=�6#   $��
19,207,0,0q�6>   $	��Top=�6R   $��90��6j   �� 5E   
   $��Start city:��6   $
��Left=�6&   $��
19,245,0,0q�6A   $	��Top=�6U   $��90��6m   �� 5F   
   $��	End city:��6   $
��Left=�6$   $��
19,281,0,0q�6?   $	��Top=�6S   $��90��6k   �� 5G   
   $
��Left=�6   $��19��6/   $��	243,5,0,0q�6;   $	��Top=�6N   $	��470��6f   $��2��6r   �� 5H   
   -   5        $��OrderSummaryList��5H      ���#E9FFF9$
��Left=�6?   $	��190��6Z   $��207,197,0,0q�6g   $	��Top=�6|   $	��350��6�   $��1��6�   6�   �� 5I   
   $��(click to delete)��6   $
��Left=�6,   $��320,167,0,0q�6G   $	��Top=�6\   $��30��6t   $	��104��6�   $��14(�6�   $��1��6�   $ 0.144,0.718&�6�   �� 5J   
   -	   5        $��TripInputError��5J      
���  ��$
��Left=�6;   $��220,285,0,0q�6V   $
��Wrap=�6k   $	��Top=�6   $��48��6�   $	��155��6�   5K      5L      