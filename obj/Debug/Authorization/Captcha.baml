   M S B A M L   `   `   `  ????L  Htest_demo_exam_04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:test_demo_exam_04.Authorizationtest_demo_exam_04.Authorization  5   	   -    'test_demo_exam_04.Authorization.Captcha   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:test_demo_exam_04.Authorization     5   	     ? Title$  Captcha??5   	   $
??auto??6   $
??auto??6'    ? Icon$ /Resources/minilogo.png??64    ? 
ResizeMode$ NoResize=?6S    ? SizeToContent$ WidthAndHeight=?6i    ? WindowStartupLocation$ CenterScreen=?6?   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5       ? RowDefinitions 5   
   ?? 5      .+?5   
   ??    StackPanelMS#??[  6    ?? Orientation$ Vertical=?6;   .+?5      ?? -   5         ??Name$ 	lbCaptcha??5      $?? ??6+     TextBlockMS#??[ 63   $??Center=?6X   $??Center=?6u   ?? 5      -   5        	 ??Name$	 	tbCaptcha??5        	TextBoxMS#??[ 6)   ?? 5      -   5        
 ??Name$
 btnSend??5        ButtonMS#??[ 6&   $
??Send??6H   6W   5      5      5      