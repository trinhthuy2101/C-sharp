use DBServer
go
create unique index id on Student(S_id)
go
create index info on Student(name,dob)
go
create index Dep on Department(D_id)
go