CREATE TABLE ENUM_STATUS (
    ID 			INT NOT NULL PRIMARY KEY,
    ORDER_CODE 	VARCHAR(50),
    SHORT_NAME 	VARCHAR(250) not null,
    FULL_NAME  	VARCHAR(300) not null,
    CREATED_AT 	TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW()
);