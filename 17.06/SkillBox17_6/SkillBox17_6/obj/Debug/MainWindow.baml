   M S B A M L   `   `   `  ????G  CSkillBox17_6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SkillBox17_6SkillBox17_6  5   	       SkillBox17_6.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SkillBox17_6     5   	     ? Title$  
MainWindow??5   	   $	??600??6   $
??1100??6)   .??5	      ? .+?5
   
   ?? -   5         ??Name$ LoginTextBox??5
      $
??Left=?6(   $??20??6C   $??	50,20,0,0q?6O    ?? TextWrapping$
 Wrap=?6b   $"??Введите логин...??6v   $	??Top=?6?   $	??120??6?   ?? 5   
   -   5        $ PasswordTextBox??5      $
??Left=?6+   $??20??6F   $??
220,20,0,0q?6R   $
 Wrap=?6f   $$??Введите пароль...??6z   $	??Top=?6?   $	??120??6?   ?? 5   
   -   5         ??Name$ SingInButton??5      $??
Войти??6'   $
??Left=?67   $??
390,20,0,0q?6R   $	??Top=?6f   $	??100??6~   6?   ?? 5   
   -   5         ??Name$ SingInStatus??5      $
??Left=?6*   $??
540,20,0,0q?6E   $
??Wrap=?6Y   $??Подключние...??6m   $	??Top=?6?   $	??400??6?   ?? 5   
   -   5        $ UniteDataButton??5      $0??*Вывести всю информацию??6*   $
??Left=?6K   $??450,535,0,0q?6f   $	??Top=?6{   $	??200??6?   6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ gridView??5      $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5         SelectionMode$ Single=?5         AutoGenerateColumns .  	   
IsReadOnly	 .  $??20,100,20,50q?5      ??5      ?? 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        id??,  &System.Windows.Controls.DataGridColumn   Header$ Id??5   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   ?? *Id+5   %     5      -   5        
workerName??$  Имя cотрудника??5    %    5   %   ?? *
workerName+5    %     5"      -	   5        workerSurname??$) #Фамилия сотрудника??5$   %    5#   %   ?? *workerSurname+5$   %     5&      -
   5        workerPatronymic??$+ %Отчество сотрудника??5(   %    5'   %   ?? *workerPatronymic+5(   %     5*      -   5        phoneNumber??$! Номер телефона??5,   %    5+   %   ?? *phoneNumber+5,   %     5.      -   5        	email??$ Email??50   %    5/   %   ?? *email+50   %    ? ContextMenu 54      ?? 55      .@?56      m? -   5        $??Добавить??56      61   m? 57      -   5        $??Удалить??57      60   58      5:      5;      5<      