--Insert data
use [QLShoes]
GO
INSERT INTO DangNhap (TaiKhoan,MatKhau,Quyen) VALUES (N'admin', N'admin', N'Admin')
INSERT INTO KhoChatLieu (MaChatLieu, TenChatLieu, SoLuong, DonVi, Hinh) VALUES (N'CL9182021_183953',N'Angelus White',60,N'ml','')
INSERT INTO KhoChatLieu (MaChatLieu, TenChatLieu, SoLuong, DonVi, Hinh) VALUES (N'CL9182021_183954',N'Angelus Black',60,N'ml','')
INSERT INTO KhoChatLieu (MaChatLieu, TenChatLieu, SoLuong, DonVi, Hinh) VALUES (N'CL9182021_183955',N'Basic hygiene',1000,N'Peace','')
INSERT INTO KhoChatLieu (MaChatLieu, TenChatLieu, SoLuong, DonVi, Hinh) VALUES (N'CL9182021_183956',N'Advanced hygiene',1000,N'Peace','')
INSERT INTO DichVu (MaDichVu, TenDichVu, MaChatLieu, MucTieuHao, SoLuongChatLieu, DonGiaNhap, DonGiaBan, GhiChu) VALUES (N'DV9182021_184345',N'Repaint White',N'CL9182021_183953',3,20,7000,299000,N'BH 30 ngày')
INSERT INTO DichVu (MaDichVu, TenDichVu, MaChatLieu, MucTieuHao, SoLuongChatLieu, DonGiaNhap, DonGiaBan, GhiChu) VALUES (N'DV9182021_184346',N'Repaint Black',N'CL9182021_183954',3,20,7000,299000,N'BH 30 ngày')
INSERT INTO DichVu (MaDichVu, TenDichVu, MaChatLieu, MucTieuHao, SoLuongChatLieu, DonGiaNhap, DonGiaBan, GhiChu) VALUES (N'DV9182021_184347',N'Basic hygiene',N'CL9182021_183955',1,1000,5000,99000,N'BH 1 ngày')
INSERT INTO DichVu (MaDichVu, TenDichVu, MaChatLieu, MucTieuHao, SoLuongChatLieu, DonGiaNhap, DonGiaBan, GhiChu) VALUES (N'DV9182021_184348',N'Advanced hygiene',N'CL9182021_183956',1,1000,5000,99000,N'BH 1 ngày')
INSERT INTO DangNhap (TaiKhoan,MatKhau,Quyen) VALUES (N'vu', N'123', N'CS')
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, TaiKhoan, Quyen, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'NV9182021_184752',N'Quang Vu',N'vu',N'CS',N'Male',N'217 Bui Dinh Tuy',N'0908087565','20210918')
INSERT INTO DangNhap (TaiKhoan,MatKhau,Quyen) VALUES (N'lam', N'123', N'QC')
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, TaiKhoan, Quyen, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'NV9182021_184753',N'Bao Lam',N'lam',N'QC',N'Male',N'218 Bui Dinh Tuy',N'0901111111','20210918')
INSERT INTO DangNhap (TaiKhoan,MatKhau,Quyen) VALUES (N'dat', N'123', N'Waitting')
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, TaiKhoan, Quyen, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (N'NV9182021_184754',N'Bap Dat',N'dat',N'CS',N'Male',N'219 Bui Dinh Tuy',N'0902222222','20210918')
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, DienThoai, GioiTinh, NgaySinh) VALUES (N'KH9182021_190143',N'Chi 7',N'1100 Phu Nhuan, HCM',N'0905555555',N'Female','20210918')
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, DienThoai, GioiTinh, NgaySinh) VALUES (N'KH9182021_190144',N'Ngoc Hoa',N'201 Binh Thanh, HCM',N'0907895623',N'Male','20210918')
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, DienThoai, GioiTinh, NgaySinh) VALUES (N'KH9182021_190145',N'Thuy Vy',N'302 Thu Duc, HCM',N'0908887645',N'Female','20210918')
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, DienThoai, GioiTinh, NgaySinh) VALUES (N'KH9182021_190146',N'Thanh Truc',N'37/1 Phu Nhuan, HCM',N'0909999999',N'Female','20210918')
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, CaBan, TongTien, TienNhan, TienThua) VALUES (N'HD9182021_190748',N'KH9182021_190143',N'NV9182021_184752','20210921',N'Ca Chieu',299000,300000,1000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191311',N'HD9182021_190748',N'DV9182021_184345',1,299000,0,299000)
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190748',N'S9182021_191311',N'Nike',N'AF1',N'DV9182021_184345',N'Tray da','')
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, CaBan, TongTien, TienNhan, TienThua) VALUES (N'HD9182021_190749',N'KH9182021_190145',N'NV9182021_184752','20210922',N'Ca Sang',1495000,1500000,5000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191312',N'HD9182021_190749',N'DV9182021_184345',1,299000,0,299000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191313',N'HD9182021_190749',N'DV9182021_184346',1,299000,0,299000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191314',N'HD9182021_190749',N'DV9182021_184347',1,299000,0,299000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191315',N'HD9182021_190749',N'DV9182021_184348',1,299000,0,299000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191316',N'HD9182021_190749',N'DV9182021_184345',1,299000,0,299000)
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190749',N'S9182021_191312',N'Nike',N'AF1',N'DV9182021_184345',N'Tray da','')
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190749',N'S9182021_191313',N'Bitis',N'Hunter',N'DV9182021_184346',N'Tray da','')
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190749',N'S9182021_191314',N'MLB',N'NY',N'DV9182021_184347',N'Tray da','')
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190749',N'S9182021_191315',N'MLB',N'Mickey',N'DV9182021_184348',N'Tray da','')
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190749',N'S9182021_191316',N'Adidas',N'Yeezy',N'DV9182021_184345',N'Tray da','')
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, CaBan, TongTien, TienNhan, TienThua) VALUES (N'HD9182021_190750',N'KH9182021_190143',N'NV9182021_184752','20210821',N'Ca Chieu',299000,300000,1000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191317',N'HD9182021_190750',N'DV9182021_184345',1,299000,0,299000)
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190750',N'S9182021_191317',N'Nike',N'AF1',N'DV9182021_184345',N'Tray da','')
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, CaBan, TongTien, TienNhan, TienThua) VALUES (N'HD9182021_190751',N'KH9182021_190143',N'NV9182021_184752','20210721',N'Ca Chieu',299000,300000,1000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191318',N'HD9182021_190751',N'DV9182021_184345',1,299000,0,299000)
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190751',N'S9182021_191318',N'Nike',N'AF1',N'DV9182021_184345',N'Tray da','')
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, CaBan, TongTien, TienNhan, TienThua) VALUES (N'HD9182021_190752',N'KH9182021_190143',N'NV9182021_184752','20210621',N'Ca Chieu',598000,600000,2000)
INSERT INTO CTHoaDon (MaGiay, MaHoaDon, MaDichVu, SoLuong, DonGia, GiamGia, ThanhTien) VALUES (N'S9182021_191319',N'HD9182021_190752',N'DV9182021_184345',2,299000,0,299000)
INSERT INTO CTGiay (MaHoaDon, MaGiay, HangGiay, TenGiay, MaDichVu, GhiChu, Hinh) VALUES (N'HD9182021_190752',N'S9182021_191319',N'Nike',N'AF1',N'DV9182021_184345',N'Tray da','')
GO

--Delete data
use [QLShoes]
GO
DELETE FROM [dbo].[CTHoaDon]
DELETE FROM [dbo].[CTGiay]
DELETE FROM [dbo].[HoaDon]
DELETE FROM [dbo].[NhanVien]
DELETE FROM [dbo].[KhachHang]
DELETE FROM [dbo].[DangNhap]
DELETE FROM [dbo].[DichVu]
DELETE FROM [dbo].[KhoChatLieu]
GO