   M S B A M L   `   `   `  ????L  Htest_demo_exam_04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:test_demo_exam_04.MainPagestest_demo_exam_04.MainPages  5      -    'test_demo_exam_04.MainPages.AddEditUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:test_demo_exam_04.MainPages     5        N? Title$  AddEditUser??5	      .??5      ?  ? ColumnDefinitions 5   
   ?? 5       ? RowDefinitions 5   
   ?? 5      .+?5   
   ??    StackPanelMS#??[  6    ?? Orientation$ Vertical=?6;   .+?5      ?? #??[  6   .+?5      ?? $??Name: ??6     TextBlockMS#??[ 6*   ?? 5      -   5         ??Name$ tbName??5        	TextBoxMS#??[ 6*   ??6M   ?? *Name+5      ?? 5      #??[  6   .+?5      ?? $??
Password: ??6   #??[ 6.   G? 5      -   5         G?Name$ 
pbPassword??5        PasswordBoxMS#??[ 62   5      ?? 5      #??[  6   .+?5      ?? $??Email: ??6   #??[ 6+   ?? 5      -   5        $ tbEmail??5      #??[ 6+   ??6N   ?? *Email+5      ?? 5       #??[  6   .+?5!      ?? $??Phone: ??6   #??[ 6+   ?? 5"      -   5        $ tbPhone??5"      #??[ 6+   ??6N   ?? *Phone+5#      ?? 5$      #??[  6   .+?5%      ?? $??
IDSecond: ??6   #??[ 6.   ?? 5&      -   5         ??Name$ 
cbIDSecond??5&        
ComboBoxMS#??[ 6/   5'      ?? 5(      #??[  6   .+?5)      ?? $??Cost: ??6   #??[ 6*   ?? 5*      -   5        $ tbCost??5*      #??[ 6*   ??6M   ?? *Cost+5+      ?? 5,      #??[  6   .+?5-      ?? $??Date: ??6   #??[ 6*   (  "System.Windows.Controls.DatePicker  5.      -   5          Name$ dpDate??5.        DatePickerMS#??[ 6-      SelectedDate 6S   ?? *Date+5/      ?? 50      #??[  6   .+?51      ?? $??Image: ??6   #??[ 6+   ?? 52      -   5        	 ??Name$	 lbImage??52      #??[ 6K   ??6-   ?? *ImageOfTable+6K   53      ?? 54      #??[  6   $??Right=?6?   .+?55      ?? -	   5        
 ??Name$
 btnLoadImage??55        ButtonMS#??[ 6/   $??
Load image??6Q   6f   56      ?? 57      #??[  6   .+?58      ?? -
   5        $
 btnSave??58      #??[ 6*   $
??Save??6L   6[   ?? 59      -   5        $
 btnBack??59      #??[ 6*   $
??Back??6L   6[   5:      5;      5<      5=      