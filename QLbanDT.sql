CREATE DATABASE DATA_DT
GO

USE DATA_DT
GO

-- Tạo bảng khách hàng
CREATE TABLE KhachHang
(
   MaKH varchar(10) primary key DEFAULT 'null',
   HoKH  nvarchar(20) NOT NULL DEFAULT 'trống',
   TenKH nvarchar(50) NOT NULL DEFAULT 'trống',
   SDT VARCHAR(10) DEFAULT 'number',
   DiaChi nvarchar(50),
   CCCD varchar(15),
   NgaySinh date,
   Email varchar(30),
   TrangThai int DEFAULT 1
)
GO

--tạo bảng cửa hàng
create table CuaHang
(
	MaCH varchar(10) primary key default 'null',
	TenCH nvarchar(50) default 'trống',
	DiaChi nvarchar(50) default 'trống',
	SDT varchar(11) default 'number', 
	TrangThai int DEFAULT 1
)
GO

--tạo bảng nhân viên
CREATE TABLE NhanVien
(
  MaNV varchar(10) primary key DEFAULT 'null',
  MaCH varchar(10) default 'null',
  HoNV nvarchar(20) NOT NULL DEFAULT 'trống',
  TenNV nvarchar(50) NOT NULL DEFAULT 'trống',
  SDT varchar(10) DEFAULT 'number',
  DiaChi nvarchar(50),
  Email varchar(30),
  TrangThai int DEFAULT 1
  foreign key(MaCH) references CuaHang(MaCH) -- CuaHang -> MaCH
)

-- tạo bảng hóa đơn
create table HoaDon
(
	MaHD varchar(10) primary key default 'null',
	MaCH varchar(10) default 'null',
	NgayLapHD date,
	Gia money,
	ChietKhau money,
	TrangThai int DEFAULT 1
	foreign key (MaCH) references CuaHang(MaCH) -- CuaHang -> MaCH
)
GO

-- tạo bảng nhà cung cấp
create table NhaCungCap
(
	MaNCC varchar(10) primary key default 'null',
	TenNCC nvarchar(50) default 'trống',
	SDT Char(10),
	DiaChi nvarchar(50),
	Email varchar(30),
	TrangThai int DEFAULT 1
)
GO

--tạo bảng cấu hình
create table CauHinh
(
	MaCauHinh varchar(10) primary key default 'null',
	Ram varchar(15),
	Rom varchar(15),
	Pin varchar(10),
	Chip varchar(15),
	ManHinh nvarchar(50),
	CameraSau nvarchar(50),
	TrangThai int DEFAULT 1
)
GO

-- tạo bảng điện thoại
create table DienThoai
(
  MaDT varchar(10) primary key default 'null',
  MaCauHinh varchar(10) default 'null',
  MaNCC varchar(10) default 'null',
  TenDT nvarchar(50) default 'trống',
  Mau nvarchar(50) default 'trống',
  Hinh VARCHAR(200),
  TinhNang nvarchar(50), 
  SoLuong int,
  Gia Money DEFAULT 1,
  TrangThai int DEFAULT 1
  foreign key (MaCauHinh) references dbo.CauHinh(MaCauHinh), -- CauHinh -> MaCauHinh
  foreign key (MaNCC) references dbo.NhaCungCap(MaNCC) -- NhaCungCap -> MaNCC
)
GO

-- tạo bảng chi tiết hóa đơn bán
CREATE TABLE CTHDBan
(
	MaHDBan varchar(10) DEFAULT 'varchar',
	MaDT varchar(10) default 'null',
	MaKH varchar(10) default 'null',
	MaNV varchar(10) default 'null',
	MaHD varchar(10) default 'null',
	SoLuong int default 0,
	TongGia money default 0,
	NgayBan date,
	TrangThai int DEFAULT 1
	FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV), -- NhanVien -> MaNV 
	foreign key (MaDT) references dbo.DienThoai(MaDT), -- DienThoai -> MaDT
	foreign key (MaKH) references dbo.KhachHang(MaKH), -- KhachHang -> MaKH
	foreign key (MaHD) references dbo.HoaDon(MaHD), -- HoaDon -> MaHD
	primary key (MaDT, MaHDBan)
)
GO

-- tạo bảng chi tiết hóa đơn nhập
create table CTHDNhap
(
	MaHDNhap varchar(10) default 'null',
	MaDT varchar(10) default 'null',
	MaNV varchar(10) default 'null',
	MaHD varchar(10) default 'null',
	MaNCC varchar(10) default 'null',
	Soluong int default 0,
	TongGia money default 0,
	NgayNhap date,
	TrangThai int DEFAULT 1
	foreign key(MaNCC) references dbo.NhaCungCap(MaNCC), -- NhaCungCap -> MaNCC
	foreign key(MaNV) references dbo.NhanVien(MaNV), -- NhanVien -> MaNV
	foreign key(MaHD) references dbo.HoaDon(MaHD), -- HoaDon -> MaHD
	foreign key(MaDT) references dbo.DienThoai(MaDT), -- DienThoai -> MaDT
	primary key (MaDT, MaHDNhap)
)
GO

-- Thêm bảng khách hàng 
INSERT DBO.KhachHang
		(MaKH,
		HoKH,
		TenKH,
		SDT,
		DiaChi,
		CCCD,
		NgaySinh,
		Email,
		TrangThai
		)
VALUES	('00001', -- MaKH - varchar(10)
		N'Trần', -- HoKH - nvarchar(20)
		N'Thị Ngọc', -- TenKH - nvarchar(50)
		'0944572536', -- SDT - varchar(10)
		N'Phường Tân Hưng, quận 4', -- DiaChi - nvarchar(50)
		'065487999482', -- CCCD - varchar(15)
		GETDATE(), -- NgaySinh - date
		'Ngoc@gmail.com', -- Email - varchar(30)
		1 -- TrangThai - int
		)
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00002', N'Nguyễn', N'Thị Châm', '0955572534', N'Phường Tân Hưng, quận 8', '065487473582', GETDATE(), 'cham@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00003', N'Trần', N'Phê Ngọc', '0944872505', N'Phường Nguyễn Hữu Thọ, quận 7', '065487999845', GETDATE(), 'ngoc@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00004', N'Lê', N'Thành Luân', '0944572946', N'Đường 18, quận 10', '065487999936', GETDATE(), 'luan@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00005', N'Nguyễn', N'Thị Hảo Hán', '0944572934', N'Phường Tân Hưng, Bình Thạnh', '065487999357', GETDATE(), 'Han@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00006', N'Trần', N'Thị Ánh', '0944572036', N'Phường Tân Hưng, quận 1', '065487990248', GETDATE(), 'anh@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00007', N'Trần', N'Mai Châu', '0944572074', N'Phường Tân Hưng, quận 2', '065487999074', GETDATE(), 'chau@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00008', N'Trần', N'Hên Ngọc', '0944572043', N'Phường Tân Hưng, quận 5', '065487999538', GETDATE(), 'ngoc@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00009', N'Huỳnh', N'Thị Chánh', '0944572342', N'Phường Tân Hưng, quận 6', '065487999835', GETDATE(), 'chanh@gmail.com', 1 )
INSERT DBO.KhachHang
		(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai)
VALUES	( '00010', N'Trần', N'Như Ngọc', '0944572437', N'Cách mạng tháng 8, quận 10', '065487999839', GETDATE(), 'ngoc@gmail.com', 1 )
GO

-- Thêm bảng cửa hàng
INSERT DBO.CuaHang
		(MaCH,
		TenCH,
		DiaChi,
		SDT,
		TrangThai
		)
VALUES	('01', -- MaCH - varchar(10)
		N'Mai cơm gà', -- TenCH -- nvarchar(50)
		N'Trường Cao Đẳng kỹ thuật Cao Thắng', -- DiaChi - nvarchar(50)
		'0942632795', -- varchar(11)
		1 -- TrangThai - int
		)
GO

-- Thêm bảng nhân viên
INSERT DBO.NhanVien
		(MaNV,
		MaCH,
		HoNV,
		TenNV,
		SDT,
		DiaChi, 
		Email,
		TrangThai
		)
VALUES	('0306211244', -- MaNV - varchar(10)
		'01', -- MaCH - varchar(10)
		N'Trần', -- HoNV - nvarchar(20)
		N'Xuân Hiếu', -- TenNV - nvarchar(50)
		'0942632795', -- SDT - varchar(10)
		N'33 Nguyễn Hữu Thọ', -- DiaChi - nvarchar(50)
		'henri16102938@gmail.com', -- Email - varchar(30)
		1
		)
INSERT DBO.NhanVien
		( MaNV, MaCH, HoNV, TenNV, SDT, DiaChi, Email, TrangThai )
VALUES	('0306211237', '01', N'Cao', N'Hải Đăng', '0942632795', N'33 Nguyễn Hữu Thọ', 'henri16102938@gmail.com', 1)
INSERT DBO.NhanVien
		( MaNV, MaCH, HoNV, TenNV, SDT, DiaChi, Email, TrangThai )
VALUES	('000', '01', N'Trần', N'DH', '0942632374', N'33 Nguyễn Hữu kkk', 'kkk16102938@gmail.com', 1)
GO

-- Thêm bảng hóa đơn
INSERT DBO.HoaDon
		(MaHD,
		MaCH,
		NgayLapHD,
		Gia,
		ChietKhau,
		TrangThai
		)
VALUES	('001', -- MaHD - varchar(10)
		'01', -- MaCH - varchar(10)
		GETDATE(), -- NgayLapHD -- date
		5.000, -- Gia - money
		100.000, -- ChietKhau - money
		1 -- TrangThai - int
		)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('002', '01', GETDATE(), 2.000, 50.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('003', '01', GETDATE(), 24.000, 150.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('004', '01', GETDATE(), 5.999, 100.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('005', '01', GETDATE(), 32.000, 150.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('006', '01', GETDATE(), 5.000, 60.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('007', '01', GETDATE(), 1.000, 10.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('008', '01', GETDATE(), 5.000, 60.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('009', '01', GETDATE(), 10.000, 80.000, 1)
INSERT DBO.HoaDon
		(MaHD, MaCH, NgayLapHD, Gia, ChietKhau, TrangThai)
VALUES	('010', '01', GETDATE(), 5.000, 100.000, 1)
GO

-- Thêm bảng nhà cung cấp
INSERT DBO.NhaCungCap
		(MaNCC,
		TenNCC,
		SDT,
		DiaChi,
		Email,
		TrangThai
		)
VALUES	('001', -- MaNCC - varchar(10)
		 N'SamSung', -- TenNCC - nvarchar(50)
		 '0942632795', -- SDT - varchar(10)
		 N'Trụ sở chính, singabo', -- DiaChi - nvarchar(50)
		 'samsung@gmail.com', -- varchar(30)
		 1 -- TrangThai - int
		 )
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('002', N'Apple', '0942632795', N'Trụ sở chính, Mỹ', 'appleg@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('003', N'Xiaomi', '0942632795', N'Trụ sở chính, Trung Quoc(Thượng Hải)', 'xiaomi@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('004', N'Oppo', '0942632795', N'Trụ sở chính, China', 'oppo@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('005', N'Huawai', '0942632795', N'Trụ sở chính, An do', 'huawai@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('006', N'OnePlus', '0942632795', N'Trụ sở chính, trung quoc', 'oneplus@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('007', N'Sony', '0942632795', N'Trụ sở chính, Jaban', 'sony@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('008', N'Redmi', '0942632795', N'Trụ sở chính, Việt Nam', 'redmi@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('009', N'Vsmart', '0942632795', N'Trụ sở chính, Việt Nam', 'vsmart@gmail.com', 1)
INSERT DBO.NhaCungCap
		(MaNCC, TenNCC, SDT, DiaChi, Email, TrangThai)
VALUES	('010', N'Bphone', '0942632795', N'Trụ sở chính, Việt Nam', 'bphone@gmail.com', 1)
GO

-- thêm bảng cấu hình
INSERT DBO.CauHinh
		(MaCauHinh,
		Ram,
		Rom,
		Pin,
		Chip,
		ManHinh,
		CameraSau,
		TrangThai
		)
VALUES	('iphone14', -- MaCauHinh - varchar(10)
		 '8GB', -- Ram - varchar(15)
		 '256GB', -- Rom - varchar(15)
		 '5000mah', -- Pin - varchar(10)
		 'Apple A14', -- Chip - varchar(15)
		 'IPS, LCD 2K+', -- ManHinh - varchar(50)
		 N'Chính 48 MP & Phụ 12 MP, 12 MP', -- CameraSau - nvarchar(50)
		 1 -- Trang thai - int
		)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('xiaomi10', '8GB', '128GB', '5000mah', 'Snap8 Gen1', 'IPS, LCD 4K', N'Chính 102 MP & Phụ 20 MP, 20 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('xiaomi11t', '16GB', '512GB', '5400mah', 'Dimesity 8100U', 'IPS, LCD full HD', N'Chính 64 MP & Phụ 12 MP, 12 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('samSungA80', '4GB', '128GB', '4000mah', 'Snap636', 'IPS, LCD HD', N'Chính 12 MP & Phụ 12 MP, 12 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('oppoA15', '8GB', '256GB', '5000mah', 'Helio G95', 'IPS, LCD full HD', N'Chính 48 MP & Phụ 12 MP, 12 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('samSungJ4', '4GB', '64GB', '3500mah', 'Helio G45', 'IPS, HD', N'Chính 12 MP & Phụ 12 MP, 12 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('redmiK50', '8GB', '256GB', '5000mah', 'Snap888', 'IPS, LCD 2K+', N'Chính 64 MP & Phụ 12 MP, 12 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('redmi9', '4GB', '128GB', '5000mah', 'Snap638', 'IPS, LCD full HD', N'Chính 102 MP & Phụ 12 MP, 12 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('huawaiP50', '8GB', '256GB', '5000mah', 'Helio G55', 'IPS, LCD 2K', N'Chính 48 MP & Phụ 12 MP, 12 MP', 1)
INSERT DBO.CauHinh
		(MaCauHinh, Ram, Rom, Pin, Chip, ManHinh, CameraSau, TrangThai)
VALUES	('onePlus10', '8GB', '256GB', '5000mah', 'Snap888', 'IPS, LCD 2K+', N'Chính 48 MP & Phụ 12 MP, 12 MP', 1)
GO

-- Thêm bảng điện thoại
INSERT DBO.DienThoai
		(MaDT,
		MaCauHinh,
		MaNCC,
		TenDT,
		Mau,
		Hinh,
		TinhNang,
		SoLuong,
		Gia,
		TrangThai
		)
VALUES	('0942632791', -- MaDT - varchar(10)
		 'xiaomi10', -- MaCauHinh - varchar(10)
		 '003', -- MaNCC - varchar(10)
		 N'Xiaomi 10', -- nvarchar(50)
		 N'Đỏ', -- Mau - nvarchar(50)
		 'xiaomi10.png', -- Hinh - varchar(200)
		 N'Điện thoại thông minh', -- TinhNang - nvarchar(50)
		 5, -- SoLuong - int
		 15.00, -- Gia - money
		 1
		)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia, TrangThai)
VALUES	('0942632792', 'iphone14', '002', N'Iphone 14', N'Gold', 'iphone14.png', N'Điện thoại thông minh', 30, 32.00, 1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632793', 'xiaomi11t', '003', N'Xiaomi 11T', N'Xanh', 'xiaomi11t.png', N'Điện thoại thông minh', 10, 11.00,1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632794', 'samSungA80', '001', N'SamSung A80', N'Đỏ', 'samSungA80.png', N'Điện thoại thông minh', 50, 5.20,1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632795', 'oppoA15', '004', N'Oppo A15', N'Đỏ', 'oppoA15.png', N'Điện thoại thông minh', 1, 3.00,1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632796', 'samSungJ4', '001', N'samSungJ4', N'Xanh', 'samSungJ4.png', N'Điện thoại thông minh', 20, 4.00,1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632797', 'redmiK50', '008', N'Redmi K50', N'Hồng nhạt', 'redmiK50.png', N'Điện thoại thông minh', 15, 6.50,1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632798', 'redmi9', '008', N'redmi9', N'Đỏ', 'redmi9.png', N'Điện thoại thông minh', 5, 4.00,1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632799', 'huawaiP50', '005', N'Huawai P50', N'Đen', 'huawaiP50.png', N'Điện thoại thông minh', 3, 7.00,1)
INSERT DBO.DienThoai
		(MaDT, MaCauHinh, MaNCC, TenDT, Mau, Hinh, TinhNang, SoLuong, Gia,TrangThai)
VALUES	('0942632710', 'onePlus10', '006', N'OnePlus 10', N'Vàng', 'onePlus10.png', N'Điện thoại thông minh', 5, 12.00,1)
GO

-- Thêm bảng chi tiết hóa đơn bán
INSERT DBO.CTHDBan
		(MaHDBan,
		MaDT,
		MaKH,
		MaNV,
		MaHD,
		SoLuong,
		TongGia,
		NgayBan, 
		TrangThai
		)
VALUES	('001', -- MaHDBan - varchar(10)
		 '0942632791', -- MaDT - varchar(10)
		 '00001', -- MaKH - varchar(10)
		 '0306211244', -- MaNV - varchar(10)
		 '001', -- MaHD - varchar(10)
		 10, -- SoLuong - int
		 320.000, -- TongGia - money
		 GETDATE(), -- NgayBan - date
		 1 -- TrangThai - int
		)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('002', '0942632792', '00002', '0306211244', '002', 5, 40.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('003', '0942632793', '00003', '0306211244', '003', 11, 350.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('004', '0942632794', '00004', '0306211244', '004', 7, 120.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('005', '0942632795', '00005', '0306211244', '005', 8, 110.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('006', '0942632796', '00006', '0306211244', '006', 1, 10.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('007', '0942632797', '00007', '0306211244', '007', 10, 520.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('008', '0942632798', '00008', '0306211244', '008', 4, 220.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('009', '0942632799', '00009', '0306211244', '009', 10, 420.000, GETDATE(), 1)
INSERT DBO.CTHDBan
		(MaHDBan, MaDT, MaKH, MaNV, MaHD, SoLuong, TongGia, NgayBan, TrangThai)
VALUES	('010', '0942632710', '00010', '0306211244', '010', 2, 20.000, GETDATE(), 1)
GO

-- Thêm bảng chi tiết hóa đơn nhập
INSERT DBO.CTHDNhap
		(MaHDNhap,
		MaDT,
		MaNCC,
		MaNV,
		MaHD,
		Soluong,
		TongGia,
		NgayNhap,
		TrangThai
		)
VALUES	('001', -- MaHDNhap - varchar(10)
		 '0942632791', -- MaDT - varchar(10)
		 '001', -- MaNCC - varchar(10)
		 '0306211244', -- MaNV - varchar(10)
		 '001', -- MaHD - varchar(10)
		 10, -- SoLuong - int
		 320.000, -- TongGia - money
		 GETDATE(), -- NgayNhap - date
		 1 -- TrangThai - int
		 )
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('002', '0942632792', '002', '0306211244', '002', 5, 40.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('003', '0942632793', '003', '0306211244', '003', 11, 350.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('004', '0942632794', '004', '0306211244', '004', 7, 120.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('005', '0942632795', '005', '0306211244', '005', 8, 110.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('006', '0942632796', '006', '0306211244', '006', 1, 10.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('007', '0942632797', '007', '0306211244', '007', 10, 520.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('008', '0942632798', '008', '0306211244', '008', 4, 220.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('009', '0942632799', '009', '0306211244', '009', 10, 420.000, GETDATE(), 1)
INSERT DBO.CTHDNhap
		(MaHDNhap, MaDT, MaNCC, MaNV, MaHD, SoLuong, TongGia, NgayNhap, TrangThai)
VALUES	('010', '0942632710', '010', '0306211244', '010', 2, 20.000, GETDATE(), 1)

GO

CREATE PROC Insert_CTNhapHoaDon
@maDT varchar(10), @maNV varchar(10), @kt int
AS
	BEGIN
	-- Kiểm tra bằng 1 thì sẽ tạo ra maHD mới -- tạo hóa đơn mới
		IF @kt = 1
		BEGIN
-- them hoa don
		INSERT DBO.HoaDon
				(MaHD, MaCH, NgayLapHD,TrangThai)
		VALUES	(
		-- MaHD
				(SELECT CONCAT('0', MAX(MaHD + 1))  
				FROM DBO.HoaDon), 
				'01', -- MaCH
				GETDATE(), -- NgayLapHD
				1 -- TrangThai
				)
	   END
-- them CTHDNhap
	   INSERT DBO.CTHDNhap
				(MaHDNhap, MaDT, MaNV, MaHD, MaNCC, Soluong, TongGia, NgayNhap, TrangThai)
	   VALUES	(
		-- MaHDNhap
				(
				SELECT CONCAT('0', MAX(MaHDNhap + 1)) 
				FROM DBO.CTHDNhap),  
				@maDT, -- MaDT
				@maNV, -- MaNV

		-- MaHD
				(
				SELECT MAX(MaHD) 
				FROM DBO.HoaDon), 

				(SELECT MaNCC FROM DBO.DienThoai WHERE MaDT = @maDT), -- MaNCC
				1, -- Soluong

		-- TongGia
				(SELECT Gia
				FROM DBO.DienThoai
				WHERE MaDT = @maDT), 

				GETDATE(), -- NgayNhap
				1 -- TrangThai
				)
-- update hoadon
		UPDATE DBO.HoaDon
		 -- Gia
				SET Gia = (
							SELECT SUM(TongGia) 
							FROM DBO.CTHDNhap 
							WHERE MaHD = (
											SELECT MAX(MaHD) 
											FROM DBO.HoaDon)),
		-- ChietKhau
				ChietKhau = (
							SELECT 0.05 *  SUM(TongGia) 
							FROM DBO.CTHDNhap 
							WHERE MaHD = (
											SELECT MAX(MaHD) FROM DBO.HoaDon)) 
				WHERE MaHD = (
								SELECT MAX(MaHD) 
								FROM DBO.HoaDon)
	END
GO

--EXEC Insert_CTNhapHoaDon '0942632793', '000', 2 -- maDT, maNV, kt

--GO

CREATE PROC LayTongGia
AS
BEGIN
	SELECT  SUM(TongGia)* 1000 AS TongGia 
	FROM DBO.CTHDNhap 
	WHERE MaHD = (SELECT MAX(MaHD) 
				  FROM DBO.HoaDon)
END
GO
--EXEC LayTongGia

CREATE PROC LaySoLuong
AS
BEGIN
	SELECT SUM(Soluong) AS SoLuong
	FROM DBO.CTHDNhap 
	WHERE MaHD = (SELECT MAX(MaHD) 
				  FROM DBO.HoaDon)
END
GO
--EXEC LaySoLuong

CREATE PROC LayChietKhau
AS
BEGIN
	SELECT ChietKhau * 1000 AS TongCong 
	FROM DBO.HoaDon 
	WHERE MaHD = (SELECT MAX(MaHD) 
				  FROM DBO.HoaDon)
END
--EXEC LayChietKhau
GO
CREATE PROC LayTongCong
AS
BEGIN
	SELECT (Gia * 1000) - (ChietKhau * 1000) AS TongCong FROM DBO.HoaDon WHERE MaHD = (SELECT MAX(MaHD) FROM DBO.HoaDon)
END

--EXEC LayTongCong
GO

CREATE PROC HuyHoaDon
AS
BEGIN
	DELETE FROM DBO.CTHDNhap
	WHERE MaHD = (SELECT MAX(MaHD) 
				  FROM DBO.HoaDon) 
	DELETE FROM DBO.HoaDon 
	WHERE MaHD = (SELECT MAX(MaHD) 
				  FROM DBO.HoaDon)
END

--EXEC HuyHoaDon
GO

CREATE PROC TruHoaDonNhap
@maHDNhap varchar(10)
AS
BEGIN

	DELETE FROM CTHDNhap 
	WHERE MaHDNhap = @maHDNhap

	UPDATE DBO.HoaDon
		 -- Gia
				SET Gia = (
							SELECT SUM(TongGia) 
							FROM DBO.CTHDNhap 
							WHERE MaHD = (
											SELECT MAX(MaHD) 
											FROM DBO.HoaDon)),
		-- ChietKhau
				ChietKhau = (
							SELECT 0.05 *  SUM(TongGia) 
							FROM DBO.CTHDNhap 
							WHERE MaHD = (
											SELECT MAX(MaHD) FROM DBO.HoaDon)) 
				WHERE MaHD = (SELECT MAX(MaHD) 
							  FROM DBO.HoaDon)
		
END

--EXEC TruHoaDonNhap '021'

GO


CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
go

CREATE PROC DoanhThu
AS
BEGIN
	SELECT SUM(b.SoLuong) AS SoLuong, SUM(a.Gia) AS Gia, SUM(a.ChietKhau) AS ChietKhau, a.NgayLapHD 
	FROM DBO.HoaDon a 
	INNER JOIN DBO.CTHDNhap b ON a.MaHD = b.MaHD 
	GROUP BY a.NgayLapHD
	HAVING COUNT(*) > 0
	ORDER BY a.NgayLapHD ASC
END
GO






SELECT MaKH, HoKH + ' ' + TenKH AS HoTenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai FROM dbo.KhachHang WHERE dbo.fuConvertToUnsign1(TenKH) LIKE N'%' + dbo.fuConvertToUnsign1(N'094457') + '%' AND dbo.fuConvertToUnsign1(SDT) LIKE N'%' + dbo.fuConvertToUnsign1(N'094457') + '%'

SELECT A.*, B.TenNCC FROM DBO.DienThoai A, dbo.NhaCungCap B WHERE A.MaNCC = B.MaNCC AND dbo.fuConvertToUnsign1(TenDT) LIKE N'%' + dbo.fuConvertToUnsign1(N'sam') + '%'
SELECT * FROM DBO.KhachHang
SELECT * FROM DBO.NhanVien 
SELECT * FROM DBO.CuaHang
SELECT * FROM DBO.HoaDon
SELECT * FROM DBO.NhaCungCap
SELECT * FROM DBO.CauHinh
SELECT * FROM DBO.DienThoai
SELECT * FROM DBO.CTHDBan 
SELECT *  FROM DBO.CTHDNhap 


SELECT a.*, SUM(b.SoLuong) AS TongSoLuong FROM DBO.HoaDon a INNER JOIN DBO.CTHDNhap b ON a.MaHD = b.MaHD GROUP BY a.MaHD, a.MaCH, a.NgayLapHD, a.Gia, a.ChietKhau, a.TrangThai HAVING COUNT(*) > 0;



DELETE FROM DBO.CTHDNhap WHERE MaHD BETWEEN 11 AND 30
DELETE FROM DBO.HoaDon WHERE MaHD BETWEEN 11 AND 30





--DELETE FROM DBO.KhachHang
--DELETE FROM DBO.NhanVien
--DELETE FROM DBO.CuaHang
--DELETE FROM DBO.HoaDon WHERE MaHD = '011'
--DELETE FROM DBO.NhaCungCap
--DELETE FROM DBO.CauHinh
--DELETE FROM DBO.DienThoai
--DELETE FROM DBO.CTHDBan
--DELETE FROM DBO.CTHDNhap

GO

