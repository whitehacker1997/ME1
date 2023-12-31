CREATE TABLE HL_PERSON
(
	ID						SERIAL NOT NULL PRIMARY KEY,
	PINFL					VARCHAR(14),
    INN						VARCHAR(9),
	
	DOCUMENT_TYPE_ID		INT NOT NULL,
	DOCUMENT_SERIA			VARCHAR(50) NOT NULL,
	DOCUMENT_NUMBER			VARCHAR(50) NOT NULL,
	DOCUMENT_START_ON		TIMESTAMP WITHOUT TIME ZONE,
	DOCUMENT_END_ON			TIMESTAMP WITHOUT TIME ZONE,
	LAST_NAME				VARCHAR(100) NOT NULL,
	FIRST_NAME				VARCHAR(100) NOT NULL,
	MIDDLE_NAME				VARCHAR(100),
	BIRTH_ON				TIMESTAMP WITHOUT TIME ZONE NOT NULL,
	GENDER_ID				INT,
	BIRTH_COUNTRY_ID		INT,
	BIRTH_REGION_ID			INT,
	BIRTH_DISTRICT_ID		INT,
	CITIZENSHIP_ID			INT,
	LIVING_REGION_ID		INT,
	LIVING_DISTRICT_ID		INT,
	
	STATE_ID				INT NOT NULL,
	CREATED_AT				TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW() NOT NULL,
	CREATED_BY				INT,
	MODIFIED_AT				TIMESTAMP WITHOUT TIME ZONE,
	MODIFIED_BY				INT,
    
	CONSTRAINT fk_document_type_id		
		FOREIGN KEY (DOCUMENT_TYPE_ID) REFERENCES ENUM_DOCUMENT_TYPE ( ID ),
	CONSTRAINT fk_birth_country_id		
		FOREIGN KEY (BIRTH_COUNTRY_ID) REFERENCES INFO_COUNTRY ( ID ),
	CONSTRAINT fk_birth_region_id		
		FOREIGN KEY (BIRTH_REGION_ID) REFERENCES INFO_REGION ( ID ),
	CONSTRAINT fk_birth_district_id		
		FOREIGN KEY (BIRTH_DISTRICT_ID) REFERENCES INFO_DISTRICT ( ID ),
	CONSTRAINT fk_citizenship_id		
		FOREIGN KEY (CITIZENSHIP_ID ) REFERENCES INFO_CITIZENSHIP ( ID ),
    CONSTRAINT fk_state_id				
		FOREIGN KEY (STATE_ID) REFERENCES ENUM_STATE ( ID ),
	CONSTRAINT fk_living_region_id		
		FOREIGN KEY (LIVING_REGION_ID) REFERENCES INFO_REGION ( ID ),
	CONSTRAINT fk_living_district_id	
		FOREIGN KEY (LIVING_DISTRICT_ID) REFERENCES INFO_DISTRICT ( ID ),
    CONSTRAINT fk_gender_id				
		FOREIGN KEY (GENDER_ID) REFERENCES ENUM_GENDER ( ID )
);

create unique index hl_person_unique_index_pinfl on HL_PERSON (PINFL)
  where PINFL is not null;
  
create unique index hl_person_unique_index_inn on HL_PERSON (INN)
  where INN is not null;
