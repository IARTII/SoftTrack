CREATE TRIGGER trg_SetSupportEndDate
ON dbo.Clients
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE c
    SET support_end = DATEADD(YEAR, 1, i.sale_date)  -- Предположим, гарантия 1 год
    FROM dbo.Clients c
    INNER JOIN inserted i ON c.id = i.id;
END;
GO

CREATE TRIGGER trg_ValidateWarrantyRequest
ON dbo.Support
BEFORE INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN dbo.Clients c ON i.client_id = c.id AND i.software_id = c.software_id
        WHERE i.request_date > c.support_end
    )
    BEGIN
        RAISERROR ('Гарантийный ремонт запрещен после окончания срока гарантии.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO
