use webt2289_StudentManager_Thuy
go
DROP table Student
drop table Class
drop table Department
drop table University
create table Student
(
	S_id char(8),
	name nvarchar(100),
	gender nchar(3),
	dob date,
	Class char(6),
	constraint PK_student primary key(S_id)
)
go
create table Class
( 
	C_id char(6),
	dep char(4),
	constraint PK_class primary key(C_id)
)
go
create table Department
(
	D_id char(4),
	uni char(4),
	name nvarchar(50),
	constraint PK_Dep primary key(D_id)
)
go
create table University
(
	U_id char(4),
	name nvarchar(100),
	constraint PK_uni primary key(U_id)
)
go
----------------
alter table Student add CONSTRAINT PK_STUDENT_CLASS foreign key(Class) references Class(C_id)
go
alter table Class add CONSTRAINT PK_CLASS_DEP foreign key(dep) references Department(D_id)
go
alter table Department add  CONSTRAINT PK_DEP_UNI foreign key(uni) references University(U_id)
go
---------------
insert into University values('KHTN',N'KHOA HỌC TỰ NHIÊN') 
go
insert into University values('HNED',N'ĐẠI HỌC SƯ PHẠM HÀ NỘI')
go
insert into University values('USSH',N'KHOA HỌC XÃ HỘI VÀ NHÂN VĂN')
-----------
go
insert into Department values('CNTT','KHTN',N'Công nghệ thông tin')
go
insert into Department values('CNSH','KHTN',N'Công nghệ sinh học')
go
insert into Department values('SPLS','HNED',N'Sư phạm Sử')
go
insert into Department values('DTVT','HNED',N'Điện tử viễn thông')
go
insert into Department values('BCTT','USSH',N'Báo chí truyền thông')
go
insert into Department values('NDPH','USSH','Đông phương học')
go
-----------
go
insert into Class values('19CTT2','CNTT')
go
insert into Class values('19CNTN','CNTT')
go
insert into Class values('19CTT1','CNTT')
go
insert into Class values('19CSH1','CNSH')
go
insert into Class values('19BC01','BCTT')
go
insert into Class values('19TT01','BCTT')
go
insert into Class values('19DL01','NDPH')
go
insert into Class values('19HQ01','NDPH')
go
insert into Class values('19KHMT','CNTT')
go
insert into Class values('19ATTT','CNTT')
go
insert into Class values('19HTTT','SPLS')
go
insert into Class values('19KTPM','SPLS')
go
--------------
insert into Student values('19120390',N'Trịnh Thị Thùy',N'Nữ','01/21/2000','19CTT2')
go
insert into Student values('19120330',N'Nguyễn Đoan Phúc',N'Nữ','12/28/2001','19CTT2')
go
insert into Student values('19120376',N'Nguyễn Lê Bảo Thi',N'Nữ','5/8/2001','19CNTN')
go
insert into Student values('19120580',N'Lê Đức Minh',N'Nam','7/10/2001','19CNTN')
go
insert into Student values('19120100',N'Trịnh Xuân Thiện',N'Nam','3/25/2001','19CTT1')
go
insert into Student values('19120101',N'Trịnh Thị Minh Thư',N'Nữ','4/7/2001','19CTT1')
go
insert into Student values('19120001',N'Nguyễn Xuân Nhi',N'Nữ','8/7/2001','19BC01')
go
insert into Student values('19120002',N'Trần Yến Phương',N'Nữ','1/7/2001','19DL01')
go
insert into Student values('19120003',N'Nguyễn Ngọc Bảo Hân',N'Nữ','10/11/2001','19TT01')
go
insert into Student values('19120004',N'Huỳnh Lê Khánh Huyền',N'Nữ','8/15/2001','19HQ01')
go
insert into Student values('19120005',N'Huỳnh Lê Ánh Huyền',N'Nữ','8/15/2001','19HQ01')
go
insert into Student values('19120006',N'Nguyễn Thu Hảo',N'Nữ','8/30/2001','19DL01')
go
insert into Student values('19120007',N'Bùi Hoàng Hưng',N'Nam','4/9/2001','19BC01')
go
insert into Student values('19120008',N'Nguyễn Quốc Huy',N'Nam','12/23/2001','19TT01')
go
insert into Student values('19120011',N'Nguyễn Công Đức',N'Nam','11/8/2001','19KHMT')
go
insert into Student values('19120012',N'Nguyễn Trần Khả Ái',N'Nữ','11/11/2001','19KHMT')
go
insert into Student values('19120013',N'Nguyễn Hữu Bình',N'Nam','9/5/2001','19ATTT')
go
insert into Student values('19120014',N'Trịnh Văn Minh',N'Nam','3/5/2001','19ATTT')
go
insert into Student values('19120015',N'Phan Văn Nam',N'Nam','6/5/2001','19KTPM')
go
insert into Student values('19120016',N'Phan Trịnh Thanh Hà',N'Nữ','7/12/2001','19KTPM')
go
insert into Student values('19120017',N'Trần Văn Trường An',N'Nam','5/13/2001','19HTTT')
go
insert into Student values('19120018',N'Trần Thị Tường Vi',N'Nữ','4/10/2001','19HTTT')
go
alter table Student add create_date datetime
go
alter table Class add create_date datetime
go
alter table Department add create_date datetime
go
alter table University add create_date datetime
go
update Student set create_date=getdate()
go
update Class set create_date=getdate()
go
update Department set create_date=getdate()
go
update University set create_date=getdate()
go
------------------------------------------------STORE PROCEDURE-------------------------------------------
create proc USP_PRINT_STUDENT_FULL
as
begin
	print 'Table is already full';
end
go
create proc USP_PRINT_STUDENT
	@S_id char(8),
	@S_name nvarchar(100)
as
begin
	print @S_id+':' +@S_name;
end
go

------------------------------------------------TRIGGER ROCEDURE-----------------------------------------
------------PREVENT STUDENT INSERTION IF COUNT >30-----------
create trigger UTG_STUDENT_INSERT_PREVENT on Student for insert
as
begin
	declare @count int
	select @count=count(*)
	from Student
	if(@count=30)
	begin
	exec USP_PRINT_STUDENT_FULL
	rollback tran
	end
end
go
-------------PRINT NEAREST DELETED STUDENT------------------------------
create trigger UTG_STUDENT_DELETE on Student after delete, update
as
	declare @sl_id char(8)
	declare @sl_name nvarchar(100)
begin
	select @sl_id=D.S_id,@sl_name=D.name
	from deleted D
	EXEC USP_PRINT_STUDENT @sl_id,@sl_name;
end
go
-------------PRINT NEAREST INSERTED STUDENT----------------------------
create trigger UTG_STUDENT_INSERT on Student after insert
as
	declare @sl_id char(8)
	declare @sl_name nvarchar(100)
begin
	select @sl_id=I.S_id,@sl_name=I.name
	from inserted I
	EXEC USP_PRINT_STUDENT @sl_id,@sl_name;
end
go


