use master
alter database FlaundryServices
set offline with rollback IMMEDIATE
alter database FlaundryServices
set online with rollback IMMEDIATE

drop database FlaundryServices