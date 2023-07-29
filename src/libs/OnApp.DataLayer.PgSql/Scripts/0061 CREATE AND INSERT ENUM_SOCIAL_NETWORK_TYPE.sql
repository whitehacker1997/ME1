--CREATE
CREATE TABLE ENUM_SOCIAL_NETWORK_TYPE -- Telegram,WhatsApp,Instagram
(    
	ID				INT NOT NULL PRIMARY KEY,
	ORDER_CODE		VARCHAR(50),
	SHORT_NAME		VARCHAR(250) NOT NULL,
	FULL_NAME		VARCHAR(250) NOT NULL,
	--ICON_IMAGE      TEXT NOT NULL, -- Keyinchalik kerak bo'lsa base64 ko'rinishi saqlanadi yoki frontdan imkoni bo'lsa rasm o'sha yerdan beriladi


	STATE_ID		INT NOT NULL,
	CREATED_AT		TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW() NOT NULL,
	CREATED_BY		INT,
	MODIFIED_AT		TIMESTAMP WITHOUT TIME ZONE,
	MODIFIED_BY		INT,
	
	CONSTRAINT FK_STATE_ID
		FOREIGN KEY (STATE_ID)
			REFERENCES ENUM_STATE (ID)	
);


--INSERT
INSERT INTO ENUM_SOCIAL_NETWORK_TYPE (ID, ORDER_CODE, SHORT_NAME, FULL_NAME, STATE_ID) VALUES (1,'1','Telegram','Telegram',1);
INSERT INTO ENUM_SOCIAL_NETWORK_TYPE (ID, ORDER_CODE, SHORT_NAME, FULL_NAME, STATE_ID) VALUES (2,'2','WhatsApp','WhatsApp',1);
INSERT INTO ENUM_SOCIAL_NETWORK_TYPE (ID, ORDER_CODE, SHORT_NAME, FULL_NAME, STATE_ID) VALUES (3,'3','Instagram','Instagram',1);
INSERT INTO ENUM_SOCIAL_NETWORK_TYPE (ID, ORDER_CODE, SHORT_NAME, FULL_NAME, STATE_ID) VALUES (4,'4','Facebook','Facebook',1);
INSERT INTO ENUM_SOCIAL_NETWORK_TYPE (ID, ORDER_CODE, SHORT_NAME, FULL_NAME, STATE_ID) VALUES (5,'5','TikTok','TikTok',1);
