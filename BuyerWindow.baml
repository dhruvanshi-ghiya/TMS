   M S B A M L   `   `   `  ����>  :TMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TMS.Pages	TMS.Pages  5   	       TMS.Pages.BuyerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TMS.Pages     5   	     � Title$  BuyerWindow��5   	   $	��450��6   $	��800��6*   .��5	      � $��-3,0,3,0q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5
      �� 5   
   $
��Left=�6   $	��419��6/   
���   �$	��Top=�6K   $	��792��6c   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5      �  � Color$ #1D3354��6#    � Offset$	 0.0Q�63   � 5      $ #9ED8DB��6#   $	 1.0Q�63   5      5      �� 5   
   -   5        ���#E9FFF9$��View Contracts��5   &   $
��Left=�6?   $��	41,32,0,0q�6Z   $	��Top=�6m   $	��151��6�   $��53��6�   6�   �� 5   
   -   5        ���#E9FFF9$��View Customers��5   &   $
��Left=�6?   $��
254,32,0,0q�6Z   $	��Top=�6n   $	��151��6�   $��53��6�    J� RenderTransformOrigin$ -0.865,0.344&�6�   �� 5   
   -   5        ���#E9FFF9$��View Completed Orders��5   &   $
��Left=�6F   $��
473,32,0,0q�6a   $	��Top=�6u   $	��151��6�   $��53��6�   6�   �� 5   
   -   5        ���#E9FFF9$��Create Order��5   &   $
��Left=�6=   $��661,290,0,0q�6X   $	��Top=�6m   $	��124��6�   $��29��6�   6�   �� 5   
   -   5        ���#E9FFF9$��Add Customer��5   &   $
��Left=�6=   $��661,324,0,0q�6X   $	��Top=�6m   $	��124��6�   $��29��6�   6�   �� 5   
   -   5        ���#E9FFF9$��Generate Invoice��5   &   $
��Left=�6A   $��661,358,0,0q�6\   $	��Top=�6q   $	��124��6�   $��29��6�   6�   �� 5   
   -   5         ��Name$ ContractsListBox��5      ���#E9FFF9$
��Bold"�6A   $��16(�6S   $
��Left=�6a   $	��298��6|   $��
10,101,0,0q�6�   $	��Top=�6�   $	��207��6�   6�   �� 5   
   -	   5        $ CustomersListBox��5      ���#E9FFF9$
��Bold"�6A   $��16(�6S   $
��Left=�6a   $	��298��6|   $��226,101,0,0q�6�   $	��Top=�6�   $	��207��6�   6�   �� 5   
   -
   5        $ CompletedOrderListBox��5      ���#E9FFF9$
��Bold"�6F   $��16(�6X   $
��Left=�6f   $	��298��6�   $��449,101,0,0q�6�   $	��Top=�6�   $	��207��6�   6�   �� 5   
   -   5        $��Sign Out��5      $
��Left=�6$   $��
688,18,0,0q�6?   $	��Top=�6S   $��75��6k   6v   5      5      