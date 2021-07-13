del /q "C:\temp\learningtransport\*"
FOR /D %%p IN ("C:\temp\learningtransport\*.*") DO rmdir "%%p" /s /q