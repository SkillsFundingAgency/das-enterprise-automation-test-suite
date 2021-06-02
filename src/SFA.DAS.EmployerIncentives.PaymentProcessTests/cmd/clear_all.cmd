sqlcmd  -i .\clear_data.sql -S "(localdb)\MSSQLLocalDB"
call clear_learningtransport_folder.bat
pause