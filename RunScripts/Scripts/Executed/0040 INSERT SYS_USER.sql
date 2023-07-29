
INSERT INTO SYS_USER 
(user_name, password_hash, password_salt,organization_id, person_id, state_id)
(select 
	N'admin', 
	N'PC8cKGwdNDgTjEhMElJE3cy6Xhz0+PsBoibo4r4wteaMItXc5RdWIKClP23yKcXu58+7dI6gl6peMtvYM8XnTA==', 
	N'vfzuPA==',
	(select id from info_organization limit 1), 
	(select id from hl_person limit 1), 
	1
);
