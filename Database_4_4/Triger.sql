use DBServer
go
------------------------------------------------STORE PROCEDURE-------------------------------------------
create proc USP_PRINT_STUDENT_FULL
as
begin
	print 'Table is already full';
end
go
create proc USP_PRINT_STUDENT
	@st_id char(8),
	@s_name nvarchar(100),
	@s_age int,
	@s_gender nchar(3),
	@s_dob date,
	@s_class char(6),
	@s_department char(2),
	@s_university char(4)
as
begin
	print st_id+s_name+age.cast(char)+s_gender+s_dob.cast(char)+s_class+s_department+s_university;
end
go

------------------------------------------------TRIGGER ROCEDURE-----------------------------------------
------------PREVENT STUDENT INSERTION IF COUNT >30-----------
create trigger UTG_STUDENT_INSERT on Student for insert
as
begin
	declare @count int
	select @count=count(*)
	from Student
	if(@count=40)
	exec USP_PRINT_STUDENT_FULL
	rollback tran
end
go
-------------PRINT DELETED STUDENT------------------------------
create trigger UTG_STUDENT_DELETE on Student after delete
as
begin
	select D.* 
	from deleted D
	EXEC USP_PRINT_STUDENT @S_id =S_id,@name= name,@age=age ,@gender=gender,@dob=dob,@class=class ,@department=department,@university=university
end
go
delete from Student where S_id='19120390'
go

