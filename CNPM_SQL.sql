CREATE DATABASE Congnghephanmem_64131196	
GO
USE Congnghephanmem_64131196
GO
CREATE TABLE VaiTro (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100)
);
GO
CREATE TABLE GoiTap (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(50),
    Gia INT
);
GO
CREATE TABLE KhachHang (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100),
    GioiTinh BIT,
    SoDienThoai NVARCHAR(10),
    AnhDaiDien VARCHAR(100),
    NgayDangKyLanDau DATETIME,
    NgayBatDauGoiTap DATETIME,
    NgayKetThucGoiTap DATETIME,
    TinhTrangThanhToan BIT,
    MaVaiTro INT FOREIGN KEY REFERENCES VaiTro(ID),
    MaGoiTap INT FOREIGN KEY REFERENCES GoiTap(ID),
    TaiKhoan VARCHAR(100),
    MatKhau VARCHAR(100)
);
GO
CREATE TABLE HuanLuyenVien (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100),
    GioiTinh BIT,
    SoDienThoai VARCHAR(10),
    AnhDaiDien VARCHAR(100),
    MaVaiTro INT FOREIGN KEY REFERENCES VaiTro(ID),
    TaiKhoan VARCHAR(100),
    MatKhau VARCHAR(100)
);
GO
CREATE TABLE NguoiQuanTri (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100),
    MaVaiTro INT FOREIGN KEY REFERENCES VaiTro(ID),
    TaiKhoan VARCHAR(100),
    MatKhau VARCHAR(100)
);
GO
CREATE TABLE LichLamViecPT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(ID),
    Thu INT,
    GioBatDau TIME,
    GioKetThuc TIME
);
GO
CREATE TABLE Comments (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(ID),
    MaKH INT FOREIGN KEY REFERENCES KhachHang(ID),
    Diem INT,
    NhanXet NVARCHAR(1000),
    NgayDanhGia DATETIME
);
GO
CREATE TABLE DatLichPT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(ID),
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(ID),
    NgayTap DATETIME,
    GioBatDau TIME,
    GioKetThuc TIME,
    NgayDatLich DATETIME
);
GO
INSERT INTO VaiTro (Ten) VALUES (N'MEMBER');
INSERT INTO VaiTro (Ten) VALUES (N'PT');
INSERT INTO VaiTro (Ten) VALUES (N'ADMIN');
GO
INSERT INTO GoiTap (Ten, Gia) VALUES (N'Gói 1 tháng', 250000);
INSERT INTO GoiTap (Ten, Gia) VALUES (N'Gói 3 tháng', 710000);
INSERT INTO GoiTap (Ten, Gia) VALUES (N'Gói 6 tháng', 1350000);
INSERT INTO GoiTap (Ten, Gia) VALUES (N'Gói 12 tháng', 2540000);
GO
INSERT INTO KhachHang (
    Ten, GioiTinh, SoDienThoai, AnhDaiDien, NgayDangKyLanDau,
    NgayBatDauGoiTap, NgayKetThucGoiTap, TinhTrangThanhToan,
    MaVaiTro, MaGoiTap, TaiKhoan, MatKhau
) VALUES
(N'Khách hàng 1', 1, '0900000001', 'employee.png', '2025-01-02 08:00:00', '2025-01-10 08:00:00', '2025-02-10 08:00:00', 1, 1, 2, 'user1', '1'),
(N'Khách hàng 2', 0, '0900000002', 'employee.png', '2025-01-03 08:00:00', '2025-01-10 08:00:00', '2025-02-10 08:00:00', 1, 1, 3, 'user2', '1'),
(N'Khách hàng 3', 1, '0900000003', 'employee.png', '2025-01-04 08:00:00', '2025-01-10 08:00:00', '2025-02-10 08:00:00', 1, 1, 4, 'user3', '1'),
(N'Khách hàng 4', 0, '0900000004', 'employee.png', '2025-01-05 08:00:00', '2025-01-10 08:00:00', '2025-02-10 08:00:00', 1, 1, 1, 'user4', '1'),
(N'Khách hàng 5', 1, '0900000005', 'employee.png', '2025-01-06 08:00:00', '2025-01-10 08:00:00', '2025-02-10 08:00:00', 1, 1, 2, 'user5', '1');
GO
INSERT INTO HuanLuyenVien (
    Ten, GioiTinh, SoDienThoai, AnhDaiDien,
    MaVaiTro, TaiKhoan, MatKhau
) VALUES
(N'Huấn luyện viên 1', 1, '0911111101', 'employee.png', 2, 'pt1', '1'),
(N'Huấn luyện viên 2', 0, '0911111102', 'employee.png', 2, 'pt2', '1'),
(N'Huấn luyện viên 3', 1, '0911111103', 'employee.png', 2, 'pt3', '1'),
(N'Huấn luyện viên 4', 0, '0911111104', 'employee.png', 2, 'pt4', '1'),
(N'Huấn luyện viên 5', 1, '0911111105', 'employee.png', 2, 'pt5', '1');
GO
INSERT INTO NguoiQuanTri (
    Ten, MaVaiTro, TaiKhoan, MatKhau
) VALUES
(N'ADMIN1', 3, 'admin1', '1'),
(N'ADMIN2', 3, 'admin2', '1'),
(N'ADMIN3', 3, 'admin3', '1'),
(N'ADMIN3', 3, 'admin4', '1'),
(N'ADMIN4', 3, 'admin5', '1');
GO
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (1, 2, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (1, 3, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (1, 4, '10:00:00', '11:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (1, 5, '13:00:00', '14:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (1, 6, '08:00:00', '09:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (1, 7, '15:00:00', '16:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (2, 2, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (2, 3, '15:00:00', '16:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (2, 4, '15:30:00', '16:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (2, 5, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (2, 6, '15:00:00', '16:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (2, 7, '20:00:00', '21:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (3, 2, '20:00:00', '21:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (3, 3, '09:00:00', '10:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (3, 4, '18:00:00', '19:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (3, 5, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (3, 6, '21:00:00', '22:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (3, 7, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (4, 2, '08:30:00', '09:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (4, 3, '08:30:00', '09:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (4, 4, '15:30:00', '16:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (4, 5, '18:30:00', '18:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (4, 6, '19:00:00', '20:00:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (4, 7, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (5, 2, '07:30:00', '08:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (5, 3, '08:30:00', '09:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (5, 4, '21:30:00', '22:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (5, 5, '20:30:00', '21:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (5, 6, '19:30:00', '20:30:00');
INSERT INTO LichLamViecPT (MaPT, Thu, GioBatDau, GioKetThuc) VALUES (5, 7, '18:00:00', '19:00:00');


