CREATE TABLE HL_ROOM
(
	ID		 					SERIAL NOT NULL PRIMARY KEY,
	ORDER_CODE					VARCHAR(10),
	FLOOR						INT,
	ROOM_NUMBER					VARCHAR(250) NOT NULL,
	ORGANIZATION_ID				INT NOT NULL,
	
	STATE_ID					INT NOT NULL,
	CREATED_AT					TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW() NOT NULL,
	CREATED_BY					INT,
	MODIFIED_AT					TIMESTAMP WITHOUT TIME ZONE,
	MODIFIED_BY					INT,	
	
	CONSTRAINT FK_STATE_ID			
		FOREIGN KEY ( STATE_ID )	
			REFERENCES ENUM_STATE ( ID ),
	CONSTRAINT FK_ORGANIZATION_ID		
		FOREIGN KEY ( ORGANIZATION_ID )	
			REFERENCES INFO_ORGANIZATION ( ID )
);