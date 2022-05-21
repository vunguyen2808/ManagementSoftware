USE [master]
CREATE DATABASE [QLShoes]
CONTAINMENT = NONE
ON PRIMARY
( NAME = N'QuanLyShop', FILENAME = N'C:\Database\QuanLyShop.mdf' , SIZE = 3136KB ,
MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
LOG ON
( NAME = N'QuanLyShop_log', FILENAME = N'C:\Database\QuanLyShop_log.ldf' , SIZE = 784KB ,
MAXSIZE = 2048GB , FILEGROWTH = 10%)

USE [QLShoes]
CREATE TABLE [dbo].[DangNhap](
[TaiKhoan] [nvarchar](20) NOT NULL,
[MatKhau] [nvarchar](20) NOT NULL,
[Quyen] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED ([TaiKhoan] ASC)
)
CREATE TABLE [dbo].[NhanVien](
[MaNhanVien] [nvarchar](20) NOT NULL,
[TenNhanVien] [nvarchar](30) NOT NULL,
[TaiKhoan] [nvarchar](20) NULL,
[Quyen] [nvarchar](10) NOT NULL,
[GioiTinh] [nvarchar](10) NULL,
[DiaChi] [nvarchar](50) NULL,
[DienThoai] [nvarchar](20) NULL,
[NgaySinh] DATE NULL,
PRIMARY KEY CLUSTERED ([MaNhanVien] ASC)
)
CREATE TABLE [dbo].[KhachHang](
[MaKhachHang] [nvarchar](20) NOT NULL,
[TenKhachHang] [nvarchar](30) NOT NULL,
[DiaChi] [nvarchar](50) NULL,
[DienThoai] [nvarchar](20) NULL,
[GioiTinh] [nvarchar](10) NULL,
[NgaySinh] DATE NULL
PRIMARY KEY CLUSTERED ([MaKhachHang] ASC)
)
CREATE TABLE [dbo].[KhoChatLieu](
[MaChatLieu] [nvarchar](20) NOT NULL,
[TenChatLieu] [nvarchar](30) NOT NULL,
[SoLuong] [float](3) NULL,
[DonVi] [nvarchar](30) NULL,
[Hinh] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED ([MaChatLieu] ASC) 
)
CREATE TABLE [dbo].[DichVu](
[MaDichVu] [nvarchar](20) NOT NULL,
[TenDichVu] [nvarchar](30) NOT NULL,
[MaChatLieu] [nvarchar](20) NOT NULL,
[MucTieuHao] [float](3) NULL,
[SoLuongChatLieu] [float](3) NULL,
[DonGiaNhap] [decimal] NULL,
[DonGiaBan] [decimal] NULL,
[GhiChu] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED ([MaDichVu] ASC)
)
CREATE TABLE [dbo].[HoaDon](
[MaHoaDon] [nvarchar](20) NOT NULL,
[MaKhachHang] [nvarchar](20) NOT NULL,
[MaNhanVien] [nvarchar](20) NOT NULL,
[NgayBan] DATE NOT NULL,
[CaBan] [nvarchar](30) NOT NULL,
[TongTien] [decimal] NULL,
[TienNhan] [decimal] NULL,
[TienThua] [decimal] NULL,
PRIMARY KEY CLUSTERED ([MaHoaDon] ASC)
)
CREATE TABLE [dbo].[CTHoaDon](
[MaGiay] [nvarchar](20) NOT NULL,
[MaHoaDon] [nvarchar](20) NOT NULL,
[MaDichVu] [nvarchar](20) NOT NULL,
[SoLuong] [int] NULL,
[DonGia] [decimal] NULL,
[GiamGia] [int] NULL,
[ThanhTien] [decimal] NULL,
PRIMARY KEY CLUSTERED ([MaHoaDon] ASC, [MaDichVu] ASC, [MaGiay] ASC)
)
CREATE TABLE [dbo].[CTGiay](
[MaHoaDon][nvarchar](20) NOT NULL,
[MaGiay] [nvarchar](20) NOT NULL,
[HangGiay] [nvarchar](30) NULL,
[TenGiay] [nvarchar](30) NOT NULL,
[MaDichVu] [nvarchar](20) NOT NULL,
[GhiChu] [nvarchar](150) NULL,
[Hinh] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED ([MaHoaDon] ASC, [MaDichVu] ASC, [MaGiay] ASC)
)

ALTER TABLE [dbo].[NhanVien] WITH CHECK ADD FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[DangNhap] ([TaiKhoan])
GO
ALTER TABLE [dbo].[DichVu] WITH CHECK ADD FOREIGN KEY([MaChatLieu])
REFERENCES [dbo].[KhoChatLieu] ([MaChatLieu])
GO
ALTER TABLE [dbo].[CTHoaDon] WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[CTGiay] WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[CTHoaDon] WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[HoaDon] WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[CTGiay] WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO

--Query data
use [QLShoes]
GO
SELECT * FROM DangNhap
SELECT * FROM KhoChatLieu
SELECT * FROM DichVu
SELECT * FROM NhanVien
SELECT * FROM KhachHang
SELECT * FROM HoaDon
SELECT * FROM CTHoaDon
SELECT * FROM CTGiay
GO
