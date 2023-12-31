CREATE TABLE SYS_EMPLOYEE_MANAGE
(
    ID                  	    BIGSERIAL NOT NULL PRIMARY KEY,
    
    DOC_TABLE_ID                INT NOT NULL,
    DOC_ID                      BIGINT NOT NULL,

    START_ON                    DATE NOT NULL,
    END_ON                      DATE,
    APPOINT_ORDER_TYPE_ID	    INT NOT NULL,

    DEPARTMENT_ID               INT NOT NULL,
    POSITION_ID                 INT NOT NULL,
    EMPLOYEE_ID                 INT NOT NULL,
    --EMPLOYMENT_TYPE_ID          INT NOT NULL,
    EMPLOYMENT_RATE             NUMERIC(18, 2) NOT NULL,
    --WORK_SCHEDULE_ID            INT NOT NULL,
    ORGANIZATION_ID             INT NOT NULL,

    END_BY_DOCUMENT_ON          DATE,
    END_TABLE_ID                INT,
    END_DOC_ID                  BIGINT,

    CONSTRAINT FK__DOC_TABLE FOREIGN KEY (DOC_TABLE_ID)
    REFERENCES SYS_TABLE(ID),

    CONSTRAINT FK__APPOINT_ORDER_TYPE FOREIGN KEY (APPOINT_ORDER_TYPE_ID)
    REFERENCES ENUM_APPOINT_ORDER_TYPE(ID),

    CONSTRAINT FK__DEPARTMENT FOREIGN KEY (DEPARTMENT_ID)
    REFERENCES HL_DEPARTMENT(ID),

    CONSTRAINT FK__POSITION FOREIGN KEY (POSITION_ID)
    REFERENCES HL_POSITION(ID),

    CONSTRAINT FK__EMPLOYEE FOREIGN KEY (EMPLOYEE_ID)
    REFERENCES HL_EMPLOYEE(ID),

    CONSTRAINT FK__END_TABLE FOREIGN KEY (END_TABLE_ID)
    REFERENCES SYS_TABLE(ID),

    CONSTRAINT FK__ORGANIZATION FOREIGN KEY (ORGANIZATION_ID)
    REFERENCES INFO_ORGANIZATION(ID)
);


INSERT INTO SYS_TABLE (ID,SHORT_NAME,FULL_NAME,DB_TABLE_NAME)
	VALUES (4,N'Ходимларни бош?ариш',N'Ходимларни бош?ариш',N'SYS_EMPLOYEE_MANAGE');