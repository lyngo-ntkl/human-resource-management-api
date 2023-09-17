drop database if exists HumanResourceManagement;
create database HumanResourceManagement;
GO
use HumanResourceManagement;
GO

CREATE TABLE employees(
	employee_id char(6) NOT NULL,
	candidate_id NOT NULL,
	name nvarchar(50) NOT NULL,
	birthday date NOT NULL,
	address nvarchar(256) NOT NULL,
	gender nchar(3) NOT NULL CHECK(gender IN('Nam', 'Nữ')),
	identity_card_number varchar(16) NOT NULL UNIQUE,
	eductional_level nvarchar(100),
	major nvarchar(50),
	is_former BIT NOT NULL,
	password_hash VARBINARY(MAX) NOT NULL,
	password_key VARBINARY(MAX) NOT NULL,
	phone char(10) NOT NULL,
	email varchar(100) NOT NULL UNIQUE,
	CONSTRAINT PK_EMPLOYEE PRIMARY KEY(employee_id)
);
GO

CREATE TABLE contracts(
	contract_id char(36),
	employee_id char(6),
	department_id int,
	position_id int,
	contract_file varchar(500) NOT NULL,
	electronic_signature varchar(500),
	contract_annex varchar(500),
	labor_contract_type smallint,
	contract_term int,
	start_date date,
	end_date date,
	annual_leave int,
	probationary_period int,
	basic_salary decimal NOT NULL,
	total_allowance decimal,
	CONSTRAINT PK_CONTRACT PRIMARY KEY(contract_id)
);
GO

CREATE TABLE payrolls(
	payroll_id char(36),
	contract_id char(36),
	pay_date date NOT NULL,
	days_off INT NOT NULL,
	CONSTRAINT PK_PAYROLL PRIMARY KEY (payroll_id)
);
GO

CREATE TABLE allowances(
	contract_id char(36) NOT NULL,
	allowance_type_id int NOT NULL,
	amount decimal NOT NULL,
	CONSTRAINT PK_ALLOWANCE PRIMARY KEY (contract_id, allowance_type_id)
);
GO

CREATE TABLE allowance_types(
	allowance_type_id INT NOT NULL,
	allowance_name NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_ALLOWANCE_TYPE PRIMARY KEY (allowance_type_id)
);
GO

CREATE TABLE bonuses(
	bonus_id CHAR(36) PRIMARY KEY,
	payroll_id CHAR(36) NOT NULL,
	bonus_type_id INT NOT NULL,
	reason VARCHAR(500) NOT NULL,
	amount DECIMAL NOT NULL
);
GO

CREATE TABLE bonus_types(
	bonus_type_id INT NOT NULL PRIMARY KEY,
	bonus_name NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE leave(
	leave_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	employee_id char(6) NOT NULL,
	start_date date NOT NULL,
	end_date date NOT NULL,
	status varchar(10) NOT NULL CHECK(status in ('Approved', 'Processed', 'Rejected')),
	type smallint NOT NULL,
	reason varchar(1000)
);
GO

CREATE TABLE departments(
	department_id int identity(1,1) PRIMARY KEY,
	department_name varchar(100)
);
GO

CREATE TABLE positions(
	position_id int identity(1,10) PRIMARY KEY,
	position_name varchar(100)
);
GO

ALTER TABLE contracts
ADD CONSTRAINT FK_CONTRACT_EMPLOYEE FOREIGN KEY (employee_id) REFERENCES employees(employee_id);
GO

ALTER TABLE contracts
ADD CONSTRAINT FK_CONTRACT_DEPARTMENT FOREIGN KEY (department_id) REFERENCES departments(department_id);
GO

ALTER TABLE contracts
ADD CONSTRAINT FK_CONTRACT_POSITION FOREIGN KEY (position_id) REFERENCES positions(position_id);
GO

ALTER TABLE payrolls
ADD CONSTRAINT FK_PAYROLL_CONTRACT FOREIGN KEY (contract_id) REFERENCES contracts(contract_id);
GO

ALTER TABLE leave
ADD CONSTRAINT FK_LEAVES_EMPLOYEE FOREIGN KEY (employee_id) REFERENCES employees(employee_id);
GO

ALTER TABLE allowances
ADD CONSTRAINT FK_ALLOWANCE_CONTRACT FOREIGN KEY (contract_id) REFERENCES contracts(contract_id);
GO

ALTER TABLE allowances
ADD CONSTRAINT FK_ALLOWANCE_ALLOWANCE_TYPE FOREIGN KEY (allowance_type_id) REFERENCES allowance_types(allowance_type_id);
GO

ALTER TABLE bonuses
ADD CONSTRAINT FK_BONUS_BONUS_TYPE FOREIGN KEY (bonus_type_id) REFERENCES bonus_types(bonus_type_id)
GO

ALTER TABLE bonuses
ADD CONSTRAINT FK_BONUS_PAYROLL FOREIGN KEY (payroll_id) REFERENCES payrolls(payroll_id)
GO

SET IDENTITY_INSERT departments ON;
insert into departments(department_id, department_name) values 
	(1, 'Tài chính kế toán'), 
	(2, 'Nhân sự'), 
	(3, 'Hành chính'), 
	(4, 'Marketing'), 
	(5, 'Chăm sóc khách hàng'),
	(6, 'Công nghệ thông tin');
SET IDENTITY_INSERT departments OFF;
SET IDENTITY_INSERT positions ON;
insert into positions(position_id, position_name) values 
	(1, 'Trưởng phòng'), 
	(2, 'Nhân viên');
SET IDENTITY_INSERT positions OFF;
INSERT INTO employees(employee_id, name, birthday, address, gender,	identity_card_number, [eductional_level], [major], [password_hash], [password_key], phone, email, is_former) 
VALUES ('1a', 'Lee Felix', '2000-09-15', '', 'Nam', '1234567890', NULL, NULL, CAST('9488141233b198df76a47df9dc38d031cc68e99901bd44d461adceaa224698de4f63e5e6f9c01fced53f1fc456eaec836f094215c5e121ab8af3f31ced12dbcc' AS varbinary(max)), CAST('1' AS varbinary(max)),'0987654321', 'abc@gmail.com', 1);
INSERT INTO leave([employee_id], [start_date], [end_date], [status], [type], [reason]) VALUES ('1a', '2023-09-01', '2023-09-05', 'Processed', 1, 'holiday');