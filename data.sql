insert into tblNhanvien values ('1', '1', 'nv1@gmail.com', N'Nhân Viên Một', 973552857, 1)
insert into tblNhanvien values ('2', '2', 'nv2@gmail.com', N'Nhân Viên Hai', 373552857, 1)
insert into tblNhanvien values ('3', '3', 'nv3@gmail.com', N'Nhân Viên Ba', 373552857, 2)

select * from tblNhanvien

insert into tblSinhvien values ('14A1010001', '1', 'email1@gmail.com', N'Trần Văn Một', N'1/1/1996', 1, 'HN', '123456789')
insert into tblSinhvien values ('14A1010002', '2', 'email2@gmail.com', N'Nguyễn Thị Hai', N'2/1/1996', 0, 'HN3', '123543789')
insert into tblSinhvien values ('14A1010003', '3', 'email3@gmail.com', N'Thầy Giáo Ba', N'1/3/1996', 1, 'HN2', '321456789')

select * from tblSinhvien

insert into tblPhongban values (N'PB1', N'Phòng 14')
insert into tblPhongban values (N'PB1', N'Phòng 33')
insert into tblPhongban values (N'PB1', N'Phòng phó khoa')

select * from tblPhongban

select * from tblDontu

insert into tblLoaiDontu values (N'Đơn xin nghỉ')
insert into tblLoaiDontu values (N'Đơn xin bảo lưu')
insert into tblLoaiDontu values (N'Đơn xin đóng học phí muộn')

select * from tblLoaiDontu


select * from tblLoaiDontu
