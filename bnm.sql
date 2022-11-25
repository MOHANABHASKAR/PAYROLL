create database bnm
use bnm
create  table data_q
(
  userid varchar(50) not null unique  ,
 
 position varchar(10) ,
 salary int,
 tax int)







 

insert into data_q values('kalyansriram20', 'software' ,45000,230)
insert into data_q values('kalyansriram30', 'software' ,48000,235)
insert into data_q values('kalyansriram40' ,'software' ,49000,240)






CREATE PROCEDURE check_a @id varchar(50) AS
begin
  select userid from data_q where userid=@id
 end



exec check_a '@id' 
select * from data_q
CREATE PROCEDURE user_details @id varchar(50) AS
BEGIN
SELECT * from data_q where userid = @id
END


exec user_details '@id'
CREATE PROCEDURE add_a @ide varchar(50),@positio varchar(10),@salar int,@taxa int AS
begin
insert into data_q values(@ide,@positio,@salar,@taxa)
end

exec add_a '@ide','@positio',@salar,@taxa

select * from data_q
CREATE PROCEDURE delete_a @id varchar(50) AS
BEGIN
delete   from data_q where userid = @id
END
exec delete_a '@id'
CREATE PROCEDURE total_sa @id varchar(50) AS
begin
declare @ts int
declare @sal int
declare @ta int
set @sal = (select salary from data_q where userid=@id)
set @ta =  (select tax from data_q where userid=@id)
set @ts= @sal  - @ta
select @ts
end




exec total_sa '@id'




select * from  data_q
