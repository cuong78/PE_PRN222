USE master
GO

CREATE DATABASE supermarketparkingdb
GO

USE supermarketparkingdb
GO

-- Tài khoản hệ thống
CREATE TABLE SystemAccounts (
    AccountID INT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Role INT,
    IsActive BIT DEFAULT 1
);
-- Vai trò Role = 2 là Manager, Role = 3 là Security
INSERT INTO SystemAccounts (AccountID, Username, Email, Password, Role, IsActive) VALUES
(1, 'manager', 'manager@parking.com', 'manager123', 2, 1),
(2, 'security1', 'sec1@parking.com', 'secpass', 2, 1),
(3, 'staff', 'staff@parking.com', 'staff123', 3, 1);

-- Danh mục loại xe
CREATE TABLE VehicleType (
    VehicleTypeID INT PRIMARY KEY,
    TypeName VARCHAR(100) NOT NULL,
    MaxParkingTime INT, -- phút
    FeePerHour DECIMAL(6,2) -- phí theo giờ
);

INSERT INTO VehicleType (VehicleTypeID, TypeName, MaxParkingTime, FeePerHour) VALUES
(1, 'Motorbike', 240, 3.00),
(2, 'Car', 720, 10.00),
(3, 'Minivan', 480, 15.00),
(4, 'Electric motorbike', 300, 20.00);

-- Bảng lượt vào/ra
CREATE TABLE ParkingRecord (
    RecordID INT PRIMARY KEY,
    VehiclePlate VARCHAR(20) NOT NULL,
    VehicleTypeID INT,
    CheckInTime DATETIME NOT NULL,
    CheckOutTime DATETIME NULL,
    ParkingSlot VARCHAR(20),
    FeePaid DECIMAL(10,2),
    CONSTRAINT fk_parking_vehicletype FOREIGN KEY (VehicleTypeID) REFERENCES VehicleType(VehicleTypeID) ON DELETE CASCADE
);

INSERT INTO ParkingRecord (RecordID, VehiclePlate, VehicleTypeID, CheckInTime, CheckOutTime, ParkingSlot, FeePaid) VALUES
(1, '59A1-12345', 1, '2025-06-21 08:10', '2025-06-21 10:00', 'M01', 6.00),
(2, '51G-88888', 2, '2025-06-21 09:00', NULL, 'C02', 0.00),
(3, '60C-23456', 3, '2025-06-21 07:45', '2025-06-21 11:45', 'T01', 60.00);
