CREATE DATABASE QL_KHACH_SAN

USE QL_KHACH_SAN

-- Quản lý Phòng
CREATE TABLE Phong (
    PhongID INT PRIMARY KEY IDENTITY(1,1),
    SoPhong NVARCHAR(50) NOT NULL,
    LoaiPhong NVARCHAR(100),
    GiaTien DECIMAL(18,2),
    TinhTrang NVARCHAR(50)
);

-- Quản lý Đặt Phòng
CREATE TABLE DatPhong (
    DatPhongID INT PRIMARY KEY IDENTITY(1,1),
    PhongID INT FOREIGN KEY REFERENCES Phong(PhongID),
    KhachHangID INT FOREIGN KEY REFERENCES KhachHang(KhachHangID),
    NgayDat DATETIME,
    NgayNhan DATETIME,
    NgayTra DATETIME,
    TinhTrang NVARCHAR(50)
);

-- Quản lý Khách Hàng
CREATE TABLE KhachHang (
    KhachHangID INT PRIMARY KEY IDENTITY(1,1),
    TenKhachHang NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    DiaChi NVARCHAR(255),
    Email NVARCHAR(100)
);

CREATE TABLE LichSuKhachHang (
    LichSuID INT PRIMARY KEY IDENTITY(1,1),
    KhachHangID INT FOREIGN KEY REFERENCES KhachHang(KhachHangID),
    PhongID INT FOREIGN KEY REFERENCES Phong(PhongID),
    NgayNhan DATETIME,
    NgayTra DATETIME
);

-- Quản lý Thanh Toán
CREATE TABLE HoaDon (
    HoaDonID INT PRIMARY KEY IDENTITY(1,1),
    DatPhongID INT FOREIGN KEY REFERENCES DatPhong(DatPhongID),
    NgayLap DATETIME,
    TongTien DECIMAL(18,2)
);

-- Quản lý Dịch Vụ
CREATE TABLE DichVu (
    DichVuID INT PRIMARY KEY IDENTITY(1,1),
    TenDichVu NVARCHAR(100),
    GiaTien DECIMAL(18,2)
);

CREATE TABLE DatDichVu (
    DatDichVuID INT PRIMARY KEY IDENTITY(1,1),
    DichVuID INT FOREIGN KEY REFERENCES DichVu(DichVuID),
    DatPhongID INT FOREIGN KEY REFERENCES DatPhong(DatPhongID),
    NgayDat DATETIME
);

-- Báo Cáo và Thống Kê
-- Thường là các view hoặc stored procedure để tạo báo cáo

-- Quản lý Nhân Viên
CREATE TABLE NhanVien (
    NhanVienID INT PRIMARY KEY IDENTITY(1,1),
    TenNhanVien NVARCHAR(100),
    ViTri NVARCHAR(100),
    Luong DECIMAL(18,2)
);

CREATE TABLE LichLamViec (
    LichLamViecID INT PRIMARY KEY IDENTITY(1,1),
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),
    NgayLam DATETIME,
    CaLam NVARCHAR(50)
);

-- Quản lý Bảo Trì
CREATE TABLE BaoCaoSuCo (
    SuCoID INT PRIMARY KEY IDENTITY(1,1),
    PhongID INT FOREIGN KEY REFERENCES Phong(PhongID),
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),
    MoTa NVARCHAR(255),
    NgayBaoCao DATETIME
);

CREATE TABLE LichBaoTri (
    LichBaoTriID INT PRIMARY KEY IDENTITY(1,1),
    PhongID INT FOREIGN KEY REFERENCES Phong(PhongID),
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),
    NgayBaoTri DATETIME,
    MoTa NVARCHAR(255)
);
