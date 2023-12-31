CREATE TABLE SYS_MODULE (
    ID 				SERIAL NOT NULL PRIMARY KEY,
    ORDER_CODE  	VARCHAR(50) NULL,
    CODE 			VARCHAR(100) NOT NULL,
    SHORT_NAME  	VARCHAR(250) NOT NULL,
    FULL_NAME 		VARCHAR(300) NOT NULL,
    SUB_GROUP_ID 	INT NOT NULL,
    STATE_ID 		INT NOT NULL,

    CONSTRAINT FK_SUB_GROUP_ID
		FOREIGN KEY (SUB_GROUP_ID) 
			REFERENCES SYS_MODULE_SUB_GROUP(ID),
    CONSTRAINT FK_STATE_ID 
		FOREIGN KEY (STATE_ID)
			REFERENCES ENUM_STATE(ID)
);
CREATE UNIQUE INDEX UK_SYS_MODULE_CODE ON SYS_MODULE (CODE);