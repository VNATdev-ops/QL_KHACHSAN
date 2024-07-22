USE QL_KHACH_SAN;

-- Qu?n lý Phòng
INSERT INTO Phong (PhongID, SoPhong, LoaiPhong, GiaTien, TinhTrang) VALUES
('1','101', N'Phòng Standard', 1000000, N'Trống'),
('2','102', N'Phòng Deluxe', 1500000, N'Đang sử dụng'),
('3','103', N'Phòng Suite', 2500000, N'Trống'),
('4','104', N'Phòng VIP', 3000000, N'Trống'),
('5','105', N'Phòng Đơn', 800000, N'Đang sử dụng'),
('6','106', N'Phòng Đôi', 1200000, N'Trống'),
('7','107', N'Phòng Gia Đình', 1800000, N'Đang sử dụng'),
('8','108', N'Phòng Hoàng Gia', 5000000, N'Trống'),
('9','109', N'Phòng Thường', 600000, N'Đang sử dụng'),
('10','110', N'Phòng Executive', 2800000, N'Trống');

DELETE FROM Phong;
select * from Phong;

-- Qu?n lý Khách Hàng
INSERT INTO KhachHang (KhachHangID , TenKhachHang, SoDienThoai, DiaChi, Email) VALUES 
('01',N'Nguyễn Văn A', '0912345678', N'Thành phố Thủ Đức', 'a.nguyen@example.com'),
('02',N'Trần Thị B', '0938549986', N'Quận 1', 'b.tran@example.com'),
('03',N'Nguyễn Hiếu Học', '0938358646', N'Quận 3', 'john.doe@example.com'),
('04',N'Phạm Minh Giang', '0912345678', N'Quận 4', 'jane.smith@example.com'),
('05',N'Hồ Chí Thành', '0938951016', N'Quận 5', 'michael.brown@example.com'),
('06',N'Vũ Ðức Phong', '0901234567', N'Quận 6', 'sarah.jones@example.com'),
('07',N'Lê Ðông Nguyên ', '0934567890', N'Quận 7', 'david.johnson@example.com'),
('08',N'Phạm Tùng Lâm', '0967890123', N'Quận 8', 'emily.williams@example.com'),
('09',N'Bùi Quốc Minh', '0987123456', N'Quận 9', 'daniel.miller@example.com'),
('10',N'Trần Hữu Thiện', '0921345678', N'Quận 10', 'sophia.davis@example.com'),
('11',N'Vũ Hướng Dương', '03312345678', N'Quận 11', 'james.wilson@example.com'),
('12',N'Trần Hoàng Phát', '03498765432', N'Quận 12', 'mia.moore@example.com'),
('13',N'Lại Minh Khánh', '03523456789', N'Quận Bình Tân', 'william.taylor@example.com'),
('14',N'Ngô Khánh Hội', '03678901234', N'Quận Bình Thạnh', 'olivia.thomas@example.com'),
('15',N'Trần Lê Minh Thiện', '03756789012', N'Quận Gò Vấp', 'isabella.jackson@example.com'),
('16',N'Hà Công Hiếu', '03722789012', N'Quận Tân Phú', 'ava.harris@example.com'),
('17',N'Nguyễn Trọng Nghĩa', '09956789012', N'Huyện Nhà Bè', 'alexander.martin@example.com');


DELETE FROM KhachHang;
SELECT * FROM KhachHang;



-- Qu?n lý ??t Phòng
-- Chèn dữ liệu vào bảng DatPhong sử dụng các giá trị PhongID từ 1 đến 20 từ bảng Phong
INSERT INTO DatPhong (DatPhongID, PhongID, KhachHangID, NgayDat, NgayNhan, NgayTra, TinhTrang)
VALUES 
(1,1, 1, '2024-07-01', '2024-07-10', '2024-07-15', N'Đã đặt'),
(2,2, 2, '2024-07-02', '2024-07-12', '2024-07-20', N'Đang sử dụng'),
(3,3, 3, '2024-07-03', '2024-07-11', '2024-07-16', N'Đã đặt'),
(4,4, 4, '2024-07-04', '2024-07-13', '2024-07-17', N'Đã đặt'),
(5,5, 5, '2024-07-05', '2024-07-14', '2024-07-18', N'Đang sử dụng'),
(6,6, 6, '2024-07-06', '2024-07-15', '2024-07-19', N'Đã đặt'),
(7,7, 7, '2024-07-07', '2024-07-16', '2024-07-20', N'Đã đặt'),
(8,8, 8, '2024-07-08', '2024-07-17', '2024-07-21', N'Đang sử dụng'),
(9,9, 9, '2024-07-09', '2024-07-18', '2024-07-22', N'Đã đặt'),
(10,10, 10, '2024-07-10', '2024-07-19', '2024-07-23', N'Đã đặt');


delete from DatPhong;
select * from DatPhong;

-- L?ch S? Khách Hàng
INSERT INTO LichSuKhachHang ( LichSuID ,KhachHangID, PhongID, NgayNhan, NgayTra) VALUES
(1,1, 1, '2024-07-01', '2024-07-10'),
(2,2, 2, '2024-07-02', '2024-07-12'),
(3,3, 3, '2024-07-03', '2024-07-11'),
(4,4, 4, '2024-07-04', '2024-07-13'),
(5,5, 5, '2024-07-05', '2024-07-14'),
(6,6, 6, '2024-07-06', '2024-07-15'),
(7,7, 7, '2024-07-07', '2024-07-16'),
(8,8, 8, '2024-07-08', '2024-07-17'),
(9,9, 9, '2024-07-09', '2024-07-18'),
(10 ,10, 10, '2024-07-10', '2024-07-19');

delete from LichSuKhachHang;
select * from LichSuKhachHang;

-- Qu?n lý Thanh Toán
INSERT INTO HoaDon (HoaDonID,DatPhongID, NgayLap, TongTien) VALUES
(1, 1, '2024-07-01', 1500000),
(2, 2, '2024-07-02', 2000000),
(3, 3, '2024-07-03', 1800000),
(4, 4, '2024-07-04', 2500000),
(5, 5, '2024-07-05', 1200000),
(6, 6, '2024-07-06', 3000000),
(7, 7, '2024-07-07', 2200000),
(8, 8, '2024-07-08', 1900000),
(9, 9, '2024-07-09', 2100000),
(10, 10, '2024-07-10', 2800000);

delete from HoaDon
select * from HoaDon;

-- Qu?n lý D?ch V?
INSERT INTO DichVu (DichVuID, TenDichVu, GiaTien) VALUES
(1, N'Dịch vụ giặt là', 50000),
(2, N'Dịch vụ đưa đón sân bay', 800000),
(3, N'Dịch vụ thuê xe máy', 200000),
(4, N'Dịch vụ spa', 1000000),
(5, N'Dịch vụ nhà hàng', 500000),
(6, N'Dịch vụ hướng dẫn du lịch', 300000),
(7, N'Dịch vụ phòng họp', 600000),
(8, N'Dịch vụ cho thuê đồ lặn', 400000),
(9, N'Dịch vụ thuê máy chụp hình', 700000),
(10, N'Dịch vụ mát xa', 900000);

delete from DichVu
select * from DichVu;

-- ??t D?ch V?
INSERT INTO DatDichVu (DatDichVuID, DichVuID, DatPhongID, NgayDat) VALUES
(1, 1, 1, '2024-07-01'),
(2, 2, 2, '2024-07-02'),
(3, 3, 3, '2024-07-03'),
(4, 4, 4, '2024-07-04'),
(5, 5, 5, '2024-07-05'),
(6, 6, 6, '2024-07-06'),
(7, 7, 7, '2024-07-07'),
(8, 8, 8, '2024-07-08'),
(9, 9, 9, '2024-07-09'),
(10, 10, 10, '2024-07-10');

delete from DatDichVu
select * from DatDichVu;

-- Qu?n lý Nhân Viên
INSERT INTO NhanVien (NhanVienID, TenNhanVien, ViTri, Luong) VALUES
(1, N'Nguyễn Văn X', N'Quản lý', 15000000),
(2, N'Trần Thị Y', N'Nhân viên lễ tân', 8000000),
(3, N'Phạm Minh Z', N'Nhân viên phục vụ', 7000000),
(4, N'Lê Thị W', N'Nhân viên bảo vệ', 6000000),
(5, N'Hoàng Văn Q', N'Kế toán', 12000000),
(6, N'Nguyễn Thị T', N'Nhân viên dọn phòng', 6000000),
(7, N'Lê Văn S', N'Bảo trì', 9000000),
(8, N'Vũ Thị H', N'Nhân viên spa', 10000000),
(9, N'Đinh Văn G', N'Hướng dẫn viên du lịch', 11000000),
(10, N'Nguyễn Thị K', N'Nhân viên bán hàng', 8000000),
(11, N'Ngô Văn L', N'Chăm sóc khách hàng', 7000000),
(12, N'Đặng Thị M', N'Nhân viên tiếp thị', 8000000),
(13, N'Hoàng Văn N', N'Đầu bếp', 9000000),
(14, N'Lê Thị P', N'Trưởng phòng', 20000000),
(15, N'Trần Văn Q', N'Giám đốc điều hành', 25000000),
(16, N'Phan Thị R', N'Phục vụ phòng họp', 8000000),
(17, N'Nguyễn Văn S', N'Nhân viên vệ sinh', 6000000),
(18, N'Lê Thị T', N'Chuyên viên IT', 15000000),
(19, N'Nguyễn Văn U', N'Nhân viên đặt vé', 7000000),
(20, N'Lê Thị V', N'Thư ký', 10000000);

delete from NhanVien
select * from NhanVien;

-- L?ch Làm Vi?c
INSERT INTO LichLamViec (LichLamViecID, NhanVienID, NgayLam, CaLam) VALUES
(1, 1, '2024-07-01', N'Sáng'),
(2, 2, '2024-07-01', N'Chiều'),
(3, 3, '2024-07-02', N'Tối'),
(4, 4, '2024-07-02', N'Sáng'),
(5, 5, '2024-07-03', N'Chiều'),
(6, 6, '2024-07-03', N'Tối'),
(7, 7, '2024-07-04', N'Sáng'),
(8, 8, '2024-07-04', N'Chiều'),
(9, 9, '2024-07-05', N'Tối'),
(10, 10, '2024-07-06', N'Sáng'),
(11, 11, '2024-07-06', N'Chiều'),
(12, 12, '2024-07-07', N'Tối'),
(13, 13, '2024-07-08', N'Sáng'),
(14, 14, '2024-07-08', N'Chiều'),
(15, 15, '2024-07-09', N'Tối');

delete from LichLamViec
select * from LichLamViec;

-- Qu?n lý B?o Trì
INSERT INTO BaoCaoSuCo (SuCoID, PhongID, NhanVienID, MoTa, NgayBaoCao) VALUES
(1, 1, 1, N'Lỗi hệ thống điện', '2024-07-01'),
(2, 2, 2, N'Hỏng thiết bị máy lạnh', '2024-07-02'),
(3, 3, 3, N'Cần thay đổi đồ nội thất', '2024-07-03'),
(4, 4, 4, N'Sửa chữa cửa sổ bể phòng', '2024-07-04'),
(5, 5, 5, N'Tiếng ồn phòng kế bên', '2024-07-05'),
(6, 6, 6, N'Đèn hồ bơi bị hỏng', '2024-07-06'),
(7, 7, 7, N'Tháo dỡ thiết bị cũ', '2024-07-07'),
(8, 8, 8, N'Thông cống nước', '2024-07-08'),
(9, 9, 9, N'Sửa chữa máy nước nóng', '2024-07-09'),
(10, 10, 10, N'Vệ sinh sàn phòng', '2024-07-10');

delete from BaoCaoSuCo
select * from BaoCaoSuCo;


INSERT INTO LichBaoTri (LichBaoTriID , PhongID, NhanVienID, NgayBaoTri, MoTa) VALUES
(1, 1, 1, '2024-07-01', N'Kiểm tra hệ thống điện'),
(2, 2, 2, '2024-07-02', N'Sửa chữa máy lạnh'),
(3, 3, 3, '2024-07-03', N'Thay đổi đồ nội thất'),
(4, 4, 4, '2024-07-04', N'Sửa chữa cửa sổ'),
(5, 5, 5, '2024-07-05', N'Kiểm tra tiếng ồn'),
(6, 6, 6, '2024-07-06', N'Sửa chữa đèn hồ bơi'),
(7, 7, 7, '2024-07-07', N'Tháo dỡ thiết bị cũ'),
(8, 8, 8, '2024-07-08', N'Thông cống nước'),
(9, 9, 9, '2024-07-09', N'Sửa chữa máy nước nóng'),
(10, 10, 10, '2024-07-10', N'Vệ sinh sàn phòng');

delete from LichBaoTri
select * from LichBaoTri;
