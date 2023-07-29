CREATE TABLE INFO_MEDICAL_SERVICE_TYPE
(
	ID				SERIAL NOT NULL PRIMARY KEY,
	CODE			VARCHAR(50),
	
	SHORT_NAME		VARCHAR(250) NOT NULL,
	FULL_NAME		VARCHAR(250) NOT NULL,
	
	STATE_ID		INT NOT NULL,
	
	CREATED_AT		TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW() NOT NULL,
	CREATED_BY		INT,
	MODIFIED_AT		TIMESTAMP WITHOUT TIME ZONE,
	MODIFIED_BY		INT,
	
	CONSTRAINT FK_STATE_ID
		FOREIGN KEY (STATE_ID)
			REFERENCES ENUM_STATE (ID)	
);