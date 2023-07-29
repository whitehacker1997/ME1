INSERT INTO HL_POSITION 
	(ID,
	 CODE,
	 SHORT_NAME,
	 FULL_NAME,
	 IS_TEACHER,
	 STATE_ID
	)
	VALUES
	(
		1,
		'001',
		N'Учитель',
		N'Учитель',
		true,
		1
	),
	(
		2,
		'002',
		N'Директор',
		N'Директор',
		false,
		1
	),
	(
		3,
		'003',
		N'Администратор',
		N'Администратор',
		false,
		1
	);

INSERT INTO HL_POSITION_TRANSLATE
	(OWNER_ID,LANGUAGE_ID,COLUMN_NAME,TRANSLATE_TEXT)
VALUES
	(1,1,N'short_name','Учитель'),(1,1,N'full_name','Учитель'),
	(1,2,N'short_name','Ўқитувчи'),(1,2,N'full_name','Ўқитувчи'),
	(1,3,N'short_name','O`qituvchi'),(1,3,N'full_name','O`qituvchi'),
	(1,4,N'short_name','Teacher'),(1,4,N'full_name','Teacher');
	
INSERT INTO HL_POSITION_TRANSLATE
	(OWNER_ID,LANGUAGE_ID,COLUMN_NAME,TRANSLATE_TEXT)
VALUES
	(2,1,N'short_name','Директор'),(2,1,N'full_name','Директор'),
	(2,2,N'short_name','Директор'),(2,2,N'full_name','Директор'),
	(2,3,N'short_name','Direktor'),(2,3,N'full_name','Direktor'),
	(2,4,N'short_name','Director'),(2,4,N'full_name','Director');

INSERT INTO HL_POSITION_TRANSLATE
	(OWNER_ID,LANGUAGE_ID,COLUMN_NAME,TRANSLATE_TEXT)
VALUES
	(3,1,N'short_name','Администратор'),(3,1,N'full_name','Администратор'),
	(3,2,N'short_name','Администратор'),(3,2,N'full_name','Администратор'),
	(3,3,N'short_name','Administrator'),(3,3,N'full_name','Administrator'),
	(3,4,N'short_name','Administrator'),(3,4,N'full_name','Administrator');