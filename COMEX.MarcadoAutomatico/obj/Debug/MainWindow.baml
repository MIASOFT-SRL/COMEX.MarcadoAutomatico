   M S B A M L   `   `   `  ����  COMEX.MarcadoAutomatico(    "COMEX.MarcadoAutomatico.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$'  !MiaSoft srl - Marcado Automático��5   	   $��671.666��62   $��1020.333��6C    � WindowStartupLocation$ CenterScreen=�6T   ���	#FFFF9B05 � Icon$ imagenes/favicon.ico��6�   .��5      � $��0,0,0,7q�6    � ColumnDefinitions 5   
   �� 5      .+�5
   
   �� $��Buscar empleado��6   $��146,20,313,0q�6,   $	��Top=�6B   $��87��6Z   $��16(�6f   ���	#FF0066B2���	#FF0066B2$
��Bold"�6�   $��2q�6�   $��Italic$�6�   .��5      � $��48��6   $	��Top=�6   $��
12,0,-12,0q�67   .+�5      �� -   5         ��Name$ txbCriterio��5       �� TextWrapping$
 Wrap=�6/   $��
97,10,21,0q�6C   $��Normal"�6W   $��26��6k   $��Normal$�6w   $	��Top=�6�   $��16(�6�   .��6�    � Triggers 5      :� 5       :� RoutedEvent$ 
MouseEnter��6'   .[�5      �� .��5   "   �� .��5   &   W�  �� 
TargetName$ txbCriterio��66   	 �� TargetProperty$	 Height�5   6   
 W� From$
 26X�5   6   	 W� To$ 35X�6@    g� Duration$ 0:0:0.2D�5   6   W� 5   &   $ txbCriterio��5   )   $	 FontSize�5   )   $
 16X�5   )   $ 21X�63   $ 0:0:0.2D�5   )   W� 5   &   $ lblCriterio��66   $	 Height�5   6   $
 26X�5   6   $ 35X�6@   $ 0:0:0.2D�5   6   W� 5!   &   $ lblCriterio��5"   )   $	 FontSize�5#   )   $
 16X�5$   )   $ 21X�63   $ 0:0:0.2D�5%   )   5'   #   5(      5)      :� 5*      $ 
MouseLeave��6'   .[�5+      �� .��5,   "   �� .��5-   &   W� $ txbCriterio��66   $	 Height�5.   6   $
 35X�5/   6   $ 26X�6@   $ 0:0:0.2D�50   6   W� 52   &   $ txbCriterio��53   )   $	 FontSize�54   )   $
 21X�55   )   $ 16X�63   $ 0:0:0.2D�56   )   W� 58   &   $ lblCriterio��66   $	 Height�59   6   $
 35X�5:   6   $ 31X�6@   $ 0:0:0.2D�5;   6   W� 5=   &   $ lblCriterio��5>   )   $	 FontSize�5?   )   $
 21X�5@   )   $ 16X�63   $ 0:0:0.2D�5A   )   5C   #   5D      5E      .��5F   (   5G      �� 5H      -   5         ��Name$ lblCriterio��5H      $��
Criterio :��6-   $
��Bold"�6B   ���	#FF0066B2$��31��6k   $��Normal$�6w    J� RenderTransformOrigin$ -0.662,-1.323&�6�   $	��Top=�6�   $��0,7,0,0q�6�   $
��Left=�6�   $��97��6�   5I      5J      �� 5K   
   $��	Empleados��6   $��10,140,313,57q�6&   $��16(�6=   $
��Bold"�6K   ���	#FF0066B2���	#FF0066B2$��2q�6�   $��Italic$�6�   .��5L      �� -   5         ��Name$ lbEmpleados��5L      $��	10,10,7,3q�6+   $��Normal"�6>   .@�5M      ��  �� Orientation$ 
Horizontal=�6   $	��639��66   $	��146��6B   .+�5N      �� $	��100��6!   .+�5O      �� $��imagenes/usuario.png��6!   $
��Fill=�6?   5P      �� 5Q      $	��312��6!   $	��130��6-   .+�5R      �� $��31��6%   $ 
Horizontal=�61   .+�5S      �� $��	Código :��6$   $
��Bold"�67   �� 5T      $��7714738��6$   5U      �� 5V      $��31��6%   $ 
Horizontal=�61   .+�5W      �� $��Nombre :��6$   $
��Bold"�67   �� 5X      $!��Miguel Aldo Balderrama Vaca��6$   5Y      �� 5Z      $��31��6%   $ 
Horizontal=�61   .+�5[      �� $��Cargo :��6$   $
��Bold"�66   �� 5\      $��Administrador��6$   5]      �� 5^      $��31��6%   $ 
Horizontal=�61   .+�5_      �� $��Departamento :��6$   $
��Bold"�6=   �� 5`      $��Sistemas��6$   5a      5b      �� 5c      $	��128��6!   $	��218��6.   $ 
Horizontal=�6:   .+�5d      �� -   5         ��Name$ 
cbxMarcado��5d   #   $�� ��67   �� 5e      $��imagenes/U-560-C.png��6    $	��176��6>   5f      5g      5i      5j      �� 5k   
   -   5        $��
borderLogo��5k      
���   �$��0q�67   $
��Left=�6K   $	��125��6f   $	��Top=�6s   $	��115��6�    �� CornerRadius$ 60��6�   $��10,5,0,0q�6�   $ 0.5,0.5&�6�   z�5l      V� 5m      .~�5n      �� �� 5o      �� 5p       �� Angle$ 0Q�6&   T� 5q      5r      ��5t      �� 5u       �� ImageSource$ favicon.png��6    5w      :� 5x      $ Border.MouseEnter��6   .[�5y      �� .��5z      �� .��5{      W� $ 
borderLogo��6.   $S	 M(Border.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�5|   .   $
 0X�5}   .   $	 -90X�67    g� AutoReverse . $ 0:0:0.3D�5~   .   5�      5�      5�      5�      �� 5�   
   
���   �$��0q�6%   $��50��69   $��
0,183,71,0q�6E   $	��Top=�6Y   ���	#FF0091FF$ 20��6�   $��Right=�6�   $	��177��6�   ._�5�      �� -   5         ��Name$ 
btnGuardar��5�      $��Guardar cambios��6)   $��0,1,-2,0q�6C   $	��Top=�6U   $��49��6m   
�������$��0q�6�    � Cursor$
 Hand��6�   $��16(�6�   ��6y   Z� 6�   5�      �� 5�   
   -   5        $��borderLogoMiasoft��5�      
���   �$��0q�6>   $	��138��6R   $��	0,10,14,0q�6_   $	��Top=�6r   $ 30��6�   $��Right=�6�   $	��284��6�   ��5�      �� 5�      $ logo.png��6    5�      :� 5�      $ Border.MouseEnter��6   .[�5�      �� .��5�      �� .��5�      W� $ borderLogoMiasoft��6.   $	 Width�5�   .   $	
 284X�5�   .   $	 300X�69   $ 0:0:0.2D�5�   .   5�      5�      5�      :� 5�      $ Border.MouseLeave��6   .[�5�      �� .��5�      �� .��5�      W� $ borderLogoMiasoft��6.   $	 Width�5�   .   $	
 300X�5�   .   $	 284X�69   $ 0:0:0.2D�5�   .   5�      5�      5�      5�      �� 5�   
   $��
10,0,14,24q�6   $ 
Horizontal=�6)   $��33��6B   $��Bottom=�6N   .+�5�      �� $&�� CopyRight® 2014  MIASOFT s.r.l.��6   $	��Top=�6>   $��32��6V   ���	#FF0066B2$��16(�6y   �� 5�      $"��Correo: miasoft.bo@gmail.com��6   $	��Top=�6;   $��33��6S   ���	#FF0066B2$��16(�6v   �� 5�      $/��)Teléfono: 72634488 - 71010967 - 60895096��6   $	��Top=�6G   $��28��6_   ���	#FF0066B2$��16(�6�   $	��320��6�   5�      �� 5�   
   $��
10,0,14,-8q�6   $ 
Horizontal=�6)   $��38��6B   $��Bottom=�6N   .+�5�      �� $���}Ing. Luis Helder choque Jorge : 72634488 - Ing. Jose Luis Vidal Cejas : 71010967 - Ing.Miguel Aldo Balderrama Vaca : 60895096��6   $	��Top=�6�   $��38��6�   ���	#FF0066B2$��16(�6�   $	��919��6�   5�      � 5�   
   $��
0,332,0,62q�6   $��Right=�6#   $	��308��6?   .+�5�      �� $��Estado :��6   $
��Left=�6'   $��10,0,0,0q�6B   $	��Top=�6T   $��16(�6l   �� 5�      -	   5         ��Name$ cbEstado��5�      $
��Left=�6)   $��84,6,0,0q�6D   $	��Top=�6V   $	��190��6n   $��16(�6z   .@�5�      �� $��M/Ent��6   $��16(�6/   �� 5�      $��M/Sal��6   5�      �� 5�      $��Añadir Registro��6   $��	0,36,10,0q�60   $��16(�6C   $��84��6Q   $	��Top=�6]   .��5�      � $��4,5,4,4q�6   .+�5�      (  "System.Windows.Controls.DatePicker  -
   5          Name$ dpFecha��5�   !   $
��Left=�62   $	��Top=�6M      SelectedDateFormat$ Short=�6e   $
 Hand��6�   $��16(�6�   $	��190��6�   $��2,10,0,0q�6�   �� 5�      -   5        $ txbHora��5�      $
��Left=�6/   $��23��6J   $��
197,13,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $��70��6�   $��16(�6�   $��00:00:00��6�   5�      5�      �� 5�      -   5        $ btnAñadirRegistro��5�      $��Añadir��60   $
��Left=�6A   $��
63,125,0,0q�6\   $	��Top=�6p   $	��173��6�   $��51��6�   $��16(�6�   ���	#FF0091FF
�������6�   5�      5�      5�      