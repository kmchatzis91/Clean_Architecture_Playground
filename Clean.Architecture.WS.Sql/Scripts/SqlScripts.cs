using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Clean.Architecture.WS.Sql.Scripts
{
    public class SqlScripts
    {
        private const string CreateTableEmployee =
            @"CREATE TABLE EMPLOYEE (
                EMPLOYEE_ID BIGINT IDENTITY(1,1) NOT NULL,
                FIRST_NAME NVARCHAR(255) NOT NULL,
                LAST_NAME NVARCHAR(255) NOT NULL,
                EMAIL NVARCHAR(255) NOT NULL,
                PHONE_NUMBER NVARCHAR(50) NOT NULL,
                ROLE_ID BIGINT NOT NULL,
                COMPANY_ID BIGINT NOT NULL,
                CONSTRAINT PK_EMPLOYEE PRIMARY KEY (EMPLOYEE_ID),
                CONSTRAINT FK_EMPLOYEE_ROLE FOREIGN KEY (ROLE_ID) REFERENCES ROLE(ROLE_ID),
                CONSTRAINT FK_EMPLOYEE_COMPANY FOREIGN KEY (COMPANY_ID) REFERENCES COMPANY(COMPANY_ID)
            );";

        private const string CreateTableCompany =
            @"CREATE TABLE COMPANY (
                COMPANY_ID BIGINT IDENTITY(1,1) NOT NULL,
                COMPANY_NAME NVARCHAR(255) NOT NULL,
                CONSTRAINT PK_COMPANY PRIMARY KEY (COMPANY_ID)
            );";

        private const string CreateTableRole =
            @"CREATE TABLE ROLE (
                ROLE_ID BIGINT IDENTITY(1,1) NOT NULL,
                ROLE_NAME NVARCHAR(255) NOT NULL,
                CONSTRAINT PK_ROLE PRIMARY KEY (ROLE_ID)
            );";

        private const string InsertDataEmployee = @"
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('John', 'Doe', 'johndoe1@example.com', '555-0101', 1, 1);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Jane', 'Doe', 'janedoe1@example.com', '555-0102', 1, 2);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Alice', 'Smith', 'alicesmith1@example.com', '555-0103', 1, 3);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Bob', 'Brown', 'bobbrown1@example.com', '555-0104', 1, 4);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Charlie', 'Johnson', 'charliejohnson1@example.com', '555-0105', 1, 5);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Daisy', 'Miller', 'daisymiller1@example.com', '555-0106', 1, 6);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Eve', 'Williams', 'evewilliams1@example.com', '555-0201', 2, 1);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Frank', 'Taylor', 'franktaylor1@example.com', '555-0202', 2, 2);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Grace', 'Davis', 'gracedavis1@example.com', '555-0203', 2, 3);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Hank', 'Martinez', 'hankmartinez1@example.com', '555-0204', 2, 4);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Ivy', 'Hernandez', 'ivyhernandez1@example.com', '555-0205', 2, 5);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Jack', 'Lopez', 'jacklopez1@example.com', '555-0206', 2, 6);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Karen', 'Gonzalez', 'karengonzalez1@example.com', '555-0301', 3, 1);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Leo', 'Wilson', 'leowilson1@example.com', '555-0302', 3, 2);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Mona', 'Moore', 'monamoore1@example.com', '555-0303', 3, 3);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Nick', 'Jackson', 'nickjackson1@example.com', '555-0304', 3, 4);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Olivia', 'White', 'oliviawhite1@example.com', '555-0305', 3, 5);
            INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID) 
            VALUES ('Paul', 'Harris', 'paulharris1@example.com', '555-0306', 3, 6);";

        private const string InsertDataCompany = @"
            INSERT INTO COMPANY (COMPANY_NAME) VALUES ('Company A');
            INSERT INTO COMPANY (COMPANY_NAME) VALUES ('Company B');
            INSERT INTO COMPANY (COMPANY_NAME) VALUES ('Company C');
            INSERT INTO COMPANY (COMPANY_NAME) VALUES ('Company D');
            INSERT INTO COMPANY (COMPANY_NAME) VALUES ('Company E');
            INSERT INTO COMPANY (COMPANY_NAME) VALUES ('Company F');";

        private const string InsertDataRole = @"
            INSERT INTO ROLE (ROLE_NAME) VALUES ('SWE');
            INSERT INTO ROLE (ROLE_NAME) VALUES ('Manager');
            INSERT INTO ROLE (ROLE_NAME) VALUES ('Boss');";

        private const string CreateViewForEmployee =
            @"CREATE VIEW EMPLOYEE_V AS
              SELECT 
                  E.EMPLOYEE_ID,
                  E.FIRST_NAME,
                  E.LAST_NAME,
                  E.EMAIL,
                  E.PHONE_NUMBER,
				  E.ROLE_ID,
                  R.ROLE_NAME,
				  E.COMPANY_ID,
                  C.COMPANY_NAME
              FROM 
                  EMPLOYEE E
              JOIN 
                  COMPANY C ON E.COMPANY_ID = C.COMPANY_ID
              JOIN 
                  ROLE R ON E.ROLE_ID = R.ROLE_ID;";

        private const string CreateViewForCompany =
            @"CREATE VIEW COMPANY_V AS
              SELECT 
                  COMPANY_ID,
                  COMPANY_NAME
              FROM 
                  COMPANY;";

        private const string CreateViewForRole =
            @"CREATE VIEW ROLE_V AS
              SELECT 
                  ROLE_ID,
                  ROLE_NAME
              FROM 
                  ROLE;";

        private const string SpInsertEmployee =
            @"CREATE PROCEDURE INSERT_EMPLOYEE
                @FirstName NVARCHAR(255),
                @LastName NVARCHAR(255),
                @Email NVARCHAR(255),
                @PhoneNumber NVARCHAR(50),
                @RoleId BIGINT,
                @CompanyId BIGINT
                AS
                BEGIN
                    INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID)
                    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @RoleId, @CompanyId);
                END";

        private const string SpInsertCompany =
            @"CREATE PROCEDURE INSERT_COMPANY
              @CompanyName NVARCHAR(255)
              AS
              BEGIN
                  INSERT INTO COMPANY (COMPANY_NAME)
                  VALUES (@CompanyName);
              END";

        private const string SpInsertRole =
            @"CREATE PROCEDURE INSERT_ROLE
              @RoleName NVARCHAR(255)
              AS
              BEGIN
                  INSERT INTO ROLE (ROLE_NAME)
                  VALUES (@RoleName);
              END";

        private const string SpUpdateEmployee =
            @"CREATE PROCEDURE UPDATE_EMPLOYEE
              @EmployeeId BIGINT,
              @FirstName NVARCHAR(255) = NULL,
              @LastName NVARCHAR(255) = NULL,
              @Email NVARCHAR(255) = NULL,
              @PhoneNumber NVARCHAR(50) = NULL,
              @RoleId BIGINT = NULL,
              @CompanyId BIGINT = NULL
              AS
              BEGIN
                  UPDATE EMPLOYEE
                  SET 
                      FIRST_NAME = ISNULL(@FirstName, FIRST_NAME),
                      LAST_NAME = ISNULL(@LastName, LAST_NAME),
                      EMAIL = ISNULL(@Email, EMAIL),
                      PHONE_NUMBER = ISNULL(@PhoneNumber, PHONE_NUMBER),
                      ROLE_ID = ISNULL(@RoleId, ROLE_ID),
                      COMPANY_ID = ISNULL(@CompanyId, COMPANY_ID)
                  WHERE EMPLOYEE_ID = @EmployeeId;
              END";

        private const string SpUpdateCompany =
            @"CREATE PROCEDURE UPDATE_COMPANY
              @CompanyId BIGINT,
              @CompanyName NVARCHAR(255) = NULL
              AS
              BEGIN
                  UPDATE COMPANY
                  SET 
                      COMPANY_NAME = ISNULL(@CompanyName, COMPANY_NAME)
                  WHERE COMPANY_ID = @CompanyId;
              END";

        private const string SpUpdateRole =
            @"CREATE PROCEDURE UPDATE_ROLE
              @RoleId BIGINT,
              @RoleName NVARCHAR(255)
              AS
              BEGIN
                UPDATE ROLE
                SET
                    ROLE_NAME = ISNULL(@RoleName, ROLE_NAME)
                WHERE ROLE_ID = @RoleId;
              END";

        private const string SpDeleteEmployee =
            @"CREATE PROCEDURE DELETE_EMPLOYEE
              @EmployeeId BIGINT
              AS
              BEGIN
                -- Ensure no referential integrity issues
                IF EXISTS (SELECT 1 FROM EMPLOYEE WHERE EMPLOYEE_ID = @EmployeeId)
                    BEGIN
                        DELETE FROM EMPLOYEE
                        WHERE EMPLOYEE_ID = @EmployeeId;
                    END
                ELSE
                    BEGIN
                        PRINT 'Not found!';
                    END
              END";
    }
}
